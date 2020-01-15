using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BinFileUploading
{
    public class HttpUtlity
    {
        public bool HttpFileUpload(string fileName) 
        {
            Uri url = new Uri("http://54.245.72.232:5008/UploadBinFile");
            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddFile("file", fileName);
            var response = client.Execute(request);
            return true;
        }


    }
}
