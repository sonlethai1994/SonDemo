#include "PuzzleCuda.cuh"

__global__ void ComputeSpatialDistancePixelSeeds(SeedSuperPixel* seeds, int* closestSeed, int width, int height, int Nseeds)
{
	int x = threadIdx.x + blockIdx.x * blockDim.x;
	int y = threadIdx.y + blockIdx.y * blockDim.y;
	int offset = x + y * width;

	float minDist = 100000.0f;
	float distSpatial = 0;
	int minSeedIndex = 0;
	if (x >= 0 && x < width && y >= 0 && y < height){
		for (int k = 0; k < Nseeds; k++){
			distSpatial = sqrtf((x - seeds[k].posX) * (x - seeds[k].posX) + (y - seeds[k].posY) * (y - seeds[k].posY));
			if (distSpatial < minDist){
				minDist = distSpatial;
				minSeedIndex = k;
			}
		}
		closestSeed[offset] = minSeedIndex;
	}
}

__global__ void ComputeDistancePixelSeeds(unsigned char* rgbData, SeedSuperPixel* seeds, int* closestSeed, int width, int height, int Nseeds, float ratio)
{
	int x = threadIdx.x + blockIdx.x * blockDim.x;
	int y = threadIdx.y + blockIdx.y * blockDim.y;
	int offset = x + y * width;

	float minDist = 100000.0f;
	float distSpatial = 0;
	float distColor = 0;
	float dist = 0;
	int minSeedIndex = 0;

	if (x >= 0 && x < width && y >= 0 && y < height)
	{
		int m = 50;
		for (int k = 0; k < Nseeds; k++)
		{
			distSpatial = sqrtf((x - seeds[k].posX) * (x - seeds[k].posX) + (y - seeds[k].posY) * (y - seeds[k].posY));
			if (distSpatial < seeds[k].dimSuperPixel)
			{
				distColor = sqrtf(
					(rgbData[3 * offset] - seeds[k].color[0]) * (rgbData[3 * offset] - seeds[k].color[0]) +
					(rgbData[3 * offset + 1] - seeds[k].color[1]) * (rgbData[3 * offset + 1] - seeds[k].color[1]) +
					(rgbData[3 * offset + 2] - seeds[k].color[2]) * (rgbData[3 * offset + 2] - seeds[k].color[2]));
				dist = distColor + ratio * distSpatial;
				if (dist < minDist)
				{
					minDist = dist;
					minSeedIndex = k;
				}
			}

		}
		closestSeed[offset] = minSeedIndex;
	}
}

__global__ void UpdateSeeds(unsigned char* rgbData, int* closestSeed, SeedSuperPixel* newSeeds, int width, int height, int Nseed)
{
	int x = threadIdx.x + blockIdx.x * blockDim.x;
	int y = threadIdx.y + blockIdx.y * blockDim.y;
	int offset = x + y * width;
	int index = 0;
	if (x >= 0 && x < width && y >= 0 && y < height)
	{
		index = closestSeed[offset];
		atomicAdd(&(newSeeds[index].posX), x);
		atomicAdd(&(newSeeds[index].posY), y);
		atomicAdd(&(newSeeds[index].nbPixel), 1);
		atomicAdd(&(newSeeds[index].color[0]), rgbData[3 * offset]);
		atomicAdd(&(newSeeds[index].color[1]), rgbData[3 * offset + 1]);
		atomicAdd(&(newSeeds[index].color[2]), rgbData[3 * offset + 2]);
	}
}

__global__ void ResetSeeds(SeedSuperPixel* seeds, int N)
{
	int x = threadIdx.x + blockIdx.x * blockDim.x;
	if (x >= 0 && x < N)
	{
		seeds[x].posX = 0;
		seeds[x].posY = 0;
		seeds[x].nbPixel = 0;
		seeds[x].color[0] = 0;
		seeds[x].color[1] = 0;
		seeds[x].color[2] = 0;
	}
}

