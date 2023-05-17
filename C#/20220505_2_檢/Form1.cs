using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220505_2_檢
{
    public partial class Form1 : Form
    {
        List<FoodOrder> _foodOrders;
        List<int> _moneyList;
        public Form1()
        {
            InitializeComponent();
            _foodOrders = new List<FoodOrder>()
            {
                new FoodOrder(label10, label1, numericUpDown1),
                new FoodOrder(label11, label14, numericUpDown2),
                new FoodOrder(label12, label15, numericUpDown3),
                new FoodOrder(label13, label16, numericUpDown4)
            };
            _moneyList = new List<int>()
            {
                1000, 500, 100, 50, 10, 5, 1
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total = _foodOrders.Sum(f => f.GetSubTotal());
            label2.Text = $"總價: {total} 元";

            ArrangePayment(total);
        }

        private void ArrangePayment(int total)
        {
            var infoList = _moneyList.Select(money => { int count = total / money; total %= money; return $"\n {money} 元 : {count} 份"; });

            label3.Text = "幣值分配 : " + String.Concat(infoList);
        }
    }
}
