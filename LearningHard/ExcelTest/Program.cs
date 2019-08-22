using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //AddModelName();

    
            Addcompatibility();


            Console.WriteLine("完成");
            Console.ReadLine();
        }

        static string binFilePath = @"C:\Users\Lenovo\Desktop\脚本\ME编码-BOX\";

        // 添加新兼容品牌
        public static void Addcompatibility()
        {
            // 获取数据库型号名
            var modelLits = GetModelLists();

            // 获取xls数据
            var list = OpenExcel2(@"C:\Users\Lenovo\Desktop\脚本\ME编码表.xls");

            foreach (var item in list)
            {
               
                //解析 attry_key 和 attry_value
                var attry = attrKey(item);
                string base64 = string.Empty;
                var modalid = modelLits.Where(p => p.modal_name == item.Modelname).FirstOrDefault();
                // 判断数量 如果数量是1 则为模板. 大于1则为bin文件

                if (item.Sum=="1")
                {
                    // 上传bin模板

                    if (item.Base64!="")
                    {
                        string binPath = binFilePath + item.Base64 + ".bin";
                        base64 = BinToBase64(binPath);
                    }                
                    var isAdd = HttpClientDoPost(modalid.id.ToString(), attry[0], attry[1], base64,"0");
                    isAdd.Wait();
                    if (!isAdd.Result)
                    {
                        Console.WriteLine($"型号名：{item.Modelname},attr_key:{attry[0]},attr_value:{attry[1]}");
                    }
                }
                else
                {
                    // 上传bin文件
                    var isAdd = HttpClientDoPost(modalid.id.ToString(), attry[0], attry[1],base64,"1");
                    isAdd.Wait();
                    if (!isAdd.Result)
                    {
                        Console.WriteLine($"型号名：{item.Modelname},attr_key:{attry[0]},attr_value:{attry [1]}");

                        // 如果添加成功
                        //string id = GetModelTypeId(modalid.id.ToString(), "Mellanox", attry[0], attry[1]);
                        //string[] modelID = null;
                        //if (id!="")
                        //{
                        //     modelID = id.Split(',');
                        //}                
                        //DirectoryInfo folder = new DirectoryInfo(binFilePath + item.Base64);
                        //foreach (FileInfo file in folder.GetFiles("*.bin"))
                        //{   
                        //    base64 = BinToBase64(file.FullName);
                        //    if (!AddCompatibleByBase64(file.Name, int.Parse(modelID[0]), int.Parse(modelID[1]), base64))
                        //    {
                        //        Console.WriteLine($"型号名：{item.Modelname},attr_key:{attry[0]},attr_value:{attry[1]}");
                        //    };
                        //}
                    }
                   

                }
            }
        }



        private bool addBins(string fileName, int modelbintypeid, int modelbinattrid, string base64)
        {
          return  AddCompatibleByBase64(fileName, modelbintypeid, modelbinattrid, base64);
        }


        // 将文件转换成base64
        public static string BinToBase64(string binPath)
        {
            try
            {
                using (FileStream fs = new FileStream(binPath, FileMode.OpenOrCreate))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    return Convert.ToBase64String(buffer);
                }
            }
            catch (Exception)
            {

                return "";
            }

        }

        // 添加型号名
        public static void AddModelName()
        {
            int sum = 0;

            var lists = GetModelLists();
            var models = OpenExcel(@"C:\Users\Lenovo\Desktop\WDM模块新旧型号名的关联.xlsx");

            foreach (var item in models)
            {
                var oldmodalid = lists.Where(p => p.modal_name == item.oldModel).FirstOrDefault();

                if (addModelName(item.newModel, oldmodalid.id))
                {
                    sum++;
                }
                else
                {
                    Console.WriteLine(item.newModel + "," + oldmodalid.id);
                }



            }
            Console.ReadKey();
        }

        // 添加兼容品牌的请求
        static bool AddCompatibility(int modaleId, string attrKey, string attrValue, string binBase64)
        {
            Uri url = new Uri("http://localhost:5000/api/fsapi/Test/AddCompatible");

            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("modaleId", modaleId);
            request.AddParameter("attrKey", attrKey);
            request.AddParameter("attrValue", attrValue);
            request.AddParameter("binBase64", binBase64);
            var response = client.Execute(request);
            var ceshistatucode = (int)response.StatusCode;

            if (ceshistatucode != 200)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        static async Task<bool> HttpClientDoPost(string modaleId, string attrKey, string attrValue, string binBase64,string isBin)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var values = new List<KeyValuePair<string, string>>();
                    values.Add(new KeyValuePair<string, string>("modaleId", modaleId));
                    values.Add(new KeyValuePair<string, string>("attrKey", attrKey));
                    values.Add(new KeyValuePair<string, string>("attrValue", attrValue));
                    values.Add(new KeyValuePair<string, string>("binBase64", binBase64));
                    values.Add(new KeyValuePair<string, string>("isBin", isBin));
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("http://localhost:5000/api/fsapi/Test/AddCompatible", content);

                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject obj = (JObject)JsonConvert.DeserializeObject(responseString);
                    if (obj["success"].ToString() == "True")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            catch (Exception)
            {

                return false;
            }
        }


        static string GetModelTypeId(string modalId, string compatibleTpe, string attrKey, string attrValue)
        {
            Uri url = new Uri("http://localhost:5000/api/fsapi/Test/GetModalTypeId");

            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("modalId", modalId);
            request.AddParameter("compatibleTpe", compatibleTpe);
            request.AddParameter("attrKey", attrKey);
            request.AddParameter("attrValue", attrValue);
            var response = client.Execute(request);
            var ceshistatucode = (int)response.StatusCode;

            if (ceshistatucode != 200)
            {
                return "";
            }
            else
            {
                JObject obj = (JObject)JsonConvert.DeserializeObject(response.Content);
                return obj["msg"].ToString();
            }


        }

        static bool AddCompatibleByBase64(string fileName, int modelbintypeid, int modelbinattrid, string base64)
        {
            Uri url = new Uri("http://localhost:5000/api/fsapi/Test/AddCompatibleByBase64");

            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("fileName", fileName);
            request.AddParameter("modelbintypeid", modelbintypeid);
            request.AddParameter("modelbinattrid", modelbinattrid);
            request.AddParameter("base64", base64);
            var response = client.Execute(request);
            var ceshistatucode = (int)response.StatusCode;

            if (ceshistatucode != 200)
            {
                return false;
            }
            else
            {
                return true;
            }


        }



        //解析属性
        public static string[] attrKey(model2 model)
        {
            string attr_key = string.Empty;
            string attr_value = string.Empty;
            if (model.Value1 != "0")
            {
                attr_key += "1,";
                attr_value += model.Value1 + ",";
            }
            if (model.Value2 != "0")
            {
                attr_key += "2,";
                attr_value += model.Value2 + ",";
            }
            if (model.Value3 != "0")
            {
                attr_key += "3,";
                attr_value += model.Value3 + ",";
            }
            if (model.Value4 != "0")
            {
                attr_key += "4,";
                attr_value += model.Value4 + ",";
            }
            if (model.Value5 != "0")
            {
                attr_key += "5,";
                attr_value += model.Value5 + ",";
            }
            if (model.Value6 != "0")
            {
                attr_key += "6,";
                attr_value += model.Value6 + ",";
            }

            if (attr_key == "")
            {
                attr_key = "0,0";
                attr_value = "0,0";
            }



            string[] attr_keya = attr_key.Split(',');
            if (attr_keya.Length == 2 && attr_keya[1] == "")
            {
                attr_key += "0";
                attr_value += "0";
            }
            if (attr_keya.Length == 3)
            {
                attr_key = attr_key.Substring(0, attr_key.Length - 1);
                attr_value = attr_value.Substring(0, attr_value.Length - 1);
            }


            string[] attry = new string[2] { attr_key, attr_value };

            return attry;

        }


        // 获取数据库型号名列表

        public static List<modelList> GetModelLists()
        {
            var jsonTxt = GetModel();
            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(jsonTxt)["obj"];

            List<modelList> lists = new List<modelList>();


            var mJObj = JArray.Parse(dynamicObject.ToString());

            foreach (var item in mJObj)
            {
                modelList model = new modelList();
                model.id = item["id"];
                model.modal_name = item["modalName"];
                lists.Add(model);

            }

            return lists;
        }


        // 请求接口
        public static string GetModel()
        {
            Uri url = new Uri("http://54.245.72.232/api/fsapi/model/findListConfModalName");

            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);

            var response = client.Execute(request);


            var ceshistatucode = (int)response.StatusCode;

            if (ceshistatucode == 200)
            {
                return response.Content;
            }
            return null;
        }

        // 添加型号名
        public static bool addModelName(string modalName, int ParentId)
        {
            Uri url = new Uri("http://localhost:5000/api/model/SaveWDMmodalName");

            var client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("modalName", modalName);
            request.AddParameter("ParentId", ParentId);

            var response = client.Execute(request);
            var ceshistatucode = (int)response.StatusCode;

            if (ceshistatucode != 200)
                return false;
            return true;
        }



        //读取EXCEL的方法   (用范围区域读取数据)
        private static List<model> OpenExcel(string strFileName)
        {

            List<model> modelsList = new List<model>();


            object missing = System.Reflection.Missing.Value;
            Application excel = new Application();//lauch excel application
            if (excel == null)
            {
                Console.WriteLine("空");
            }
            else
            {
                excel.Visible = false; excel.UserControl = true;
                // 以只读的形式打开EXCEL文件
                Workbook wb = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
                 missing, missing, missing, true, missing, missing, missing, missing, missing);
                //取得第一个工作薄
                Worksheet ws = (Worksheet)wb.Worksheets.get_Item(1);


                //取得总记录行数   (包括标题列)
                int rowsint = ws.UsedRange.Cells.Rows.Count; //得到行数
                                                             //int columnsint = mySheet.UsedRange.Cells.Columns.Count;//得到列数


                //型号名
                Range rng1 = ws.Cells.get_Range("A2", "A" + rowsint);   //item


                Range rng2 = ws.Cells.get_Range("D2", "D" + rowsint); //Customer
                object[,] arryItem = (object[,])rng1.Value2;   //get range's value
                object[,] arryCus = (object[,])rng2.Value2;
                //将新值赋给一个数组
                string[,] arry = new string[rowsint - 1, 2];
                for (int i = 1; i <= rowsint - 1; i++)
                {


                    model model = new model();
                    model.oldModel = arryItem[i, 1].ToString();
                    model.newModel = arryCus[i, 1].ToString();

                    modelsList.Add(model);

                    //Item_Code列
                    arry[i - 1, 0] = arryItem[i, 1].ToString();
                    //Customer_Name列
                    arry[i - 1, 1] = arryCus[i, 1].ToString();
                }




            }
            excel.Quit(); excel = null;
            Process[] procs = Process.GetProcessesByName("excel");


            foreach (Process pro in procs)
            {
                pro.Kill();//没有更好的方法,只有杀掉进程
            }
            GC.Collect();



            return modelsList;

        }



        //读取EXCEL的方法2 用于新增兼容品牌
        private static List<model2> OpenExcel2(string strFileName)
        {

            List<model2> modelsList = new List<model2>();


            object missing = System.Reflection.Missing.Value;
            Application excel = new Application();//lauch excel application
            if (excel == null)
            {
                Console.WriteLine("空");
            }
            else
            {
                excel.Visible = false; excel.UserControl = true;
                // 以只读的形式打开EXCEL文件
                Workbook wb = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
                 missing, missing, missing, true, missing, missing, missing, missing, missing);
                //取得第一个工作薄
                Worksheet ws = (Worksheet)wb.Worksheets.get_Item(1);

                //取得总记录行数   (包括标题列)
                int rowsint = ws.UsedRange.Cells.Rows.Count; //得到行数
                                                             //int columnsint = mySheet.UsedRange.Cells.Columns.Count;//得到列数
                //取得数据范围区域 (不包括标题列) 
                // 型号名
                Range rng1 = ws.Cells.get_Range("A2", "A" + rowsint);   //item

                // 属性一

                Range rng2 = ws.Cells.get_Range("B2", "B" + rowsint);

                // 属性二
                Range rng3 = ws.Cells.get_Range("C2", "C" + rowsint);

                // 属性三
                Range rng4 = ws.Cells.get_Range("D2", "D" + rowsint);

                // 属性四
                Range rng5 = ws.Cells.get_Range("E2", "E" + rowsint);

                // 属性五
                Range rng6 = ws.Cells.get_Range("F2", "F" + rowsint);


                // 属性六
                Range rng7 = ws.Cells.get_Range("G2", "G" + rowsint);

                // bin文件
                Range rng8 = ws.Cells.get_Range("J2", "J" + rowsint);

                Range Sum = ws.Cells.get_Range("K2", "K" + rowsint);


                // 型号名
                object[,] arryItem = (object[,])rng1.Value2;


                object[,] arryItem1 = (object[,])rng2.Value2;

                object[,] arryItem2 = (object[,])rng3.Value2;   //get range's value

                object[,] arryItem3 = (object[,])rng4.Value2;


                object[,] arryItem4 = (object[,])rng5.Value2;
                object[,] arryItem5 = (object[,])rng6.Value2;
                object[,] arryItem6 = (object[,])rng7.Value2;
                object[,] arryItem7 = (object[,])rng8.Value2;

                object[,] arryItem8 = (object[,])Sum.Value2;



                //将新值赋给一个数组
                string[,] arry = new string[rowsint - 1, 2];
                for (int i = 1; i <= rowsint - 1; i++)
                {
                    model2 model = new model2();
                    model.Modelname = arryItem[i, 1].ToString();
                    model.Value1 = arryItem1[i, 1].ToString();
                    model.Value2 = arryItem2[i, 1].ToString();

                    model.Value3 = arryItem3[i, 1].ToString();

                    model.Value4 = arryItem4[i, 1].ToString();

                    model.Value5 = arryItem5[i, 1].ToString();
                    model.Value6 = arryItem6[i, 1].ToString();

                    if (arryItem7[i, 1]==null)                   
                        model.Base64 = "";              
                    else              
                        model.Base64 = arryItem7[i, 1].ToString();

                    if (arryItem8[i, 1] == null)
                        model.Sum = "";
                    else
                        model.Sum = arryItem8[i, 1].ToString();

                    modelsList.Add(model);

                }




            }
            excel.Quit(); excel = null;
            Process[] procs = Process.GetProcessesByName("excel");


            foreach (Process pro in procs)
            {
                pro.Kill();//没有更好的方法,只有杀掉进程
            }
            GC.Collect();



            return modelsList;

        }

    }
}