__global__ void AverageSeeds(SeedSuperPixel* seeds, int N)
{
	int x = threadIdx.x + blockIdx.x * blockDim.x;
	if (x >= 0 && x < N)
	{
		seeds[x].posX /= seeds[x].nbPixel;
		seeds[x].posY /= seeds[x].nbPixel;
		seeds[x].color[0] /= seeds[x].nbPixel;
		seeds[x].color[1] /= seeds[x].nbPixel;
		seeds[x].color[2] /= seeds[x].nbPixel;
	}
}

void ComputeDistancePixelFromSeeds(cv::Mat puzzleImage, SeedSuperPixel* seeds, int* pixelSuperSeed, const int width, const int height, const int Nseeds, const float ratio, const int nbLoop)
{
	unsigned char* d_puzzleImageRGB;
	cudaMalloc((void**)&d_puzzleImageRGB, (size_t)puzzleImage.cols * (size_t)puzzleImage.rows * 3);
	cudaMemcpy(d_puzzleImageRGB, puzzleImage.data, (size_t)puzzleImage.cols * (size_t)puzzleImage.rows * 3, cudaMemcpyHostToDevice);

	SeedSuperPixel* d_seeds;
	cudaMalloc((void**)&d_seeds, sizeof(SeedSuperPixel) * Nseeds);
	cudaMemcpy(d_seeds, seeds, sizeof(SeedSuperPixel) * Nseeds, cudaMemcpyHostToDevice);

	int* d_closestSeed;
	cudaMalloc((void**)&d_closestSeed, width * height * sizeof(int));
	cudaMemset(d_closestSeed, 0, width * height * sizeof(int));

	dim3 threads(16, 16);
	dim3 blocks( (width + threads.x - 1)/ (threads.x), (height + threads.y - 1)/ (threads.y));

	dim3 threadsReset(16);
	dim3 blocksReset((Nseeds + threadsReset.x - 1) / threadsReset.x);

	for (int i = 0; i < nbLoop; i++){
		ComputeDistancePixelSeeds << <blocks, threads >> > (d_puzzleImageRGB, d_seeds, d_closestSeed, width, height, Nseeds, ratio);
		ResetSeeds << <blocksReset, threadsReset >> > (d_seeds, Nseeds);
		UpdateSeeds << <blocks, threads >> > (d_puzzleImageRGB, d_closestSeed, d_seeds, width, height, Nseeds);
		AverageSeeds << <blocksReset, threadsReset >> > (d_seeds, Nseeds);
	}
	cudaMemcpy(pixelSuperSeed, d_closestSeed, width * height * sizeof(int), cudaMemcpyDeviceToHost);
	cudaMemcpy(seeds, d_seeds, sizeof(SeedSuperPixel) * Nseeds, cudaMemcpyDeviceToHost);
	cudaFree(d_puzzleImageRGB);
	cudaFree(d_seeds);
	cudaFree(d_closestSeed);
}

void ComputeVoronoiDiagram(SeedSuperPixel* seeds, int* pixelSuperSeed, const int width, const int height, const int Nseeds)
{
	SeedSuperPixel* d_seeds;
	cudaMalloc((void**)&d_seeds, sizeof(SeedSuperPixel) * Nseeds);
	cudaMemcpy(d_seeds, seeds, sizeof(SeedSuperPixel) * Nseeds, cudaMemcpyHostToDevice);

	int* d_closestSeed;
	cudaMalloc((void**)&d_closestSeed, width * height * sizeof(int));
	cudaMemset(d_closestSeed, 0, width * height * sizeof(int));

	dim3 threads(16, 16);
	dim3 blocks((width + threads.x - 1) / (threads.x), (height + threads.y - 1) / (threads.y));

	ComputeSpatialDistancePixelSeeds<<<blocks,threads>>>(d_seeds, d_closestSeed, width, height, Nseeds);
	cudaMemcpy(pixelSuperSeed, d_closestSeed, width * height * sizeof(int), cudaMemcpyDeviceToHost);
	cudaFree(d_seeds);
	cudaFree(d_closestSeed);
}
