using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTimeTable.DTO
{
    internal class SourceData
    {
        public int? code { get; set; }
        public object message { get; set; }
        public Data data { get; set; }
        public class Data
        {
            public Gpsdata[] gpsData { get; set; }
            public Displaysettings displaySettings { get; set; }
        }

        public class Displaysettings
        {
            public int? startTimeUnit { get; set; }
            public int? activeTimeUnit { get; set; }
        }

        public class Gpsdata
        {
            public CarPassed V01 { get; set; }
            public CarPassed V02 { get; set; }
            public CarPassed V03 { get; set; }
            public CarPassed V04 { get; set; }
            public CarPassed V05 { get; set; }
            public CarPassed V06 { get; set; }
            public CarPassed V07 { get; set; }
            public CarPassed V08 { get; set; }
            public CarPassed V09 { get; set; }
            public CarPassed V10 { get; set; }
            public CarPassed V11 { get; set; }
            public CarPassed V28 { get; set; }
            public CarPassed V27 { get; set; }
            public CarPassed V26 { get; set; }
        }

        public class CarPassed
        {
            public string carNum { get; set; }
            public string drivingTime { get; set; }
            public int? routeId { get; set; }
            public int? time { get; set; }
            public int? time3 { get; set; }
            public int? time4 { get; set; }
            public int? timeRouteId { get; set; }
        }
    }
}
