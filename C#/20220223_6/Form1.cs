using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220223_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// 使用迴圈
            
            /// 西元
            int str = int.Parse(textBox1.Text);
            CountSatSun(str);  //使用迴圈


            /*
            /// 民國
            int cstr = int.Parse(textBox4.Text) + 1911;
            CountSatSun(cstr);  //使用迴圈
            */

            /*
            /// 西元 每天
            int year = int.Parse(textBox1.Text);
            RoundEveryDay(year);
            */

            /*
            /// 民國 每天
            int cyear = int.Parse(textBox4.Text) + 1911;
            RoundEveryDay(cyear);
            */
        }


        private void button2_Click(object sender, EventArgs e)
        {
            /// 不使用迴圈
            /*
            /// 西元
            int str = int.Parse(textBox1.Text);
            Count(str);  //使用方法硬做
            */


            /// 民國
            int cstr = int.Parse(textBox4.Text) + 1911;
            Count(cstr);  //使用方法 硬
            
        }
        private static (int, int) Choice(ref DateTime year, ref int cSat, ref int cSun)
        {
            if (Convert.ToInt32(year.DayOfWeek) == 0)
            {
                year = year.AddDays(0);
                cSun += 1;
            }
            year = year.AddDays(7 - Convert.ToInt32(year.DayOfWeek));
            cSat += 1;
            cSun += 1;

            return (cSat, cSun);
        }

        private void CountSatSun(int str)
        {
            DateTime year = new DateTime(str, 1, 1);
            DateTime endYear = new DateTime(str + 1, 1, 1);
            int cSat = 0;
            int cSun = 0;

            (cSat, cSun) = Choice(ref year, ref cSat, ref cSun);


            while (year < endYear && year.AddDays(6) < endYear)
            {
                year = year.AddDays(6);
                cSat += 1;
                if (year.AddDays(1) < endYear)
                {
                    year = year.AddDays(1);
                    cSun += 1;
                }
            }
            label1.Text = cSat.ToString();
            label2.Text = cSun.ToString();
        }
        private void Count(int cstr)
        {
            DateTime year = new DateTime(cstr, 1, 1);
            DateTime endYear = new DateTime(int.Parse(year.ToString("yyyy")) + 1, 1, 1);

            int cSat = 0;
            int cSun = 0;

            (cSat, cSun) = Choice(ref year, ref cSat, ref cSun);

            (cSat, cSun) = CountAll(ref year, ref cSat, ref cSun, ref endYear);

            label1.Text = cSat.ToString();
            label2.Text = cSun.ToString();
        }

        private (int, int) CountAll(ref DateTime year, ref int cSat, ref int cSun, ref DateTime endYear)
        {
            if (year.AddDays(6) < endYear)
            {
                year = year.AddDays(6);
                cSat += 1;
                if (year.AddDays(1) < endYear)
                {
                    year = year.AddDays(1);
                    cSun += 1;
                }
            }
            else
                return (cSat, cSun);
            if (year < endYear)
                return CountAll(ref year, ref cSat, ref cSun, ref endYear);
            else
                return (cSat, cSun);
        }
        private static void RoundEveryDay(int year)
        {
            var date = new DateTime(year, 1, 1);
            int cSat = 0;
            int cSun = 0;

            while (date.Year == year)
            {
                DayOfWeek dayOfWeek = date.DayOfWeek;
                if (Convert.ToInt32(date.DayOfWeek) == 6)
                {
                    cSat += 1;
                }
                if (Convert.ToInt32(date.DayOfWeek) == 0)
                {
                    cSun += 1;
                }
            }
        }
    }
}
