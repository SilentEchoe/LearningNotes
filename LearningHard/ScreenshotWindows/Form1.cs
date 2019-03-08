using CSharpWin_JD.CaptureImage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CaptureImageTool capture = new CaptureImageTool();
            if (capture.ShowDialog() == DialogResult.OK)
            {
                Image image = capture.Image;
                //pictureBox1.Width = image.Width;
                //pictureBox1.Height = image.Height;
                //pictureBox1.Image = image;
            }

            //Bitmap bitmap = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            //Graphics graphics = Graphics.FromImage(bitmap);
            //graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));




        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
