using EasyOffice.Attributes;
using EasyOffice.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test2
{
    public static  class ExcelCarTemplateDTO
    {
        [ColName("车牌号")]
        [Required]
        [Regex(RegexConstant.CAR_CODE_REGEX)]
        [Duplication]
        //[MergeCols]
        public static string CarCode { get; set; }

        [ColName("手机号")]
        [Regex(RegexConstant.MOBILE_CHINA_REGEX)]
        public static string Mobile { get; set; }

        [ColName("身份证号")]
        [Regex(RegexConstant.IDENTITY_NUMBER_REGEX)]
        public static string IdentityNumber { get; set; }

        [ColName("姓名")]
        [MaxLength(10)]
        public static string Name { get; set; }

        [ColName("性别")]
        [Regex(RegexConstant.GENDER_REGEX)]
        public static GenderEnum Gender { get; set; }

     
    }

    public enum GenderEnum
    {
        男 = 10,
        女 = 20
    }
}
