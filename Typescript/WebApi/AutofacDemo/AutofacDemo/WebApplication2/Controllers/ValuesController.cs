using System.Collections.Generic;
using System.Linq;
using EasyOffice.Enums;
using EasyOffice.Interfaces;
using EasyOffice.Models.Excel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        private readonly IExcelImportService _excelImportService;
        public ValuesController()
        {
            _excelImportService = _excelImportService;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            var _rows = _excelImportService.ValidateAsync<ExcelCarTemplateDTO>(new ImportOption()
            {
                FileUrl = @"C:\Users\Lenovo\Desktop\WDM模块新旧型号名的关联.xlsx", //Excel文件绝对地址
                DataRowStartIndex = 0, //数据起始行索引，默认1第二行
                HeaderRowIndex = 0,  //表头起始行索引，默认0第一行
                MappingDictionary = null, //映射字典，可以将模板类与Excel列重新映射， 默认null
                SheetIndex = 0, //页面索引，默认0第一个页签
                ValidateMode = ValidateModeEnum.Continue //校验模式，默认StopOnFirstFailure校验错误后此行停止继续校验，Continue：校验错误后继续校验
            }).Result;

            //得到错误行
            var errorDatas = _rows.Where(x => !x.IsValid);
            //错误行业务处理

            //将有效数据行转换为指定类型
            //var validDatas = _rows.Where(x => x.IsValid).FastConvert<ExcelCarTemplateDTO>();
            //正确数据业务处理


            return new string[] { "value1", "value2" };
        }

        
    }
}
