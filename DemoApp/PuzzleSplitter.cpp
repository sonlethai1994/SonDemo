#include "PuzzleSplitter.h"

PuzzleSplitter::PuzzleSplitter()
{

}

PuzzleSplitter::PuzzleSplitter(cv::Mat image, int NpiecesUI)
{
	puzzleImage = image;
	Npieces = NpiecesUI;
}

void PuzzleSplitter::GenerateRandomPuzzlePiece(int nbInnerLock, int nbOuterlock, int sizeRect)
{


}
