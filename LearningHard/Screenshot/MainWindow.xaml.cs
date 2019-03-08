using RisCaptureLib;
using System;
using System.Threading;
using System.Windows;

namespace Screenshot
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RisCaptureLib.ScreenCaputre screenCaputre = new RisCaptureLib.ScreenCaputre();
        private Size? lastSize;

        public MainWindow()
        {
            InitializeComponent();
            screenCaputre.ScreenCaputred += OnScreenCaputred;
            screenCaputre.ScreenCaputreCancelled += OnScreenCaputreCancelled;
        }

        private void OnScreenCaputreCancelled(object sender, EventArgs e)
        {
            Show();
            Focus();
        }

        private void OnScreenCaputred(object sender, ScreenCaputredEventArgs e)
        {
            //set last size
            lastSize = new Size(e.Bmp.Width, e.Bmp.Height);
            Show();
            //test
            var bmp = e.Bmp;
            Clipboard.SetImage(e.Bmp);
        }

        private void OnScreenCapturedBitmap(object sender, ScreenCaputredBitmapEventArgs e)
        {
            System.Drawing.Bitmap bitmap = e.bBitMap;
        }
        private void Btn_Screenshot(object sender, RoutedEventArgs e)
        {
            Hide();
            Thread.Sleep(300);
            screenCaputre.StartCaputre(30, lastSize);
        }
    }
}
