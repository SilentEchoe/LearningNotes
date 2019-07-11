using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Addcompatibility();
            Console.ReadKey();
        }

        static string binFilePath = @"C:\Users\Lenovo\Desktop\脚本\云端中性码\";


        public static void Addcompatibility()
        {
            // 获取数据库型号名
            var modelLits = GetModelLists();

            var list = OpenExcel2(@"C:\Users\Lenovo\Desktop\脚本\Generic.xls");

            foreach (var item in list)
            {
                string key = string.Empty;

                //string binPath = binFilePath + item.Base64;
                //Console.WriteLine(BinToBase64(binPath));
                var modalid = modelLits.Where(p => p.modal_name == item.Modelname).FirstOrDefault();


             

                Console.WriteLine(item.Modelname +":"+ key);



            }








        }

        public static string BinToBase64(string binPath)
        {
            using (FileStream fs = new FileStream(binPath, FileMode.OpenOrCreate))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                return Convert.ToBase64String(buffer);
            }
        }


        public void AddModelName()
        {
            int sum = 0;
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

        public static string attrKey(string value1,string value2,string attrValue)
        {
            
            string key = string.Empty;
            if (value1 != "0")
            {
                key += "1,";
                attrValue = value1;
            }
            else
            {
                key += "0,";
            }
            if (value2 != "0")
            {
                key += "2";
                attrValue = value1;
            }
            else
            {
                key += "0";
            }

            return key;

        }



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


                //取得数据范围区域 (不包括标题列) 
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

                // Bin文件
                Range rng4 = ws.Cells.get_Range("F2", "F" + rowsint);





                object[,] arryItem = (object[,])rng1.Value2;   //get range's value
                object[,] arryItem2 = (object[,])rng2.Value2;

                object[,] arryItem3 = (object[,])rng3.Value2;   //get range's value

                object[,] arryItem4 = (object[,])rng4.Value2;

                //将新值赋给一个数组
                string[,] arry = new string[rowsint - 1, 2];
                for (int i = 1; i <= rowsint - 1; i++)
                {
                    model2 model = new model2();
                    model.Modelname = arryItem[i, 1].ToString();
                    model.Value1 = arryItem2[i, 1].ToString();
                    model.Value2 = arryItem3[i, 1].ToString();
                    model.Base64 = arryItem4[i, 1].ToString() + ".bin";

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
