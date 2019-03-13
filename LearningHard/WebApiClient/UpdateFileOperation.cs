using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApiClient
{
    class UpdateFileOperation
    {

        public void CreateDir(string folderName)
        {
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
        }

        // 创建md5码存储文件
        public void CreatorMd5(string updatePath, string md5FilePath)
        {
            try
            {
                var path = Path.Combine(updatePath, "VersionsFile");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (!File.Exists(md5FilePath))
                {
                    // updatePath + @"\VersionsFile\md5.txt"
                    using (FileStream fs = new FileStream(md5FilePath, FileMode.CreateNew))
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write("a");  // 这里是写入的内容
                        sw.Flush();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        /// <summary>
        /// 下载版本文件
        /// </summary>
        /// <param name="filepath">下载到指定路径</param>
        /// <returns>下载结果</returns>
        public bool DownloadNew(string urlstr, string filepath, string fileName)
        {
            try
            {
                //string urlstr = ConfigurationManager.AppSettings["accessAddress"] + fileName;
                using (FileStream fs = new FileStream(filepath + fileName, FileMode.Create, FileAccess.Write))
                {
                    Uri url = new Uri(urlstr);
                    HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    myHttpWebRequest.Method = "GET";
                    using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse())
                    {
                        using (Stream receiveStream = myHttpWebResponse.GetResponseStream())
                        {
                            byte[] bytes = new byte[100];
                            int count = receiveStream.Read(bytes, 0, 100);
                            while (count != 0)
                            {
                                fs.Write(bytes, 0, count);
                                count = receiveStream.Read(bytes, 0, 100);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                return false;
            }
        }

        /// <summary>
        /// 根据路径删除文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>是否成功</returns>
        public bool DeleteFile(string path)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                if (attr == FileAttributes.Directory)
                {
                    Directory.Delete(path, true);
                }
                else
                {
                    File.Delete(path);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // 清空指定的文件夹，但不删除文件夹
        public void DeleteFolder(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }

                    File.Delete(d); // 直接删除其中的文件
                }
                else
                {
                    DirectoryInfo d1 = new DirectoryInfo(d);
                    if (d1.GetFiles().Length != 0)
                    {
                        DeleteFolder(d1.FullName);////递归删除子文件夹
                    }
                    Directory.Delete(d);
                }
            }
        }

        /// <summary>
        /// 获取文件的MD5码
        /// </summary>
        /// <param name="fileName">传入的文件名（含路径及后缀名）</param>
        /// <returns>返回MD5</returns>
        public string GetMD5Hash(string fileName)
        {
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open))
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] retVal = md5.ComputeHash(file);
                    file.Close();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < retVal.Length; i++)
                    {
                        sb.Append(retVal[i].ToString("x2"));
                    }

                    return sb.ToString();
                }
            }
            catch (Exception)
            {
                // 如果发生异常，返回一个错误的MD5码
                return "0";
            }
        }

        // 读取txt文件内容
        public string FileToString(string filePath)
        {
            string strData = string.Empty;
            try
            {
                string line;

                // 创建一个 StreamReader 的实例来读取文件 ,using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // 从文件读取并显示行，直到文件的末尾
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Console.WriteLine(line);
                        strData = line;
                    }
                }
            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return strData;
        }

        // 读取xml 文件
        // 返回name,fileName 格式信息
        public string ReadVersion(string filePath, string rootName)
        {
            string version = string.Empty;
            try
            {
                // 将XML文件加载进来
                XDocument document = XDocument.Load(filePath);
                // 获取到XML的根元素进行操作
                XElement root = document.Root;
                // XElement ele = root.Element("version");
                XElement el = root.Element(rootName);
                // 获取name标签的值
                version = el.Value;
                version += "," + el.LastAttribute.Value;

                return version;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 解压功能(解压压缩文件到指定目录)
        /// </summary>
        /// <param name="fileToUnZip">待解压的文件</param>
        /// <param name="zipedFolder">指定解压目标目录</param>
        /// <returns>解压结果</returns>
        public bool UnZip(string fileToUnZip, string zipedFolder)
        {
            bool result = true;
            FileStream fs = null;
            ZipInputStream zipStream = null;
            ZipEntry ent = null;
            string fileName;

            if (!File.Exists(fileToUnZip))
            {
                return false;
            }

            if (!Directory.Exists(zipedFolder))
            {
                Directory.CreateDirectory(zipedFolder);
            }

            try
            {
                zipStream = new ZipInputStream(File.OpenRead(fileToUnZip));
                while ((ent = zipStream.GetNextEntry()) != null)
                {
                    if (!string.IsNullOrEmpty(ent.Name))
                    {
                        fileName = Path.Combine(zipedFolder, ent.Name);
                        fileName = fileName.Replace('/', '\\');

                        if (fileName.EndsWith("\\"))
                        {
                            Directory.CreateDirectory(fileName);
                            continue;
                        }

                        fs = File.Create(fileName);
                        int size = 2048;
                        byte[] data = new byte[size];
                        while (true)
                        {
                            size = zipStream.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                fs.Write(data, 0, data.Length);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
                result = false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }

                if (zipStream != null)
                {
                    zipStream.Close();
                    zipStream.Dispose();
                }

                if (ent != null)
                {
                    ent = null;
                }

                GC.Collect();
                GC.Collect(1);
            }

            return result;
        }

        // TXT文件写入
        public bool TxtWrite(string filePath, string text)
        {
            try
            {
                // 判断文件是否存在，没有则创建。
                if (!File.Exists(filePath))
                {
                    FileStream stream = File.Create(filePath);
                    stream.Close();
                    stream.Dispose();
                }

                // 写入日志
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine(text);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
