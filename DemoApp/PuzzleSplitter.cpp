#include "PuzzleSplitter.h"
#include "PuzzleCuda.cuh"
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

void PuzzleSplitter::GeneratePiece(VoronoiCell)
{
}

void PuzzleSplitter::SLICsuperpixelsCPU(int Nsuperpixels, int nbLoop, float m_ratio)
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
			seedSuperPix.dimSuperPixel = S * 2;

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
			for (int y = seed.posY - seed.dimSuperPixel / 2; y < seed.posY + seed.dimSuperPixel / 2; y++) {
				for (int x = seed.posX - seed.dimSuperPixel / 2; x < seed.posX + seed.dimSuperPixel / 2; x++) {
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

std::vector<SeedSuperPixel> PuzzleSplitter::SLICsuperpixelsGPU(int Nsuperpixels, int nbLoop, float m_ratio)
{
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
			seedSuperPix.dimSuperPixel = S * 2;
			seedSuperPix.nbPixel = 1;

			seedSuperPix.color[0] = (float)puzzleImage.at<cv::Vec3b>(cv::Point(seedSuperPix.posX, seedSuperPix.posY))[0];
			seedSuperPix.color[1] = (float)puzzleImage.at<cv::Vec3b>(cv::Point(seedSuperPix.posX, seedSuperPix.posY))[1];
			seedSuperPix.color[2] = (float)puzzleImage.at<cv::Vec3b>(cv::Point(seedSuperPix.posX, seedSuperPix.posY))[2];

			SeedArray.push_back(seedSuperPix);
			seedId++;
		}
	}
	int Nseeds = (int)SeedArray.size();
	int* pixelSuperSeed = new int[(size_t)widthPuzzle * (size_t)heightPuzzle];
	float ratio = m_ratio / S;
	ComputeDistancePixelFromSeeds(puzzleImage, &(SeedArray[0]), pixelSuperSeed, widthPuzzle, heightPuzzle, Nseeds, ratio, nbLoop);

	cv::Mat QuantizedImage = puzzleImage.clone();
	int indexSuperSeed;


	for (int y = 0; y < heightPuzzle; y++){
		for (int x = 0; x < widthPuzzle; x++){
			indexSuperSeed = pixelSuperSeed[x + y * widthPuzzle];
			QuantizedImage.at<cv::Vec3b>(cv::Point(x, y))[0] = (unsigned char)SeedArray[indexSuperSeed].color[0];
			QuantizedImage.at<cv::Vec3b>(cv::Point(x, y))[1] = (unsigned char)SeedArray[indexSuperSeed].color[1];
			QuantizedImage.at<cv::Vec3b>(cv::Point(x, y))[2] = (unsigned char)SeedArray[indexSuperSeed].color[2];
		}
	}

	for (auto& seed : SeedArray)
	{
		cv::circle(QuantizedImage, cv::Point(seed.posX, seed.posY), 10, cv::Scalar(0, 0, 255));
	}

	//std::string fileToWrite = "C:\\Users\\Son\\Work Space\\Son Test\\GitSon\\SonDemo\\Data\\QuantizedImage\\Quantized.jpg";
	//cv::imwrite(fileToWrite, QuantizedImage);
	return SeedArray;
}

std::vector<VoronoiCell> PuzzleSplitter::ComputeVoronoiDiagramGPU(std::vector<SeedSuperPixel> seeds)
{
	int Nseed = (int)seeds.size();
	int* pixelSuperSeed = new int[(size_t)widthPuzzle * (size_t)heightPuzzle];
	ComputeVoronoiDiagram(&(seeds[0]), pixelSuperSeed, widthPuzzle, heightPuzzle, Nseed);

	cv::Mat VoronoiImage = puzzleImage.clone();

	// GetVoronoiCell 
	std::vector<VoronoiCell> VoronoiCells =  GetVoronoiCell(VoronoiImage, pixelSuperSeed, seeds);
	std::vector<pixelContour> allContours = GetAllContoursVoronoiCells(VoronoiImage, pixelSuperSeed);
	//std::vector<pieceContour> pieceContours = ExtractPieceContours(Nseed, allContours);
	int widthMax, heightMax;
	GetSizePuzzlePiece(VoronoiCells, widthMax, heightMax);
	
	for (auto& cell : VoronoiCells){
		cell.width = 2 * widthMax;
		cell.height = 2 * heightMax;
		cell.Image = cv::Mat::zeros(2 * widthMax, 2 * heightMax, CV_8UC3);
		//cell.contour = pieceContours[cell.id_seed];
		cell.CopyDataToImage(false);
		cell.dataPosition.clear();
		cell.dataColor.clear();
		std::cout << "Nb edge = " << cell.contour.edges.size() << std::endl;
	}



	return VoronoiCells;
}

