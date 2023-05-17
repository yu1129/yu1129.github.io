using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220223_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void TotalCal(bool w, bool u)
        {
            double x = double.Parse(textBox1.Text);
            double y = double.Parse(textBox2.Text);
            if (w && u)
                label1.Text = (x + y).ToString();
            else if (w && u == false)
                label1.Text = (x - y).ToString();
            else if (w == false && u)
                label1.Text = (x * y).ToString();
            else
                label1.Text = (x / y).ToString();
        }

        private void DisplayResult(char v)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox1.Text);

            if (v == '+' || v == '-')
            {
                if (v == '-')
                    y = -y;
                label1.Text = (x + y).ToString();
            }
            else if (v == '*' || v == '/')
            {
                if (v == '/')
                    y = 1 / y;
                label1.Text = (x - y).ToString();
            }
        }

        private void DisplayResult1(char v)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox1.Text);

            Dictionary<char, int> dict = new Dictionary<char, int>()
            {
                {'+', x+y},
                {'-', x-y},
                {'*', x*y},
                {'/', x/y},
            };

            label1.Text = dict[v].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// 方法設兩個布林值
            TotalCal(true, true);

            /*
            /// 方法判斷運算子
            DisplayResult('+');
            */

            /*
            /// 用字典查找
            DisplayResult1('/');
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TotalCal(true, false);
            //DisplayResult('-');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TotalCal(false, true);
            //DisplayResult('*');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TotalCal(false, false);
            //DisplayResult('/');
        }
    }
}
