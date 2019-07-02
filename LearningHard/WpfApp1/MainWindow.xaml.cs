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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        System.Windows.Threading.DispatcherTimer IsClose = new System.Windows.Threading.DispatcherTimer();

        private int a = 0;
        private int b = 0;
        public MainWindow()
        {
            InitializeComponent();

            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);

            IsClose.Tick += Close_Tick;
            IsClose.Interval = new TimeSpan(0, 0, 0, 1);
            IsClose.Start();
            dispatcherTimer.Start();
        }


        private void Close_Tick(object sender, EventArgs e)
        {
            a++;
            this.Label.Content = a.ToString();

        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            b++;
            this.Label1.Content = b.ToString();


        }
    }
}
