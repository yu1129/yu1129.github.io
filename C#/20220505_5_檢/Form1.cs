using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220505_5_檢
{
    public partial class Form1 : Form
    {
        List<string> Stations;
        List<string> _fromStations;
        List<string> _toStations;
        List<List<int>> _ticketPriceTable; 
        public Form1()
        {
            InitializeComponent();

            _fromStations = new List<string> { "台北", "新竹", "台中", "嘉義", "台南", "高雄" };

            _ticketPriceTable = new List<List<int>>
            {
                new List<int>{},
                new List<int> { 177, },
                new List<int>{ 375, 197, },
                new List<int>{ 598, 421, 224, },
                new List<int>{ 738, 560, 363, 139, },
                new List<int>{ 842, 755, 469, 245, 106 }
            };

            radioButton1.Checked = true;
            comboBox1.DataSource = _fromStations;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeToStations();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeToStations();
        }

        private void ChangeToStations()
        {
            int idx = comboBox1.SelectedIndex;

            if (radioButton1.Checked)
            {
                _toStations = _fromStations.Skip(idx + 1).ToList();
            }
            else
            {
                _toStations = _fromStations.Take(idx).ToList();
            }

            comboBox2.DataSource = _toStations;

            comboBox2.SelectedIndex = -1;
            //comboBox2.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                label4.Text = "無法計算";
                return;
            }

            int fromIndex = comboBox1.SelectedIndex;
            int toIndex = comboBox1.SelectedIndex + (radioButton1.Checked ? fromIndex + 1 : 0);

            decimal price = radioButton1.Checked ? _ticketPriceTable[toIndex][fromIndex] : _ticketPriceTable[fromIndex][toIndex];
            if (checkBox1.Checked) price = price * 9 / 5;
            if (checkBox2.Checked) price = price * 9 / 10;

            label4.Text = Math.Ceiling(price) + "元";
        }
    }
}
