using EasyOffice.Attributes;
using EasyOffice.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class ExcelCarTemplateDTO
    {
       
        [ColName("旧型号名")]
        [MaxLength(20)]
        public string Name { get; set; }

        
    }

   
}
