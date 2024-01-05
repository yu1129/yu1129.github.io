using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTimeTable.DTO
{
    internal class UnitTimeTable
    {
        public string RouteID { get; set; }
        public int Direction { get; set; }
        public string Stop { get; set; }
        public string Time { get; set; }
        public string Car { get; set; }
    }
}
