#pragma once

#include "PuzzleSolver.h"

using namespace System;

namespace Wrapper {
	public ref class Interface
	{
	public:
		Interface();
		bool CheckInputFile(String^ pathFileUI, String^% LOG);
		void SplitImageIntoPieces(int NsuperpixelUI, float m_ratioUI, int nbLoopUI);
	private:
		PuzzleSolver* puzzleSolver;
	};
}

void MarshalString(String^ s, std::string& os);
void MarshalString(String^ s, std::wstring& os);
