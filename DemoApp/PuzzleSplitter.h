#pragma once

#ifndef PUZZLE_SPLITTER
#define PUZZLE_SPLITTER

#include "opencv2/opencv.hpp"

struct SeedSuperPixel
{
	int posX, posY;
	int widthNeighborhood, heightNeighborhood;
	int id;
	cv::Vec3f color;
};


class PuzzleSplitter
{
public:
	PuzzleSplitter();
	PuzzleSplitter(cv::Mat image);

	// Cluster 5D space [r,g,b,x,y]
	void SLICsuperpixels(int Nsuperpixels, int nbLoop);



private:
	cv::Mat puzzleImage;
	
	int* superPixelIndexMap;
	float* distanceMap;

	int widthPuzzle, heightPuzzle;
	int Nsuperpixels;
};

float ComputeDistanceSuperPixel(const cv::Mat &puzzleImage, const SeedSuperPixel seed, const cv::Point2i pixel, const float S);

#endif // !PUZZLE_SPLITTER
