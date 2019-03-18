using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace WebApiClient
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

        public delegate void Entrust(string str);//委托   
        private delegate void SetPos(int ipos, string vinfo);//代理

        UpdateFileOperation fileOperations = new UpdateFileOperation();



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            // 解压
            string path1 = @"D:\a\FSBox.zip";
            string path2 = @"D:\";
            var a = fileOperations.UnZip(path1, path2);

        }


        private void PostFile()
        {
            string filePath = "‪D:\a.png";
            Uri url = new Uri("http://localhost:5000/api/fsapi/file/upload/multi");
            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddFile("file", filePath);
            IRestResponse response = client.Execute(request);
           
            int ceshistatucode = (int)response.StatusCode;


        }


        public bool Push(string Newfilepath)
        {
          
            var client = new RestClient("http://localhost:5000/api/fsapi/file/upload/multi");
            var request = new RestRequest(Method.POST);
            request.AddFile("file", Newfilepath);
           
            IRestResponse response = client.Execute(request);
            int ceshistatucode = (int)response.StatusCode;
            if ((int)response.StatusCode == 204)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Entrust callback = new Entrust(CallBack); //把方法赋值给委托
            Thread fThread = new Thread(update);
            fThread.Start(callback);//将委托传递到子线程中      



        }
        private void update(object obj)
        {

        }
        //子线程结束后，执行的方法
        private void CallBack(string str)
        {
            //子线程结束后，执行的方法      

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Push(@"C:\Users\Lenovo\Desktop\c.txt");
        }
    }
}
