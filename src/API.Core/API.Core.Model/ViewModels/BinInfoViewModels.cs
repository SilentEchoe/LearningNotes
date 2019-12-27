using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Model.ViewModels
{
    public class BinInfoViewModels
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// PN 型号名
        /// </summary>
        public string Pn { get; set; }


        /// <summary>
        /// SN Bin文件序列号
        /// </summary>
        public string Sn { get; set; }

        /// <summary>
        /// Waveband 波段
        /// </summary>
        public string Waveband { get; set; }


        /// <summary>
        /// Distance 距离
        /// </summary>
        public string Distance { get; set; }


        /// <summary>
        /// Isddm
        /// </summary>
        public bool Isddm { get; set; }


        /// <summary>
        /// BinType bin文件的封装类型
        /// </summary>
        public string BinType { get; set; }


        /// <summary>
        /// BinMeter bin文件的米数（仅线缆）
        /// </summary>
        public string BinMeter { get; set; }

        /// <summary>
        /// compatibility 兼容类型
        /// </summary>
        public string Compatibility { get; set; }


        /// <summary>
        /// Manufacturer 厂商名
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// version 版本
        /// </summary>
        public string Version { get; set; }

    }
}
