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
            Uri url = new Uri("http://localhost:7934/images/Upload/Pic");
            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddFile("file", fileName);
            var response = client.Execute(request);
            return true;
        }


    }
}
