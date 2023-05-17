using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220505_2
{
    public partial class Form1 : Form
    {
        //int dollar = 0;
        List<string> _buyList;
        public Form1()
        {
            InitializeComponent();
            //CreateList();
            //DataSource();
        }

        private void CreateList()
        {
            _buyList = new List<string>();
        }
        private void DataSource()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _buyList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dollar;
            
            dollar = int.Parse(numericUpDown1.Text) * 30 + int.Parse(numericUpDown2.Text) * 17 + int.Parse(numericUpDown3.Text) * 15 + int.Parse(numericUpDown4.Text) * 40;
            label2.Text = $"總金額: {dollar}";

            if (dollar / 1000 > 0)
            {
                label3.Text = $"1000 元: { dollar / 1000 } 張";
            }
            else
            {
                label3.Text = $"1000 元: 0 張";
            }
            if (dollar / 100 % 10 >= 5)
            {
                label4.Text = "500 元: 1 張";
                label5.Text = $"100 元: { dollar / 100 % 10 - 5 } 張";
            }
            else if (dollar / 100 % 10 < 5 && dollar / 100 % 10 > 0)
            {
                label4.Text = "500 元: 0 張";
                label5.Text = $"100 元: { dollar / 100 % 10 } 張";
            }
            else 
            {
                label4.Text = "500 元: 0 張";
                label5.Text = $"100 元: 0 張";
            }
            if (dollar / 10 % 10 >= 5)
            {
                label6.Text = "50 元: 1 個";
                label7.Text = $"10 元: { dollar / 10 % 10 - 5 } 個";
            }
            else if (dollar / 10 % 10 < 5 && dollar / 10 % 10 > 0)
            {
                label6.Text = "50 元: 0 個";
                label7.Text = $"10 元: { dollar / 10 % 10 } 個";
            }
            else
            {
                label6.Text = "50 元: 0 個";
                label7.Text = $"10 元: 0 個";
            }
            if (dollar % 10 >= 5)
            {
                label8.Text = "5 元: 1 個";
                label9.Text = $"1 元: { dollar % 10 - 5 } 個";
            }
            else if (dollar % 10 < 5 && dollar % 10 > 0)
            {
                label8.Text = "5 元: 0 個";
                label9.Text = $"1 元: { dollar % 10 } 個";
            }
            else
            {
                label8.Text = "5 元: 0 個";
                label9.Text = $"1 元: 0 個";
            }

            this.listBox1.Items.Add($"{label10.Text}: {numericUpDown1.Text}, {label11.Text}: {numericUpDown2.Text}, {label12.Text}: {numericUpDown3.Text}, {label13.Text}: {numericUpDown4.Text}");
        }

    }
}
