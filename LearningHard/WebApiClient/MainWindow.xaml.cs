using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

      

    

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            Uri url = new Uri("");
            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddFile("file", "");
            request.AddHeader("ACCESS-TOKEN", "");
            request.AddParameter("","");
            IRestResponse response = client.Execute(request);

        }
    }
}
