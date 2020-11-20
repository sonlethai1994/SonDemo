using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
            wrapperCPP = new Interface();
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

            if(!valid)
            {
                MessageBox.Show(LOG);
                return;
            }

            imagePuzzleLocation.SizeMode = PictureBoxSizeMode.StretchImage;
            imagePuzzleLocation.Image = Image.FromFile(file[0]);

        }

        private void SplitButton_Click(object sender, EventArgs e)
        {
            // check if image is upload or not 
            if(imagePuzzleLocation.Image != null)
            {
                wrapperCPP.SplitImageIntoPieces();
            }
            else
            {
                MessageBox.Show("Please load a valid image.");
            }
        }
    }
}
