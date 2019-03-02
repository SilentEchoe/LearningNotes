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

            //Bitmap bitmap = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            //Graphics graphics = Graphics.FromImage(bitmap);
            //graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));

            string base64 = "EcwMgAAAAAAAAAAD/wIAIwAAMgBPRU0gICAgICAgICAgICAgBwAAAFRSLUZDODVTLU5CSyAgICAxQUJoB9BGJwIA/9YxMDBHU1I0ICAgICAgICAgMTUxMDExICAMAAAdNzQwLTA2MTQwNSBSRVYgMDFBUEYwNzI3NTQzMDEwNP8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////";


            string base65 = "EcwMgAAAAAAAAAAD/wIAIwAAMgBPRU0gICAgICAgICAgICAgBwAAAFRSLUZDODVTLU5CSyAgICAxQUJoB9BGJwIA/9YxMDBHU1I0ICAgICAgICAgMTUxMDExICAMAAAdNzQwLTA2MTQwNSBSRVYgMDFBUEYwNzI3NTQzMDEwNP8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////";
            if (base64== base65)
            {
                MessageBox.Show("a");
            }


           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
