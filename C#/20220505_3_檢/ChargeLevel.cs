using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220505_3_檢
{
    internal class ChargeLevel
    {
        public int HalfHourLowerBound半小時下限 { get; set; }
        public int ChargeRate半小時費率 { get; set; }

        public ChargeLevel(int halfHourLowerBound, int chargeRate)
        {
            HalfHourLowerBound半小時下限 = halfHourLowerBound;
            ChargeRate半小時費率 = chargeRate;
        }

        public ChargeLevel()
        {
        }
    }
}
