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

void PuzzleSolver::SplitImageIntoPieces(int NsuperpixelUI, float m_ratioUI, int nbLoopUI)
{
	puzzleSplitter = new PuzzleSplitter(puzzleImage);
	//puzzleSplitter->SLICsuperpixelsCPU(500, 10);
	puzzleSplitter->SLICsuperpixelsGPU(NsuperpixelUI, m_ratioUI, nbLoopUI);
}