std::vector<VoronoiCell> PuzzleSplitter::GetVoronoiCell(cv::Mat VoronoiImage, int* pixelSuperSeed,  std::vector<SeedSuperPixel> seeds)
{
	int xMin, xMax, yMin, yMax;
	int indexSuperSeed;
	int Nseed = (int)seeds.size();

	std::vector<VoronoiCell> VoronoiCells;
	for (int k = 0; k < Nseed; k++) {
		VoronoiCell cell;
		xMin = 10000; yMin = 10000;
		xMax = 0; yMax = 0;
		for (int y = 0; y < heightPuzzle; y++) {
			for (int x = 0; x < widthPuzzle; x++) {
				indexSuperSeed = pixelSuperSeed[x + y * widthPuzzle];
				if (k == indexSuperSeed) {
					VoronoiImage.at<cv::Vec3b>(cv::Point(x, y))[0] = (unsigned char)seeds[indexSuperSeed].color[0];
					VoronoiImage.at<cv::Vec3b>(cv::Point(x, y))[1] = (unsigned char)seeds[indexSuperSeed].color[1];
					VoronoiImage.at<cv::Vec3b>(cv::Point(x, y))[2] = (unsigned char)seeds[indexSuperSeed].color[2];

					if (x < xMin)	xMin = x;
					if (x > xMax)	xMax = x;
					if (y < yMin)	yMin = y;
					if (y > yMax)	yMax = y;

					cell.dataPosition.push_back(cv::Point(x, y));
					cell.dataColor.push_back(puzzleImage.at<cv::Vec3b>(cv::Point(x, y)));
				}
			}
		}
		if (cell.dataPosition.size() > 0){
			cell.width = abs(xMax - xMin);
			cell.height = abs(yMax - yMin);
			cell.id_seed = k;
			VoronoiCells.push_back(cell);
		}
		
	}
	return VoronoiCells;
}

std::vector<pixelContour> PuzzleSplitter::GetAllContoursVoronoiCells(cv::Mat VoronoiImage, int* pixelSuperSeed)
{
	std::vector<pixelContour> allContours;
	for (int y = 0; y < heightPuzzle; y++) {
		for (int x = 0; x < widthPuzzle; x++) {
			// check left 
			pixelContour pixelContour;
			pixelContour.seed_id = pixelSuperSeed[x + y * widthPuzzle];
			if (x - 1 >= 0) {
				if (VoronoiImage.at<cv::Vec3b>(cv::Point(x - 1, y)) != VoronoiImage.at<cv::Vec3b>(cv::Point(x, y))) {
					pixelContour.NeighboorLabel.insert(pixelSuperSeed[(x - 1) + y * widthPuzzle]);
				}
			}
			else {
				// border --> contour 
				pixelContour.NeighboorLabel.insert(pixelSuperSeed[x + y * widthPuzzle]);
			}
			// check right
			if (x + 1 < widthPuzzle) {
				if (VoronoiImage.at<cv::Vec3b>(cv::Point(x + 1, y)) != VoronoiImage.at<cv::Vec3b>(cv::Point(x, y))) {
					pixelContour.NeighboorLabel.insert(pixelSuperSeed[(x + 1) + y * widthPuzzle]);
				}
			}
			else {
				// border --> contour 
				pixelContour.NeighboorLabel.insert(pixelSuperSeed[x + y * widthPuzzle]);
			}
			// check top 
			if (y - 1 >= 0) {
				if (VoronoiImage.at<cv::Vec3b>(cv::Point(x, y - 1)) != VoronoiImage.at<cv::Vec3b>(cv::Point(x, y))) {
					pixelContour.NeighboorLabel.insert(pixelSuperSeed[x + (y - 1) * widthPuzzle]);
				}
			}
			else {
				// border --> contour 
				pixelContour.NeighboorLabel.insert(pixelSuperSeed[x + y * widthPuzzle]);
			}
			// check bot
			if (y + 1 < heightPuzzle) {
				if (VoronoiImage.at<cv::Vec3b>(cv::Point(x, y + 1)) != VoronoiImage.at<cv::Vec3b>(cv::Point(x, y))) {
					pixelContour.NeighboorLabel.insert(pixelSuperSeed[x + (y + 1) * widthPuzzle]);
				}
			}
			else {
				// border --> contour 
				pixelContour.NeighboorLabel.insert(pixelSuperSeed[x + y * widthPuzzle]);
			}
			if (pixelContour.NeighboorLabel.size() != 0) {
				pixelContour.x = x;
				pixelContour.y = y;
				allContours.push_back(pixelContour);
			}
		}
	}
	return allContours;
}

