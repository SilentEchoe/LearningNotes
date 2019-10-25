using SharpCompress.Archives;
using SharpCompress.Common;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            var archive = ArchiveFactory.Open(@"D:\a.zip");

            foreach (var entry in archive.Entries)
            {
                if (!entry.IsDirectory)
                {

                    entry.WriteToDirectory(@"D:\a\", new ExtractionOptions { ExtractFullPath = true, Overwrite = true });
                }
            }




        }


        public void a()
        {
        
            var archive = ArchiveFactory.Open(@"D:\a.zip");
          
            foreach (var entry in archive.Entries)
            {
                if (!entry.IsDirectory)
                {
                   
                    entry.WriteToDirectory(@"D:\a\", new ExtractionOptions { ExtractFullPath = true, Overwrite = true });
                }
            }
        }


    }
}
