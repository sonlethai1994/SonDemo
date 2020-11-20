#pragma once

#ifndef PUZZLE_SPLITTER
#define PUZZLE_SPLITTER

#include "opencv2/opencv.hpp"

class PuzzleSplitter
{
public:
	PuzzleSplitter();
	PuzzleSplitter(cv::Mat image, int NpiecesUI);

	void GenerateRandomPuzzlePiece(int nbInnerLock, int nbOuterlock, int sizeRect);

private:
	cv::Mat puzzleImage;
	int Npieces;
};

#endif // !PUZZLE_SPLITTER
