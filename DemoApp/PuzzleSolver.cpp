#include "PuzzleSolver.h"

PuzzleSolver::PuzzleSolver()
{
}

void PuzzleSolver::CheckInputFile(std::string pathImageUI, bool& valid)
{
	std::filesystem::path pathFile(pathImageUI);
	std::string extensionFile = pathFile.extension().string();
	if (extensionFile == ".jpg")
	{
		valid = true;
		imagePath = pathImageUI;
		puzzleImage = cv::imread(imagePath);
		widthImage = puzzleImage.cols;
		heightImage = puzzleImage.rows;
	}
	else
		valid = false;
}

void PuzzleSolver::SplitImageIntoPieces()
{
	puzzleSplitter = new PuzzleSplitter(puzzleImage);
	puzzleSplitter->SLICsuperpixels(500, 10);
}
