#pragma once

#ifndef PUZZLE_SPLITTER
#define PUZZLE_SPLITTER

#include "opencv2/opencv.hpp"

struct SeedSuperPixel
{
	int posX, posY;
	int dimSuperPixel;
	int id;
	int nbPixel;
	float color[3];
};

struct pixelContour
{
	int x, y;
	std::set<int> NeighboorLabel;
	int seed_id;
};


struct edge
{
	std::vector<pixelContour> pixels;
	int id_neighboorSeed;
	cv::Point extremity1;
	cv::Point extremity2;
};

struct pieceContour
{
	std::vector<pixelContour> pixels;
	std::vector<edge> edges;
	std::set<int> labelNeighboors;
	int id_seed;
};

class  VoronoiCell
{
public :
	VoronoiCell();

	std::vector<cv::Point2i> cornersCell;
	std::vector<cv::Point2i> dataPosition;
	std::vector<cv::Vec3b> dataColor;
	cv::Mat Image;

	void NormalizeCoord();
	void CopyDataToImage(bool highlightCorner);
	void CharacterizePiece();

	int width;
	int height;
	int id_seed;
	pieceContour contour;
};


class PuzzleSplitter
{
public:
	PuzzleSplitter();
	PuzzleSplitter(cv::Mat image);

	void GeneratePiece(VoronoiCell cell);
	// Cluster 5D space [r,g,b,x,y]
	void SLICsuperpixelsCPU(int Nsuperpixels, int nbLoop, float m_ratio);
	std::vector<SeedSuperPixel> SLICsuperpixelsGPU(int Nsuperpixels, int nbLoop, float m_ratio);
	std::vector<VoronoiCell> ComputeVoronoiDiagramGPU(std::vector<SeedSuperPixel> seeds);
	std::vector<VoronoiCell> GetVoronoiCell(cv::Mat VoronoiImage, int* pixelSuperSeed, std::vector<SeedSuperPixel> seeds);
	std::vector<pixelContour> GetAllContoursVoronoiCells(cv::Mat VoronoiImage, int* pixelSuperSeed);
	std::vector<pieceContour> ExtractPieceContours(int Nseed, std::vector<pixelContour> allContours);
	void GetSizePuzzlePiece(std::vector<VoronoiCell> cells, int &widthMax, int &heightMax);

private:
	cv::Mat puzzleImage;
	
	int* superPixelIndexMap;
	float* distanceMap;

	int widthPuzzle, heightPuzzle;
	int Nsuperpixels;
};


float ComputeDistanceSuperPixel(const cv::Mat &puzzleImage, const SeedSuperPixel seed, const cv::Point2i pixel, const float S);

#endif // !PUZZLE_SPLITTER
