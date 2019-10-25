using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage image = new BitmapImage();
        BitmapImage image2 = new BitmapImage();
        int a = 0;
        public MainWindow()
        {

           
            image.BeginInit();
            image.UriSource = new Uri(@"C:\Users\Lenovo\Desktop\status1.gif");
            image.EndInit();
            
            image2.BeginInit();
            image2.UriSource = new Uri(@"C:\Users\Lenovo\Desktop\status2.gif");
            image2.EndInit();


            
          


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (a==0)
            {
                ImageBehavior.SetAnimatedSource(img, image2);
                a = 1;
            }
            else
            {
                ImageBehavior.SetAnimatedSource(img, image);
                a = 0;
            }
        }
    }
}
