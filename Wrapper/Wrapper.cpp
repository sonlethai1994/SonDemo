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

int Wrapper::Interface::SplitImageIntoPieces(int NsuperpixelUI, float m_ratioUI, int nbLoopUI)
{
    int Npieces = puzzleSolver->SplitImageIntoPieces(NsuperpixelUI, m_ratioUI, nbLoopUI);
    return Npieces;
}

System::Drawing::Bitmap^ Wrapper::Interface::GetPiecePuzzle(int id)
{
    int width, height;
    cv::Mat imageCV = puzzleSolver->GetPuzzlePiece(id, width, height);
    int stride = imageCV.size().width * imageCV.channels();

    System::Drawing::Bitmap^ image_UI = MatToBitmap(imageCV);

    return image_UI;
}

void Wrapper::Interface::matchPiecePuzzle(float thresh1, float thresh2, float minScale1, float minScale2, float maxAmbi, float threshRansac, float minScore, System::Drawing::Bitmap^ piece)
{
    cv::Mat piece_CV = BitmapToMat(piece);

    puzzleSolver->matchPiece(thresh1, thresh2, minScale1, minScale2, maxAmbi, threshRansac, minScore, piece_CV);
}

void Wrapper::Interface::Save(System::Drawing::Bitmap^ image)
{
    cv::Mat image_CV = BitmapToMat(image);
    cv::imwrite("c:\\tmp\\piece.jpg", image_CV);
}


System::Drawing::Bitmap^ Wrapper::Interface::MatToBitmap(cv::Mat srcImg) {
    int stride = srcImg.size().width * srcImg.channels();//calc the srtide
    int hDataCount = srcImg.size().height;

    System::Drawing::Bitmap^ retImg;

    System::IntPtr ptr(srcImg.data);

    //create a pointer with Stride
    if (stride % 4 != 0) {//is not stride a multiple of 4?
        //make it a multiple of 4 by fiiling an offset to the end of each row

        //to hold processed data
        uchar* dataPro = new uchar[((srcImg.size().width * srcImg.channels() + 3) & -4) * hDataCount];

        uchar* data = srcImg.ptr();

        //current position on the data array
        int curPosition = 0;
        //current offset
        int curOffset = 0;

        int offsetCounter = 0;

        //itterate through all the bytes on the structure
        for (int r = 0; r < hDataCount; r++) {
            //fill the data
            for (int c = 0; c < stride; c++) {
                curPosition = (r * stride) + c;

                dataPro[curPosition + curOffset] = data[curPosition];
            }

            //reset offset counter
            offsetCounter = stride;

            //fill the offset
            do {
                curOffset += 1;
                dataPro[curPosition + curOffset] = 0;

                offsetCounter += 1;
            } while (offsetCounter % 4 != 0);
        }

        ptr = (System::IntPtr)dataPro;//set the data pointer to new/modified data array

        //calc the stride to nearest number which is a multiply of 4
        stride = (srcImg.size().width * srcImg.channels() + 3) & -4;

        retImg = gcnew System::Drawing::Bitmap(srcImg.size().width, srcImg.size().height,
            stride,
            System::Drawing::Imaging::PixelFormat::Format24bppRgb,
            ptr);
    }
    else {

        //no need to add a padding or recalculate the stride
        retImg = gcnew System::Drawing::Bitmap(srcImg.size().width, srcImg.size().height,
            stride,
            System::Drawing::Imaging::PixelFormat::Format24bppRgb,
            ptr);
    }

    array<unsigned char>^ imageData;
    System::Drawing::Bitmap^ output;

    // Create the byte array.
    {
        System::IO::MemoryStream^ ms = gcnew System::IO::MemoryStream();
        retImg->Save(ms, System::Drawing::Imaging::ImageFormat::Png);
        imageData = ms->ToArray();
        delete ms;
    }

    // Convert back to bitmap
    {
        System::IO::MemoryStream^ ms = gcnew System::IO::MemoryStream(imageData);
        output = (System::Drawing::Bitmap^)System::Drawing::Bitmap::FromStream(ms);
    }

    return output;
}

cv::Mat Wrapper::Interface::BitmapToMat(System::Drawing::Bitmap^ bitmap)
{
    cv::Mat image;

    System::Drawing::Imaging::BitmapData^ bmData = bitmap->LockBits(System::Drawing::Rectangle(0, 0, bitmap->Width, bitmap->Height), System::Drawing::Imaging::ImageLockMode::ReadWrite, bitmap->PixelFormat);
    if (bitmap->PixelFormat == System::Drawing::Imaging::PixelFormat::Format8bppIndexed)
    {
        image = cv::Mat(cv::Size(bitmap->Width, bitmap->Height), CV_8U, bmData->Scan0.ToPointer());
    }

    else if (bitmap->PixelFormat == System::Drawing::Imaging::PixelFormat::Format24bppRgb)
    {
        image = cv::Mat(cv::Size(bitmap->Width, bitmap->Height), CV_8UC3, bmData->Scan0.ToPointer());
    }

    bitmap->UnlockBits(bmData);

    return image;
}
