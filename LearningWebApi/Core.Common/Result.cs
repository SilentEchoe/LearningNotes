using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public class Result
    {
        public static int SUCCESS = 1;
        public static int FAILURE = -1;
        public static int OTHER = 2;      //其他，页面显示
        public static int FAILURE_AUTHC = -9999;

        public static string STR_PARAM_NOT_NULL = "传入参数不能为空";
        public static string STR_SUCCESS = "操作成功";
        public static string STR_FAIL = "操作失败";


        /**
         * 请求是否错误，默认false
         */
        public Boolean success = false;
        /**
         * 请求返回code
         */
        public int code = SUCCESS;
        /**
         * 请求返回描述
         */
        public string msg = "";

        public Object obj = null;

        public Result() { }

        public Result(int code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }
        public Result(int code, string msg, Boolean success)
        {
            this.code = code;
            this.msg = msg;
            this.success = success;
        }

        public Boolean isSuccess()
        {
            return success;
        }

        public void setSuccess(Boolean success)
        {
            this.success = success;
        }

        public string getMsg()
        {
            return msg;
        }

        public void setMsg(string msg)
        {
            this.msg = msg;
        }

        public Object getObj()
        {
            return obj;
        }

        public void setObj(Object obj)
        {
            this.obj = obj;
        }

        public int getCode()
        {
            return code;
        }

        public void setCode(int code)
        {
            this.code = code;
        }
    }
}
