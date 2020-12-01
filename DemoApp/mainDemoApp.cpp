#include <iostream>
#include "opencv2/opencv.hpp"
#include "glfw3.h"

#include "cudaImage.h"
#include "cudaSift.h"

int ImproveHomography(SiftData& data, float* homography, int numLoops, float minScore, float maxAmbiguity, float thresh);
void PrintMatchData(SiftData& siftData1, SiftData& siftData2, CudaImage& img);
void DisplayKeyPoint(cv::Mat image, SiftData& siftData);
cv::Mat ApplyHomography(cv::Mat puzzle, cv::Mat piece, float* homography);

int main()
{
	cv::Mat puzzle = cv::imread("C:\\Users\\Son\\Work Space\\Son Test\\GitSon\\SonDemo\\Data\\ImagePuzzle.jpg");
	cv::Mat piece = cv::imread("C:\\tmp\\piece.jpg");

    cv::Mat puzzleFloat, pieceFloat;
    cv::cvtColor(puzzle, puzzleFloat, cv::COLOR_BGR2GRAY);
    cv::cvtColor(piece, pieceFloat, cv::COLOR_BGR2GRAY);

    puzzleFloat.convertTo(puzzleFloat, CV_32FC1);
    pieceFloat.convertTo(pieceFloat, CV_32FC1);

    InitCuda(0);
    CudaImage img1, img2;
    img1.Allocate(puzzle.cols, puzzle.rows, iAlignUp(puzzle.cols, 128), false, NULL, (float*)puzzleFloat.data);
    img2.Allocate(piece.cols, piece.rows, iAlignUp(piece.cols, 128), false, NULL, (float*)pieceFloat.data);
    img1.Download();
    img2.Download();

    SiftData siftData1, siftData2;
    float initBlur = 1.0f;
    float thresh = 0.5f;
    InitSiftData(siftData1, 32768, true, true);
    InitSiftData(siftData2, 32768, true, true);

    float* img1Memory = AllocSiftTempMemory(puzzle.cols, puzzle.rows, 5, false);
    float* img2Memory = AllocSiftTempMemory(piece.cols, piece.rows, 5, false);

    ExtractSift(siftData1, img1, 5, initBlur, thresh, 2.0f, false, img1Memory);
    ExtractSift(siftData2, img2, 5, initBlur, thresh, 0.0f, false, img2Memory);

    DisplayKeyPoint(puzzle, siftData1);
    DisplayKeyPoint(piece, siftData2);

    FreeSiftTempMemory(img1Memory);
    FreeSiftTempMemory(img2Memory);

    MatchSiftData(siftData1, siftData2);

    float homography[9];
    int numMatches;
    FindHomography(siftData1, homography, &numMatches, 10000, 0.00f, 0.80f, 1.0);
    int numFit = ImproveHomography(siftData1, homography, 5, 0.00f, 0.80f, 3.0);

    cv::Mat result = ApplyHomography(puzzle, piece, homography);


    std::cout << "Number of original features: " << siftData1.numPts << " " << siftData2.numPts << std::endl;

    cv::namedWindow("applied homography", cv::WINDOW_FREERATIO);
    cv::imshow("applied homography", result);
    cv::waitKey(0);
    //std::cout << "Number of matching features: " << numFit << " " << numMatches << " " << 100.0f * numFit / std::min(siftData1.numPts, siftData2.numPts) << "% " << initBlur << " " << thresh << std::endl;
    //}

  // Print out and store summary data
    //PrintMatchData(siftData1, siftData2, img1);


	cv::waitKey(0);
}

cv::Mat ApplyHomography(cv::Mat puzzle, cv::Mat piece, float* homography)
{
    int x, y;
    int xMapped, yMapped;
    cv::Mat puzzleClone = puzzle.clone();

    for (int y = 0; y < piece.rows; y++){
        for (int x = 0; x < piece.cols; x++){
            xMapped = homography[0] * x + homography[1] * y + homography[2];
            yMapped = homography[3] * x + homography[4] * y + homography[5];
            if (xMapped > 0 && xMapped < puzzle.cols && yMapped > 0 && yMapped < puzzle.rows)
            {
                puzzleClone.at<cv::Vec3b>(cv::Point(xMapped, yMapped)) = cv::Vec3b(0, 255, 0);
            }
        }
    }
    return puzzleClone;
}

void DisplayKeyPoint(cv::Mat image, SiftData& siftData)
{
    int numPts = siftData.numPts;
    SiftPoint* sift = siftData.h_data;

    for (int k = 0; k < numPts; k++) {
        cv::circle(image, cv::Point(sift[k].xpos, sift[k].ypos), sift[k].scale * 1.41, cv::Scalar(0, 255, 0));
    }

    cv::namedWindow("keypoint", cv::WINDOW_FREERATIO);
    cv::imshow("keypoint", image);
    cv::waitKey(0);
};

void PrintMatchData(SiftData& siftData1, SiftData& siftData2, CudaImage& img)
{
    int numPts = siftData1.numPts;
#ifdef MANAGEDMEM
    SiftPoint* sift1 = siftData1.m_data;
    SiftPoint* sift2 = siftData2.m_data;
#else
    SiftPoint* sift1 = siftData1.h_data;
    SiftPoint* sift2 = siftData2.h_data;
#endif
    float* h_img = img.h_data;
    int w = img.width;
    int h = img.height;
    std::cout << std::setprecision(3);
    for (int j = 0; j < numPts; j++) {
        int k = sift1[j].match;
        if (sift1[j].match_error < 5) {
            float dx = sift2[k].xpos - sift1[j].xpos;
            float dy = sift2[k].ypos - sift1[j].ypos;
#if 0
            if (false && sift1[j].xpos > 550 && sift1[j].xpos < 600) {
                std::cout << "pos1=(" << (int)sift1[j].xpos << "," << (int)sift1[j].ypos << ") ";
                std::cout << j << ": " << "score=" << sift1[j].score << "  ambiguity=" << sift1[j].ambiguity << "  match=" << k << "  ";
                std::cout << "scale=" << sift1[j].scale << "  ";
                std::cout << "error=" << (int)sift1[j].match_error << "  ";
                std::cout << "orient=" << (int)sift1[j].orientation << "," << (int)sift2[k].orientation << "  ";
                std::cout << " delta=(" << (int)dx << "," << (int)dy << ")" << std::endl;
            }
#endif
#if 1
            int len = (int)(fabs(dx) > fabs(dy) ? fabs(dx) : fabs(dy));
            for (int l = 0; l < len; l++) {
                int x = (int)(sift1[j].xpos + dx * l / len);
                int y = (int)(sift1[j].ypos + dy * l / len);
                h_img[y * w + x] = 255.0f;
            }
#endif
        }
        int x = (int)(sift1[j].xpos + 0.5);
        int y = (int)(sift1[j].ypos + 0.5);
        int s = std::min(x, std::min(y, std::min(w - x - 2, std::min(h - y - 2, (int)(1.41 * sift1[j].scale)))));
        int p = y * w + x;
        p += (w + 1);
        for (int k = 0; k < s; k++)
            h_img[p - k] = h_img[p + k] = h_img[p - k * w] = h_img[p + k * w] = 0.0f;
        p -= (w + 1);
        for (int k = 0; k < s; k++)
            h_img[p - k] = h_img[p + k] = h_img[p - k * w] = h_img[p + k * w] = 255.0f;
    }
    std::cout << std::setprecision(6);
}