using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220505_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var min = Convert.ToDateTime(dateTimePicker2.Value).Subtract(Convert.ToDateTime(dateTimePicker1.Value)).Days * 24 * 60 + Convert.ToDateTime(dateTimePicker2.Value).Subtract(Convert.ToDateTime(dateTimePicker1.Value)).Hours * 60 + Convert.ToDateTime(dateTimePicker2.Value).Subtract(Convert.ToDateTime(dateTimePicker1.Value)).Minutes + 1;
            
            if (min < 0)
            {
                MessageBox.Show("請重新輸入");
                return;
            }

            if (Convert.ToDateTime(dateTimePicker2.Value) < Convert.ToDateTime(dateTimePicker1.Value))
            {
                label3.Text = "請重新輸入";
            }
            else if (min >= 240)
            {
                label3.Text = (min / 30 * 60).ToString();
            }
            else if (min > 120 && min < 240)
            {
                label3.Text = (min / 30 * 40).ToString();
            }
            else
            {
                label3.Text = (min / 30 * 30).ToString();
            }

        }
    }
}
