#pragma once
#ifndef PUZZLE_SOLVER
#define PUZZLE_SOLVER

#include <iostream>
#include <filesystem>
#include "opencv2/opencv.hpp"
#include "PuzzleSplitter.h"
#include "cudaImage.h"
#include "cudaSift.h"

class PuzzleSolver
{
public:
	PuzzleSolver();
	void CheckInputFile(std::string pathImageUI, bool &valid);
	int SplitImageIntoPieces(int NsuperpixelUI, float m_ratioUI, int nbLoopUI);
	cv::Mat GetPuzzlePiece(int id, int& width, int& height);
	void matchPiece(float thresh1, float thresh2, float minScale1, float minScale2, float maxAmbi, float threshRansac, float minScore, cv::Mat piece);
private:
	// properties files
	std::string imagePath;
	int widthImage, heightImage;

	// attribut
	cv::Mat puzzleImage;
	cv::Mat resultPuzzle;

	// other classes
	PuzzleSplitter* puzzleSplitter;

	std::vector<VoronoiCell> puzzlePieces;
};

#endif // !PUZZLE_SOLVER
