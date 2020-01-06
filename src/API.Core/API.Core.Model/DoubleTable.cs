using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Model
{
    public class DoubleTable
    {
        /// <summary>
        /// 左表
        /// </summary>
        public string LeftSurface { get; set; }

        /// <summary>
        /// 右表
        /// </summary>
        public string RightSurface { get; set; }

        /// <summary>
        /// 右表主键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 左表外键
        /// </summary>
        public string ForeignKey { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int IntPageIndex { get; set; } = 0;

        /// <summary>
        /// 页大小
        /// </summary>
        public int IntPageSize { get; set; } = 10;

        /// <summary>
        /// 排序条件
        /// </summary>
        public string OrderByFileds { get; set; }

    }
}
