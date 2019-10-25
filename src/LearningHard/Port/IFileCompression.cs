using System;
using System.Collections.Generic;
using System.Text;

namespace Port
{
    /// <summary>
    /// 定义压缩接口
    /// </summary>
    interface IFileCompression
    {
        void Compress(string targetFileName, string[] fileList);

        void Uncompress(string compressedFileName, string expadDirectoryName);

    }
}
