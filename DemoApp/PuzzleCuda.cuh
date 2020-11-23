#ifndef PUZZLE_CUDA
#define PUZZLE_CUDA

#include <cuda_runtime.h>
#include <cuda_device_runtime_api.h>
#include <opencv2/opencv.hpp>
#include <opencv2/cudaarithm.hpp>
#include <opencv2/cudafeatures2d.hpp>
#include <opencv2/cudaimgproc.hpp>
#include "PuzzleSplitter.h"

extern "C"
void ComputeDistancePixelFromSeeds(cv::Mat puzzleImage, SeedSuperPixel* seeds, int* pixelSuperSeed, const int width,const int height,const int Nseeds, const float ratio, const int nbLoop);



#endif // !PUZZLE_CUDA

