using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220303
{
    /// <summary>
    /// 影片
    /// </summary>
    internal class Video
    {
        /// <summary>
        /// 片名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 國家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 類型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 片長(分鐘為單位)
        /// </summary>
        public double Duration { get; set; }
    }
}
