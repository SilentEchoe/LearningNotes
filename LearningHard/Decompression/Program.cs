using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Decompression
{
    class Program
    {
        static void Main(string[] args)
        {
          var a = UnZip(@"D:\FS_Feedback.zip", @"D:\CESHI\");
        }


        /// <summary>
        /// 解压功能(解压压缩文件到指定目录)
        /// </summary>
        /// <param name="fileToUnZip">待解压的文件</param>
        /// <param name="zipedFolder">指定解压目标目录</param>
        /// <returns>解压结果</returns>
        public static bool UnZip(string fileToUnZip, string zipedFolder)
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



    }
}
