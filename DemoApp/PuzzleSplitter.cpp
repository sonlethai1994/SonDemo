#include "PuzzleSplitter.h"
#include <numeric>

PuzzleSplitter::PuzzleSplitter()
{

}

PuzzleSplitter::PuzzleSplitter(cv::Mat image)
{
	puzzleImage = image;
	widthPuzzle = puzzleImage.cols;
	heightPuzzle = puzzleImage.rows;
}

void PuzzleSplitter::SLICsuperpixels(int Nsuperpixels, int nbLoop)
{
	// 1) Initialize Super pixel center by sampling N locations on a regular grid
	// move slightly within 3x3 neighborhood to lie on the lowest gradient position
	// seed in flastest location (not want to start on a edge)
	int xPos, yPos;
	int S = (int) sqrt((widthPuzzle * heightPuzzle) / Nsuperpixels);
	int nbSuperPixX = widthPuzzle / S;
	int nbSuperPixY = heightPuzzle / S;

	std::vector<SeedSuperPixel> SeedArray;
	int seedId = 0;
	for (int y = 0; y < nbSuperPixY; y++){
		for (int x = 0; x < nbSuperPixX; x++){
			SeedSuperPixel seedSuperPix;
			xPos = x * S + S;
			yPos = y * S + S;

			if (xPos >= widthPuzzle || yPos >= heightPuzzle)
				continue;

			// position shifted to be in center
			seedSuperPix.id = seedId;
			seedSuperPix.posX = xPos;
			seedSuperPix.posY = yPos;
			seedSuperPix.widthNeighborhood = S * 2;
			seedSuperPix.heightNeighborhood = S * 2;

			seedSuperPix.color[0] = (float)puzzleImage.at<cv::Vec3b>(cv::Point(seedSuperPix.posX, seedSuperPix.posY))[0];
			seedSuperPix.color[1] = (float)puzzleImage.at<cv::Vec3b>(cv::Point(seedSuperPix.posX, seedSuperPix.posY))[1];
			seedSuperPix.color[2] = (float)puzzleImage.at<cv::Vec3b>(cv::Point(seedSuperPix.posX, seedSuperPix.posY))[2];

			SeedArray.push_back(seedSuperPix);
			seedId++;
		}
	}

	// 2) For each cluster center mi, compute distance between mi and each pixel in the neighborhood (interdistance super pixel)
	// Assign to custer i if distance is better than current value

	superPixelIndexMap = new int[std::size_t(widthPuzzle) * std::size_t(heightPuzzle)];
	distanceMap = new float[std::size_t(widthPuzzle) * std::size_t(heightPuzzle)];

	int indexSuperPix;
	int offset = 0;
	std::vector<cv::Vec2f> SuperPixelClass;
	std::vector<cv::Vec3f> SuperPixelColor;
	for (int i = 0; i < nbLoop; i++){
		// reset distance map + indexmap
		memset(superPixelIndexMap, 0, std::size_t(widthPuzzle) * std::size_t(heightPuzzle) * sizeof(int));
		for (std::size_t k = 0; k < std::size_t(widthPuzzle) * std::size_t(heightPuzzle); k++)
			distanceMap[k] = 10000;

		for (auto seed : SeedArray) {
			// check neighborhood seed super pixel
			for (int y = seed.posY - seed.heightNeighborhood / 2; y < seed.posY + seed.heightNeighborhood / 2; y++) {
				for (int x = seed.posX - seed.widthNeighborhood / 2; x < seed.posX + seed.widthNeighborhood / 2; x++) {
					if (x >= 0 && x < widthPuzzle && y >= 0 && y < heightPuzzle) {
						offset = x + y * widthPuzzle;
						float distance = ComputeDistanceSuperPixel(puzzleImage, seed, cv::Point(x, y), S);
						if (distance < distanceMap[offset]) {
							distanceMap[offset] = distance;
							superPixelIndexMap[offset] = seed.id;
						}
					}
				}
			}
		}

		cv::Mat QuantizedImage = puzzleImage.clone();
		// update seed 
		for (auto &seed : SeedArray){
			SuperPixelClass.clear();
			SuperPixelColor.clear();
			for (int y = 0; y < heightPuzzle; y++){
				for (int x = 0; x < widthPuzzle; x++){
					offset = x + y * widthPuzzle;
					indexSuperPix = superPixelIndexMap[offset];
					if (seed.id == indexSuperPix) {
						SuperPixelClass.push_back(cv::Vec2f(x, y));
						SuperPixelColor.push_back(cv::Vec3f(
							puzzleImage.at<cv::Vec3b>(cv::Point(x, y))[0],
							puzzleImage.at<cv::Vec3b>(cv::Point(x, y))[1],
							puzzleImage.at<cv::Vec3b>(cv::Point(x, y))[2])
							);
					}
				}
			}

			if (SuperPixelClass.size() == 0)
				continue;

			// compute new mean
			cv::Vec2f newMeanPosition = std::accumulate(SuperPixelClass.begin(), SuperPixelClass.end(), cv::Vec2f(0.0f, 0.0f));
			cv::Vec3f newAvgColor = std::accumulate(SuperPixelColor.begin(), SuperPixelColor.end(), cv::Vec3f(0.0f, 0.0f, 0.0f));
			newMeanPosition[0] /= SuperPixelClass.size();
			newMeanPosition[1] /= SuperPixelClass.size();

			newAvgColor[0] /= SuperPixelClass.size();
			newAvgColor[1] /= SuperPixelClass.size();
			newAvgColor[2] /= SuperPixelClass.size();
			
			seed.posX = (int)newMeanPosition[0];
			seed.posY = (int)newMeanPosition[1];

			seed.color[0] = newAvgColor[0];
			seed.color[1] = newAvgColor[1];
			seed.color[2] = newAvgColor[2];

		}

		// check segmentation 
		for (int y = 0; y < heightPuzzle; y++){
			for (int x = 0; x < widthPuzzle; x++){
				offset = x + y * widthPuzzle;
				indexSuperPix = superPixelIndexMap[offset];
				QuantizedImage.at<cv::Vec3b>(cv::Point(x, y)) =
					cv::Vec3b(
						SeedArray[indexSuperPix].color[0],
						SeedArray[indexSuperPix].color[1],
						SeedArray[indexSuperPix].color[2]);
			}
		}

		for (auto seed : SeedArray)
		{
			cv::circle(QuantizedImage, cv::Point(seed.posX, seed.posY), 10, cv::Scalar(0, 0, 255));
		}

		std::string fileToWrite = "C:\\Users\\Son\\Work Space\\Son Test\\GitSon\\SonDemo\\Data\\QuantizedImage\\iter" + std::to_string(i) + ".jpg";
		cv::imwrite(fileToWrite, QuantizedImage);
	}
}

float ComputeDistanceSuperPixel(const cv::Mat &puzzleImage, const SeedSuperPixel seed, const cv::Point2i pixel, const float S)
{
	// What is the distance function ? 
	// Combination of color distance + spatial distance
	// carreful of the scale 
	// D = sqrt ( (dc/c)^2 + (ds/s)^2) with c = max color distance, s = max spatial distance
	// use c to tune trade off --> 
	// cbig --> superpixel more compact 
	// csmall --> superpixel more 
	// compactness ?  
	static float m = 150;
	cv::Scalar colorPix = puzzleImage.at<cv::Vec3b>(pixel);

	float distColor = sqrt( 
		(seed.color[0] - colorPix[0]) * (seed.color[0] - colorPix[0]) +
		(seed.color[1] - colorPix[1]) * (seed.color[1] - colorPix[1]) + 
		(seed.color[2] - colorPix[2]) * (seed.color[2] - colorPix[2]));

	float distSpatial = sqrt( 
		(seed.posX - pixel.x) * (seed.posX - pixel.x) + 
		(seed.posY - pixel.y) * (seed.posY - pixel.y));

	return  distColor + m / S * distSpatial;

}