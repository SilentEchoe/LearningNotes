using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace Model.Models
{
    public class SysUserInfo
    {
        public SysUserInfo() { }

        public SysUserInfo(string loginName, string loginPWD)
        {
            ULoginName = loginName;
            ULoginPwd = loginPWD;
            URealName = ULoginName;
            UStatus = 0;
            UCreateTime = DateTime.Now;
            UUpdateTime = DateTime.Now;
            ULastErrTime = DateTime.Now;
            UErrorCount = 0;
            Name = "";

        }
        /// <summary>
        /// 用户ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int UID { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        [SugarColumn(Length = 60, IsNullable = true)]
        public string ULoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [SugarColumn(Length = 60, IsNullable = true)]
        public string ULoginPwd { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [SugarColumn(Length = 60, IsNullable = true)]
        public string URealName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int UStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(Length = int.MaxValue, IsNullable = true)]
        public string URemark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime UCreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime UUpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        ///最后登录时间 
        /// </summary>
        public DateTime ULastErrTime { get; set; } = DateTime.Now;

        /// <summary>
        ///错误次数 
        /// </summary>
        public int UErrorCount { get; set; }



        /// <summary>
        /// 登录账号
        /// </summary>
        [SugarColumn(Length = 60, IsNullable = true)]
        public string Name { get; set; }

        // 性别
        [SugarColumn(IsNullable = true)]
        public int Sex { get; set; } = 0;
        // 年龄
        [SugarColumn(IsNullable = true)]
        public int Age { get; set; }
        // 生日
        [SugarColumn(IsNullable = true)]
        public DateTime Birth { get; set; } = DateTime.Now;
        // 地址
        [SugarColumn(Length = 200, IsNullable = true)]
        public string Addr { get; set; }

        [SugarColumn(IsNullable = true)]
        public bool TdIsDelete { get; set; }


        [SugarColumn(IsIgnore = true)]
        public int Rid { get; set; }
        [SugarColumn(IsIgnore = true)]
        public string RoleName { get; set; }

    }
}
