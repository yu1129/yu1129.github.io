using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220505_3_檢
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double halfHours = (dateTimePicker2.Value - dateTimePicker1.Value).TotalHours;

            if (halfHours < 0)
            {
                MessageBox.Show("請重新選擇");
                return;
            }

            label3.Text = CalcTotalFee((int)halfHours) + "元";
        }
        // 解法 1
        private int CalcTotalFee(int halfHours)
        {
            int total = 0;

            if (halfHours > 8)
            {
                total += (halfHours - 8) * 60;
                halfHours = 8;
            }

            if (halfHours > 4)
            {
                total += (halfHours - 4) * 40;
                halfHours = 4;
            }

            total += (halfHours - 0) * 30;
            halfHours = 0;

            return total;
        }

        // 解法 2
        private List<ChargeLevel> _chargeLevels = new List<ChargeLevel>() {
            new ChargeLevel() { HalfHourLowerBound半小時下限 = 8, ChargeRate半小時費率 = 60},
            new ChargeLevel(4, 40){ChargeRate半小時費率 = 40},
            new ChargeLevel(0, 30)
        };
        private int CalcTotalFree2(int halfHours)
        {
        var validlevels = _chargeLevels.Where(ListView => halfHours > ListView.HalfHourLowerBound半小時下限);

            return validlevels.Sum(lv =>
            {
                var over = halfHours - lv.HalfHourLowerBound半小時下限;
                halfHours = lv.HalfHourLowerBound半小時下限;
                return over * lv.ChargeRate半小時費率;
            });
        }
    }
}
