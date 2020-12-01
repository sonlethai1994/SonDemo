using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Wrapper;

namespace WindowFormApp
{
    public partial class Form1 : Form
    {
        Interface wrapperCPP;
        Bitmap[] puzzlePieces;
        List<int> PositionPowerOf2 = new List<int>();
        
        public Form1()
        {
            InitializeComponent();
            wrapperCPP = new Interface();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void imagePuzzleLocation_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void imagePuzzleLocation_DragDrop(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
            // send image to C++ --> if jpg --> copy image to imagePuzzleLocation
            string LOG = "";
            bool valid = wrapperCPP.CheckInputFile(file[0], ref LOG);

            if (!valid)
            {
                MessageBox.Show(LOG);
                return;
            }

            imagePuzzleLocation.SizeMode = PictureBoxSizeMode.StretchImage;
            imagePuzzleLocation.Image = Image.FromFile(file[0]);
        }

        public bool ThumbnailCallback()
        {
            return true;
        }

        private void SplitButton_Click(object sender, EventArgs e)
        {
            // check if image is upload or not 
            if(imagePuzzleLocation.Image != null){
                int nbLoopUI = (int)nbLoopVal.Value;
                int NsuperPixelUI = (int)NsuperPixeVal.Value;
                float weightRatioUI = (float)weightRatioVal.Value;
                int Npieces = wrapperCPP.SplitImageIntoPieces(NsuperPixelUI, weightRatioUI, nbLoopUI);

                puzzlePieces = new Bitmap[Npieces];
                for (int i = 0; i < Npieces; i++){

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Click += new System.EventHandler(selectImage);

                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    puzzlePieces[i] = wrapperCPP.GetPiecePuzzle(i);
                    pictureBox.Image = puzzlePieces[i];
                    pictureBox.Refresh();
                    vignettePanel.Controls.Add(pictureBox);
                }
            }
            else
            {
                MessageBox.Show("Please load a valid image.");
            }
        }

        private void selectImage(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            pictureBox1.Image = temp.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float thresh1Val = (float)thresh1.Value;
            float thresh2Val = (float) thresh2.Value;
            float minScale1Val = (float) minScale1.Value;
            float minScale2Val = (float) minScale2.Value;
            float maxAmbiVal = (float) maxAmbi.Value;
            float threshRansacVal = (float) threshRansac.Value;
            float minScoreVal = (float) minScore.Value;
            wrapperCPP.matchPiecePuzzle(thresh1Val, thresh2Val, minScale1Val, minScale2Val, maxAmbiVal, threshRansacVal, minScoreVal, (Bitmap)pictureBox1.Image);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap img = (Bitmap)pictureBox1.Image;
            wrapperCPP.Save(img);
        }

        
    }
}
