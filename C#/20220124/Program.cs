using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220124
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //Lab4_1 等差數列
            Console.WriteLine("請輸入首項:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("請輸入公差:");
            int d = int.Parse(Console.ReadLine());

            Console.WriteLine("等差數列前7項:");
            for (int i = a; i < (a + d*7); i += d)
            {
                Console.WriteLine(i);
            }
            */

            /*
            //Lab4_2 等比數列
            Console.WriteLine("請輸入首項:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("請輸入公比:");
            int r = int.Parse(Console.ReadLine());
            string beforeSeven = "";

            Console.WriteLine("等比數列前7項:");
            for (int i = a; i < (a + Math.Pow(r, 8)); i *= r)
            {
                beforeSeven += i;
                beforeSeven += ",";
            }
            Console.WriteLine(beforeSeven);
            */

            /*
            //Lab4_3 瓶蓋兌換
            string[] bottle = new string[7];

            Console.WriteLine("請輸入已購買的可樂瓶數:");
            for (int i = 0; i < 7; i++)
            {
                bottle[i] = Console.ReadLine();
            }
            Console.WriteLine("參考值輸入 => 輸出對應");

            for (int i = 0; i < 7; i++)
            {
                int temp = int.Parse(bottle[i]);
                int changeBottle = 0;
                changeBottle += temp;
                while (true)
                {
                    changeBottle += (temp / 3);
                    temp = (temp / 3) + (temp % 3);
                    if (temp < 3)
                        break;
                }
                
                Console.WriteLine($"{bottle[i].ToString().PadLeft(10)} => {changeBottle.ToString().PadRight(10)}");
            }
            */

            /*
            //Lab5_1 印出三角形
            Console.WriteLine("請輸入一個整數:");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number - (i - 1); j++)
                {
                    Console.Write("X");
                }
                for (int k = 1; k <= i - 1; k++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i - 1; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= number - (i - 1); k++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= i; k++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("X");
                }
                for (int k = 1; k <= number - i; k++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            */

            /*
            //Lab5_2 印出金字塔
            ///解法1 : 分兩部分解
            Console.WriteLine("請輸入一個整數:");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= i; k++)
                {
                    Console.Write("X");
                }
                for (int l = 1; l <= i - 1; l++)
                {
                    Console.Write("X");
                }
                for (int l = 1; l <= number - (i - 1); l++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            */

            /*
            //Lab5_2 印出金字塔
            ///解法2 : 分一部分解
            Console.WriteLine("請輸入一個整數:");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= (2 * i) - 1; k++)
                {
                    Console.Write("X");
                }
                for (int l = 1; l <= number - i; l++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            */

            /*
            //Lab5_3 印出菱形
            ///解法1 : 分五部分解
            Console.WriteLine("請輸入一個整數:");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number - (i - 1); j++)
                {
                    Console.Write("X");
                }
                for (int k = 1; k <= i - 1; k++)
                {
                    Console.Write("|");
                }
                for (int l = 1; l <= i;l++)
                {
                    Console.Write("|");
                }
                for (int m = 1; m <= (number + 1) - i; m++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();

            }
            for(int i = 1; i <= (number * 2 + 1); i++)
            {
                Console.Write("|");
            }
            Console.WriteLine();
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("X");
                }
                for (int k = 1; k <= (number - i); k++)
                {
                    Console.Write("|");
                }
                for (int l = 1; l <= (number + 1) - i; l++)
                {
                    Console.Write("|");
                }
                for (int m = 1; m <= i; m++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }
            */

            /*
            //Lab5_3 印出菱形
            ///解法2 : 分三部分解
            Console.WriteLine("請輸入一個整數:");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number - (i - 1); j++)
                {
                    Console.Write("X");
                }
                for (int k = 1; k <= (2 * i) - 1; k++)
                {
                    Console.Write("|");
                }
                for (int m = 1; m <= number - (i - 1); m++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();

            }
            for (int i = 1; i <= (number * 2 + 1); i++)
            {
                Console.Write("|");
            }
            Console.WriteLine();
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("X");
                }
                for (int k = 1; k <= (2 * number) - (2 * i) + 1; k++)
                {
                    Console.Write("|");
                }
                for (int m = 1; m <= i; m++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }
            */

            /*
            //Lab5_4 印出風車
            Console.WriteLine("請輸入一個整數:");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("'");
                }
                for (int k = 1; k <= (number - i); k++)
                {
                    Console.Write("X");
                }
                for (int l = 1; l <= number - (i - 1); l++)
                {
                    Console.Write("'");
                }
                for (int m = 1; m <= (i - 1); m++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number - i; j++)
                {
                    Console.Write("X");
                }
                for (int k = 1; k <= i; k++)
                {
                    Console.Write("'");
                }
                for (int l = 1; l <= (i - 1); l++)
                {
                    Console.Write("X");
                }
                for (int m = 1; m <= number - (i - 1); m++)
                {
                    Console.Write("'");
                }
                Console.WriteLine();
            }
            */

            /*
            //Lab5_5 印出九九乘法表
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.Write($@"{j.ToString().PadLeft(2)} * {i.ToString().PadRight(2)} = {(j * i).ToString().PadRight(4)}");
                }
                Console.WriteLine();
            }
            */

            /*
            //Lab6_1 分數獎勵
            Console.WriteLine("輸入考數分數:");
            int score = int.Parse(Console.ReadLine());

            if (score >= 90)
                Console.Write("一頓西堤");
            else if (score >= 70)
                Console.Write("一杯 City Cafe");
            else
                Console.Write("一頓暴打");
            */

            /*
            //Lab6_2 分數加成
            Console.WriteLine("請輸入原始成績:");
            double originalGrade = double.Parse(Console.ReadLine());
            Console.WriteLine("你是原住民嗎:");
            bool aboriginalPeople = bool.Parse(Console.ReadLine());
            Console.WriteLine("你有身心障礙嗎嗎:");
            bool physicalDisabilities = bool.Parse(Console.ReadLine());

            if (aboriginalPeople == true && physicalDisabilities == true)
                originalGrade = (originalGrade * (1 + 0.35)) * (1 + 0.22);
            else if (aboriginalPeople == true)
                originalGrade = originalGrade * (1 + 0.35);
            else if (physicalDisabilities == true)
                originalGrade = originalGrade * (1 + 0.22);

            Console.Write($"你的有效分數是:{originalGrade}");
            */

            /*
            //Lab6_3 擇偶條件
            Console.WriteLine("輸入身高:");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("輸入年薪:");
            int annualSalary = int.Parse(Console.ReadLine());
            Console.WriteLine("輸入職業:");
            string profession = Console.ReadLine();
            string result = "考慮";

            if (height < 180 || annualSalary < 1000000)
            {
                result = "不考慮";
                Console.WriteLine($"結果:{result}");
            }
            else if (profession == "醫師" || profession == "律師")
            {
                result = "考慮";
                Console.WriteLine($"結果:{result}");
            }
            */

            Console.ReadLine();
        }
    }
}
