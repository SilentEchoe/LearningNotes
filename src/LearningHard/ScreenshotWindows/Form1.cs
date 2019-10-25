using System;
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
           
            //Bitmap bitmap = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            //Graphics graphics = Graphics.FromImage(bitmap);
            //graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));




        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