std::vector<pieceContour> PuzzleSplitter::ExtractPieceContours(int Nseed, std::vector<pixelContour> allContours)
{
	std::vector<pieceContour> pieceContours;
	for (int k = 0; k < Nseed; k++) {
		// extract all contours that belong to seed K (label contour == K)
		pieceContour seedContour;
		seedContour.id_seed = k;
		std::copy_if(allContours.begin(), allContours.end(), std::back_inserter(seedContour.pixels), [k](pixelContour pt) -> bool
			{
				bool condition = false;
				if (pt.seed_id == k)
					condition = true;

				return condition;
			});

		// extract neighboor of seeds
		std::set<int> neighboorSeed;
		for (auto pix : seedContour.pixels) {
			for (auto lab : pix.NeighboorLabel) {
				neighboorSeed.insert(lab);
			}
		}
		seedContour.labelNeighboors = neighboorSeed;

		for (auto lab : seedContour.labelNeighboors) {
			edge edgePiece;
			edgePiece.id_neighboorSeed = lab;
			for (auto pix : seedContour.pixels) {
				for (auto labPix : pix.NeighboorLabel) {
					if (lab == labPix)
						edgePiece.pixels.push_back(pix);
				}
			}
			seedContour.edges.push_back(edgePiece);
		}
		// no need anymore of pixel 
		// pixel are sorted to edge !!
		seedContour.pixels.clear();

		// find corners;
		int yMin, yMax;
		cv::Point2i extremity1, extremity2;
		for (auto& edge : seedContour.edges) {
			// find extremity
			yMin = 10000;
			yMax = 0;
			std::sort(edge.pixels.begin(), edge.pixels.end(), [](pixelContour pix1, pixelContour pix2)
				{
					bool condition = false;
					if (pix1.y < pix2.y)
						condition = true;
					return condition;
				});

			edge.extremity1 = cv::Point(edge.pixels[0].x, edge.pixels[0].y);
			edge.extremity2 = cv::Point(edge.pixels[edge.pixels.size() - 1].x, edge.pixels[edge.pixels.size() - 1].y);
		}
		pieceContours.push_back(seedContour);
	}
	return pieceContours;
}

void PuzzleSplitter::GetSizePuzzlePiece(std::vector<VoronoiCell> cells, int& widthMax, int& heightMax)
{
	widthMax = 0;
	heightMax = 0;

	for (const auto& element : cells)
	{
		// normalize coordinate or copy array data to new centered image 
		if (element.width > widthMax)
			widthMax = element.width;
		if (element.height > heightMax)
			heightMax = element.height;
	}
}

std::vector<int> PixelDistanceFromSeeds(const int x, const int y, const std::vector<SeedSuperPixel> seeds)
{
	float distance;
	std::vector<int> indexNearSeeds;
	for (std::vector<SeedSuperPixel>::const_iterator it = seeds.begin(); it != seeds.end(); it++)
	{
		distance = sqrt(((*it).posX - x) * ((*it).posX - x) + ((*it).posY - y) * ((*it).posY - y));
		if (distance < (*it).dimSuperPixel)
		{
			indexNearSeeds.push_back((*it).id);
		}
	}
	return indexNearSeeds;
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

VoronoiCell::VoronoiCell()
{
}

void VoronoiCell::NormalizeCoord()
{
	// compute mean 
	int accX = 0, accY = 0;
	int meanX, meanY;
	for (auto& element : dataPosition)
	{
		accX += element.x;
		accY += element.y;
	}
	meanX = accX / dataPosition.size();
	meanY = accY / dataPosition.size();
	for (auto& element : dataPosition){
		element.x -= meanX;
		element.y -= meanY;
	}

	for (auto& element : contour.edges){
		for (auto& pix : element.pixels){
			pix.x -= meanX;
			pix.y -= meanY;
		}

		element.extremity1 -= cv::Point(meanX, meanY);
		element.extremity2 -= cv::Point(meanX, meanY);
	}



	// substract mean from each data
}

void VoronoiCell::CopyDataToImage(bool highlightCorner)
{
	NormalizeCoord();
	int middleX = width/2, middleY = height/2;
	int x, y;
	int Npix = (int)dataPosition.size();
	for (int i = 0; i < Npix; i++)
	{
		x = dataPosition[i].x + middleX;
		y = dataPosition[i].y + middleY;
		Image.at<cv::Vec3b>(cv::Point(x, y)) = dataColor[i];
	}

	if (highlightCorner)
	{
		for (auto edge : contour.edges) {
			for (auto pix : edge.pixels) {
				Image.at<cv::Vec3b>(cv::Point(pix.x + middleX, pix.y + middleY)) = cv::Vec3b(255, 255, 255);
			}

		}
	}

}

void VoronoiCell::CharacterizePiece()
{
	cv::Mat binaryPiece = Image.clone();
	cv::cvtColor(binaryPiece, binaryPiece, cv::COLOR_BGR2GRAY);
	cv::threshold(binaryPiece, binaryPiece, 0, 255, cv::THRESH_OTSU);

	cv::morphologyEx(binaryPiece, binaryPiece, cv::MORPH_CLOSE, cv::getStructuringElement(cv::MorphShapes::MORPH_CROSS, cv::Size(40, 40)));
	cv::namedWindow("puzzle piece", cv::WINDOW_FREERATIO);
	cv::imshow("puzzle piece", binaryPiece);
	cv::waitKey(0);
	cv::Mat contours;


	//cv::findContours(Image, contours, )
	// compute extremity
	// compute contours
	// compute edges
}
