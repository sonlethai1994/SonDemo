#pragma once

#include "PuzzleSolver.h"

using namespace System;

namespace Wrapper {
	public ref class Interface
	{
	public:
		Interface();
		bool CheckInputFile(String^ pathFileUI, String^% LOG);
		int SplitImageIntoPieces(int NsuperpixelUI, float m_ratioUI, int nbLoopUI);
		System::Drawing::Bitmap^ GetPiecePuzzle(int id);
		void matchPiecePuzzle(float thresh1, float thresh2, float minScale1, float minScale2, float maxAmbi, float threshRansac, float minScore, System::Drawing::Bitmap^ piece);
		void Save(System::Drawing::Bitmap^ image);

	private:
		PuzzleSolver* puzzleSolver;

		System::Drawing::Bitmap^ MatToBitmap(cv::Mat srcImg);
		cv::Mat BitmapToMat(System::Drawing::Bitmap^ bitmap);
	};
}

void MarshalString(String^ s, std::string& os);
void MarshalString(String^ s, std::wstring& os);
