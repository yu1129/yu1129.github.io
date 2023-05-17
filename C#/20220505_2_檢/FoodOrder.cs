using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220505_2_檢
{
    internal class FoodOrder
    {

        public FoodOrder(Label nameUI, Label priceUI, NumericUpDown counterUI)
        {
            NameUI = nameUI;
            PriceUI = priceUI;
            CounterUI = counterUI;
        }

        Label NameUI { get; set; }
        Label PriceUI { get; set; }
        NumericUpDown CounterUI { get; set; }

        public int GetSubTotal()
        {
            int price = int.Parse(PriceUI.Text.TrimEnd('元'));
            
            int count = (int)CounterUI.Value;

            return price * count;
        }
    }
}
