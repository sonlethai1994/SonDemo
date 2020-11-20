#pragma once
#ifndef PUZZLE_SOLVER
#define PUZZLE_SOLVER

#include <iostream>
#include <filesystem>
#include "opencv2/opencv.hpp"

#include "PuzzleSplitter.h"

class PuzzleSolver
{
public:
	PuzzleSolver();
	void CheckInputFile(std::string pathImageUI, bool &valid);
	void SplitImageIntoPieces();

private:
	// properties files
	std::string imagePath;
	int widthImage, heightImage;

	// attribut
	cv::Mat puzzleImage;

	// other classes
	PuzzleSplitter* puzzleSplitter;
};

#endif // !PUZZLE_SOLVER
