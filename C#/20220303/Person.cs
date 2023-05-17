﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220303
{
    /// <summary>
    /// 人
    /// </summary>
    internal class Person
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 媒體偏好國家
        /// </summary>
        public List<string> CountryPrefer { get; set; }
        /// <summary>
        /// 媒體偏好類型
        /// </summary>
        public List<string> TypePrefer { get; set; }
    }
}
