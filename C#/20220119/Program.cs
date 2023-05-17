using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220119
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //Lab3_1 廢話產生器
            ///主程式區碼
            Console.WriteLine("請輸入「人」:");
            string name = Console.ReadLine();
            Console.WriteLine("請輸入「事」:");
            string thing = Console.ReadLine();

            Console.WriteLine(name + "正在" + thing);
            */

            /*
            //Lab3_1 廢話產生器
            ///使用方法
            Console.WriteLine("請輸入「人」:");
            string name = Console.ReadLine();
            Console.WriteLine("請輸入「事」:");
            string thing = Console.ReadLine();

            DoThing(name, thing);
            */

            /*
            //Lab3_2 台幣換美金
            Console.WriteLine("請輸入新台幣數值:");
            int NTdollar = int.Parse(Console.ReadLine());

            Console.WriteLine($"對應的美金價值為:{(double)NTdollar / 28}");
            */

            /*
            //Lab3_2 台幣換美金
            Console.WriteLine("請輸入新台幣數值:");
            int NTdollar = int.Parse(Console.ReadLine());

            ChangeUSD(NTdollar);
            */

            /*
            //Lab3_3 華氏換攝氏
            Console.WriteLine("請輸入整數的華氏溫度值:");
            double degreeF = double.Parse(Console.ReadLine());
            double degreeC = (degreeF - 32) * 5 / 9;

            Console.WriteLine($"對應的攝氏溫度值為:{degreeC}");
            */

            /*
            //Lab3_4 數值交換
            Console.WriteLine("請輸入 a 的值:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("請輸入 b 的值:");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine($"交換前，a = {a}，b = {b}");
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"交換後，a = {a}，b = {b}");
            */

            Console.ReadLine();
        }
        static void DoThing(string a, string b)
        {
            Console.WriteLine(a + "正在" + b);
        }
        static void ChangeUSD(int a)
        {
            Console.WriteLine($"對應的美金價值為:{(double)a / 28}");
        }
    }
}
