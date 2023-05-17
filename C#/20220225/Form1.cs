using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220225
{
    public partial class Form1 : Form
    {
        private List<string> _leftList;
        private List<string> _rightList;
        private List<string> _resultList;
        private bool _isFarmerLeft;
        private int count;
        public Form1()
        {
            InitializeComponent();
            CreateList();
            SetListDataSource();
            ChangeData();
        }
        private void CreateList()
        {
            _leftList = new List<string>
            {
                "農夫", "狼", "羊", "菜"
            };
            _rightList = new List<string>();
            _resultList = new List<string>();
            count = 0;
            _isFarmerLeft = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
        }
        private void SetListDataSource()
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
        }
        private void ChangeData()
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox3.DataSource = null;
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
            listBox3.DataSource = _resultList;
            if (_leftList.Count >= 3)
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            count += 1;
            CloseRest();
            MoveData(listBox1, _leftList, _rightList);

            if (_rightList.Count == 4)
            {
                MessageBox.Show("恭喜過關");
                button4.Enabled = true;
                button3.Enabled = false;
                button2.Enabled = false;
                button1.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            count += 1;
            CloseRest();
            MoveData(listBox2, _rightList, _leftList);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var thing = _resultList.ElementAt(_resultList.Count - 2);
            var role = thing[4].ToString();

            if (thing.Contains("過河") && _rightList.FirstOrDefault((x) => x.Contains(role)) != null)
            {
                ToLeft(role);
                ToLeft("農夫");
            }
            else if (thing.Contains("過河") && _rightList.FirstOrDefault((x) => x.Contains(role)) == null)
            {
                ToLeft("農夫");
            }
            else if (thing.Contains("回去") && _leftList.FirstOrDefault((x) => x.Contains(role)) != null)
            {
                ToRight(role);
                ToRight("農夫");
            }
            else
            {
                ToRight("農夫");
            }
            DeleteResult();
            ChangeData();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            RestGame();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            count += 1;
            CloseRest();
            var farmerSideListBox = listBox2;
            if (_isFarmerLeft)
            {
                farmerSideListBox = listBox1;
            }
            string selectedName = (string)farmerSideListBox.SelectedItem;
            if (selectedName == null)
            {
                return;
            }
            if (selectedName != "農夫")
            {
                AcrossData(selectedName);
            }
            AcrossData("農夫");

            if (selectedName == "農夫")
                selectedName = String.Empty;
            AcrossResult(farmerSideListBox, "農夫", selectedName);

            _isFarmerLeft = !_isFarmerLeft;
            ChangeData();
            button3.Enabled = true;

            if (CheckGameOver())
            {
                button5.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
            }
        }
        private void AcrossResult(ListBox lb, string v, string s)
        {
            if (lb == listBox1)
            {
                ToResult(true, "農夫", s);
            }
            else
            {
                ToResult(false, "農夫", s);
            }
        }
        private void MoveData(ListBox lb, List<string> go, List<string> to)
        {
            string item = (string)lb.SelectedItem;

            if (item != "農夫" && go.Find((x) => x.Contains("農夫")) == "農夫")
            {
                if (go == _leftList)
                    ToRight(item);
                else
                    ToLeft(item);
            }
            else if (to.Find((x) => x.Contains("農夫")) == "農夫")
            {
                MessageBox.Show("請重新選擇");
            }

            if (go.Find((x) => x.Contains("農夫")) == "農夫")
            {
                if (item == "農夫")
                {
                    item = String.Empty;
                }
                if (go == _leftList)
                {
                    ToRight("農夫");
                    ToResult(true, "農夫", item);
                }
                else
                {
                    ToLeft("農夫");
                    ToResult(false, "農夫", item);
                }
            }

            ChangeData();

            CloseB1B2();

            Judge(go);
        }
        private void CloseB1B2()
        {
            if (_leftList.Find((x) => x.Contains("農夫")) == "農夫")
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = true;
            }
        }
        private bool CheckGameOver()
        {
            if (_rightList.Count == 4)
            {
                MessageBox.Show("Win");
                return true;
            }

            var noFarmerSideList = _leftList;
            if (_isFarmerLeft)
            {
                noFarmerSideList = _rightList;
            }

            if (noFarmerSideList.Contains("羊"))
            {
                if (noFarmerSideList.Contains("狼"))
                {
                    MessageBox.Show($"狼吃了羊");
                    return true;
                }
                if (noFarmerSideList.Contains("菜"))
                {
                    MessageBox.Show($"羊吃了菜");
                    return true;
                }
            }

            return false;
        }
        private void AcrossData(string v)
        {
            var go = _rightList;
            var to = _leftList;
            if (_isFarmerLeft)
            {
                go = _leftList;
                to = _rightList;
            }

            go.Remove(v);
            to.Add(v);
        }
        private void Judge(List<string> a)
        {
            if (a.Contains("羊") && a.Contains("菜") || a.Contains("羊") && a.Contains("狼"))
            {
                MessageBox.Show("遊戲失敗");
                button4.Enabled = true;
                button3.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }
        private void ToRight(string item)
        {
            _leftList.Remove(item);
            _rightList.Add(item);
        }
        private void ToLeft(string item)
        {
            _rightList.Remove(item);
            _leftList.Add(item);
        }
        private void ToResult(bool a, string item, string carry)
        {
            if (a && carry != String.Empty)
            {
                _resultList.Add(item + "帶著" + carry + "過河");
                _resultList.Add("-----------------------------");
            }
            else if (a && carry == String.Empty)
            {
                _resultList.Add(item + "自己過河");
                _resultList.Add("-----------------------------");
            }
            else if (a == false && carry != String.Empty)
            {
                _resultList.Add(item + "帶著" + carry + "回去");
                _resultList.Add("-----------------------------");
            }
            else
            {
                _resultList.Add(item + "自己回去");
                _resultList.Add("-----------------------------");
            }
        }
        private void DeleteResult()
        {
            _resultList.RemoveRange(_resultList.Count - 2, 2);
            //_resultList.RemoveAt(_resultList.Count - 1);
            //_resultList.RemoveAt(_resultList.Count - 1);
        }
        private void CloseRest()
        {
            if (count > 0)
            {
                button4.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
                button3.Enabled = false;
            }
        }
        private void RestGame()
        {
            CreateList();
            ChangeData();
        }

    }
}
