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
        resultPuzzle = cv::Mat(cv::Size(widthImage, heightImage), CV_8UC3);
	}
	else
		valid = false;
}

int PuzzleSolver::SplitImageIntoPieces(int NsuperpixelUI, float m_ratioUI, int nbLoopUI)
{
	puzzleSplitter = new PuzzleSplitter(puzzleImage);
	//puzzleSplitter->SLICsuperpixelsCPU(500, 10);
	auto seeds = puzzleSplitter->SLICsuperpixelsGPU(NsuperpixelUI, m_ratioUI, nbLoopUI);
	puzzlePieces = puzzleSplitter->ComputeVoronoiDiagramGPU(seeds);
	int Npieces = (int)puzzlePieces.size();

	return Npieces;
}

cv::Mat PuzzleSolver::GetPuzzlePiece(int id, int& width, int& height)
{
	VoronoiCell piece = puzzlePieces[id];
	width = piece.width;
	height = piece.height;

	return piece.Image;
}

void PuzzleSolver::matchPiece(float thresh1, float thresh2, float minScale1, float minScale2, float maxAmbi, float threshRansac, float minScore, cv::Mat piece)
{
    //cv::Mat puzzle = cv::imread("C:\\Users\\Son\\Work Space\\Son Test\\GitSon\\SonDemo\\Data\\ImagePuzzle.jpg");
    //cv::Mat piece = cv::imread("C:\\tmp\\piece.jpg");

    cv::Mat puzzleFloat, pieceFloat;
    cv::cvtColor(puzzleImage, puzzleFloat, cv::COLOR_BGR2GRAY);
    cv::cvtColor(piece, pieceFloat, cv::COLOR_BGR2GRAY);

    puzzleFloat.convertTo(puzzleFloat, CV_32FC1);
    pieceFloat.convertTo(pieceFloat, CV_32FC1);

    InitCuda(0);
    CudaImage img1, img2;
    img1.Allocate(puzzleFloat.cols, puzzleFloat.rows, iAlignUp(puzzleFloat.cols, 128), false, NULL, (float*)puzzleFloat.data);
    img2.Allocate(pieceFloat.cols, pieceFloat.rows, iAlignUp(pieceFloat.cols, 128), false, NULL, (float*)pieceFloat.data);
    img1.Download();
    img2.Download();

    SiftData siftData1, siftData2;
    float initBlur = 1.0f;
    float thresh = 0.5f;
    InitSiftData(siftData1, 32768, true, true);
    InitSiftData(siftData2, 32768, true, true);

    float* img1Memory = AllocSiftTempMemory(puzzleFloat.cols, puzzleFloat.rows, 5, false);
    float* img2Memory = AllocSiftTempMemory(piece.cols, piece.rows, 5, false);

    ExtractSift(siftData1, img1, 5, initBlur, thresh1, minScale1, false, img1Memory);
    ExtractSift(siftData2, img2, 5, initBlur, thresh2, minScale2, false, img2Memory);

    //DisplayKeyPoint(puzzleImage, siftData1);
    //DisplayKeyPoint(piece, siftData2);

    FreeSiftTempMemory(img1Memory);
    FreeSiftTempMemory(img2Memory);

    MatchSiftData(siftData1, siftData2);

    float homography[9];
    int numMatches;
    FindHomography(siftData1, homography, &numMatches, 10000, minScore, maxAmbi, threshRansac);
    //int numFit = ImproveHomography(siftData1, homography, 5, 0.00f, 0.80f, 3.0);

    //cv::Mat result = ApplyHomography(puzzle, piece, homography);


    std::cout << "Number of original features: " << siftData1.numPts << " " << siftData2.numPts << std::endl;

    //cv::namedWindow("applied homography", cv::WINDOW_FREERATIO);
    //cv::imshow("applied homography", result);
    //cv::waitKey(0);
}
