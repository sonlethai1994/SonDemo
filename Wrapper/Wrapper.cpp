#include "pch.h"

#include "Wrapper.h"

void MarshalString(String^ s, std::string& os)
{
    using namespace Runtime::InteropServices;
    const char* chars = (const char*)(Marshal::StringToHGlobalAnsi(s)).ToPointer();
    os = chars;
    Marshal::FreeHGlobal(IntPtr((void*)chars));
}

void MarshalString(String^ s, std::wstring& os)
{
    using namespace Runtime::InteropServices;
    const wchar_t* chars = (const wchar_t*)(Marshal::StringToHGlobalUni(s)).ToPointer();
    os = chars;
    Marshal::FreeHGlobal(IntPtr((void*)chars));
}


Wrapper::Interface::Interface()
{
    puzzleSolver = new PuzzleSolver();
}

bool Wrapper::Interface::CheckInputFile(String^ pathFileUI, String^% LOG)
{
    std::string pathFile_str;
    bool validFile;
    MarshalString(pathFileUI, pathFile_str);
    puzzleSolver->CheckInputFile(pathFile_str, validFile);
    if (!validFile)
    {
        LOG = "Input file is not correct. Should be an jpg.";
    }
       
    return validFile;
}

void Wrapper::Interface::SplitImageIntoPieces(int NsuperpixelUI, float m_ratioUI, int nbLoopUI)
{
    puzzleSolver->SplitImageIntoPieces(NsuperpixelUI, m_ratioUI, nbLoopUI);
}

