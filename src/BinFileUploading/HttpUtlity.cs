using Newtonsoft.Json;
using RestSharp;
using System;

namespace BinFileUploading
{
    public class HttpUtlity
    {
        public bool HttpFileUpload(string fileName) 
        {
            // 请求上传接口
            Uri url = new Uri("http://54.245.72.232:5008/UploadBinFile");
            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddFile("file", fileName);
            var response = client.Execute(request);
           
            // 判断返回值是否为200
            if ((int)response.StatusCode==200)
            {
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(response.Content);
                bool code = (bool)dynamicObject.success;
                return code;
            }
            else
            {
                return false;
            }
        }

        public bool HttpGetLog()
        {
            // 请求上传接口
            Uri url = new Uri("http://54.245.72.232:5008/GetLogInfo");
            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            // 判断返回值是否为200
            if ((int)response.StatusCode == 200)
            {
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(response.Content);
                bool code = (bool)dynamicObject.success;
                return code;
            }
            else
            {
                return false;
            }
        }


    }
}
