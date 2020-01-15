using System;
using System.IO;
using System.Windows;

namespace BinFileUploading
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpUtlity httpUtlity = new HttpUtlity();
        FileUtility fileUtility = new FileUtility();
        // 获取程序所在路径
        readonly string BinPath = AppDomain.CurrentDomain.BaseDirectory;

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();
        public MainWindow()
        {
            InitializeComponent();
            #region 定义定时器
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1, 0);
            #endregion
        }

        private void Btn_Upload_Click(object sender, RoutedEventArgs e)
        {
            UploadBin();
        }


        private void Btn_selectPath_Click(object sender, RoutedEventArgs e)
        {
            folder.ShowDialog();//打开文件夹会话

            this.BinFilePath.Content = folder.SelectedPath;
            //BinFilePath = folder.SelectedPath;//获取文件夹路径

        }

        // 定时器触发的事件
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            UploadBin();
        }

        private void UploadBin()
        {

            int Count = 0;
            // 选择Bin文件文件夹
            string Path = this.BinFilePath.Content.ToString();

            // 获取文件夹名
            string[] folders = Directory.GetDirectories(Path);
            

            foreach (var item in folders)
            {
                // 获取文件
                string[] files = Directory.GetFiles(item);
                foreach (var bins in files)
                {

                    if (File.Exists(bins))//必须判断要复制的文件是否存在
                    {
                        string filename = System.IO.Path.GetFileName(bins);

                        //三个参数分别是源文件路径，存储路径，若存储路径有相同文件是否替换
                        File.Copy(bins, BinPath + @"BinFile\" + filename, true);
                    }
                }
                Guid g = Guid.NewGuid();

                string zipPath = BinPath + g.ToString() + ".zip";
                // 压缩文件夹
                ZipHelper.CreateZip(BinPath + "BinFile", zipPath);
                // 将zip 上传到服务器上
                if (httpUtlity.HttpFileUpload(zipPath))
                {
                    Count++;
                    // 清理已上传的BIN文件
                    fileUtility.DeleteFolder(BinPath + "BinFile");
                }
                else
                {

                    break;
                }
            }

            if (folders.Length == Count)
            {
                MessageBox.Show("上传成功");
            }
            else
            {
                MessageBox.Show("实际上传Bin文件数量：" + Count);
            }


        }


    }
}
