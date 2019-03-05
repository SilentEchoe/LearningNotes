using CSharpWin_JD.CaptureImage;
using System.Windows;
using System.Windows.Controls;

namespace Screenshot
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Screenshot(object sender, RoutedEventArgs e)
        {
            CaptureImageTool capture = new CaptureImageTool();
            if (capture.ShowDialog() == DialogResult)
            {
                Image image = capture.Image;
                pictureBox1.Width = image.Width;
                pictureBox1.Height = image.Height;
                pictureBox1.Image = image;
            }
        }
    }
}
