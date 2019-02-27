using Microsoft.AspNetCore.Mvc;

namespace Core.Common
{
    public class BaseController
    {

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public JsonResult RenderSuccess(object obj)
        {
            Result result = new Result();
            result.SetSuccess(true);
            result.SetObj(obj);
            return null;

        }

    }
}
