using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220505_5
{
    public partial class Form1 : Form
    {
        decimal[,] journey;
        decimal ticketprice;
        decimal total;
        public Form1()
        {
            InitializeComponent();
            journey = new decimal[6, 6] { {0, 177, 375, 598, 738, 842}, {177, 0, 197, 421, 560, 755}, {375, 197, 0, 224, 363, 469}, {598, 421, 224, 0, 139, 245}, {738, 560, 363, 139, 0, 106}, {842, 755, 469, 245, 106, 0} };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ticketprice = journey[comboBox1.SelectedIndex, comboBox2.SelectedIndex];
            }
            else if (radioButton2.Checked)
            {
                ticketprice = journey[comboBox2.SelectedIndex, comboBox1.SelectedIndex];
            }


            if (checkBox1.Checked && checkBox2.Checked)
            {
                total = Convert.ToDecimal(ticketprice * 0.81M);
            }
            else if (checkBox1.Checked)
            {
                total = Convert.ToDecimal(ticketprice * 2 * 0.9M);
            }
            else if (checkBox2.Checked)
            {
                total = Convert.ToDecimal(ticketprice * 0.9M);
            }

            label4.Text = Math.Ceiling(total).ToString();
        }
    }
}
