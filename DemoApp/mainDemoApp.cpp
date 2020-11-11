#include <iostream>
#include "opencv2/opencv.hpp"
#include "glfw3.h"

int main()
{
	cv::Mat image = cv::imread("C:\\Users\\Son\\Desktop\\photoCV.jpg");
	cv::namedWindow("image", cv::WINDOW_FREERATIO);
	cv::imshow("image", image);
	cv::waitKey(0);
}