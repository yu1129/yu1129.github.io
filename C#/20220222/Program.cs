using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220222
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // 1 奇偶數判斷
            /// 用 if else
            Console.WriteLine("請輸入一個整數數字:");
            int number = int.Parse(Console.ReadLine());
            if (IsOddNumber(number))
                Console.WriteLine("奇數");
            else
                Console.WriteLine("偶數");
            */

            /*
            // 1 奇偶數判斷
            /// 用 switch case
            Console.WriteLine("請輸入一個整數數字:");
            int number = int.Parse(Console.ReadLine());
            switch (number % 2)
            {
                case 0:
                    Console.WriteLine("奇數");
                    break;
                case 1:
                    Console.WriteLine("偶數");
                    break;
            }
            */

            /*
            // 1 奇偶數判斷
            /// 用 三元運算式
            Console.WriteLine("請輸入一個整數數字:");
            int number = int.Parse(Console.ReadLine());
            string s = number % 2 == 0 ? $"偶數" : $"奇數"
            Console.WriteLine(s);
             */

            /*
            // 2 奇偶數判斷
            /// 用 foreach 與 .Trim()
            Console.WriteLine("請輸入一串以逗號分隔的數字字串:");
            string str = Console.ReadLine();
            string[] numberStr = str.Split(',');
            int[] number = new int[numberStr.Length];
            string odd = "";
            string notOdd = "";

            for (int i = 0; i < numberStr.Length; i++)
            {
                number[i] = int.Parse(numberStr[i]);
            }
            Array.Sort(number);

            foreach (int s in number)
            {
                if (IsOddNumber(s))
                {
                    odd += s + ",";
                }
                else
                {
                    notOdd += s + ",";
                }
            }

            Console.WriteLine($"奇數:{odd.TrimEnd(',')}");
            Console.WriteLine($"偶數:{notOdd.TrimEnd(',')}");
            */

            /*
            // 2 奇偶數判斷
            /// 用 方法
            Console.WriteLine("請輸入一串以逗號分隔的數字字串:");
            string str = Console.ReadLine();
            string[] numberStr = str.Split(',');
            int[] number = new int[numberStr.Length];
            string odd = String.Empty;
            string notOdd = String.Empty;

            for (int i = 0; i < numberStr.Length; i++)
            {
                number[i] = int.Parse(numberStr[i]);
            }
            Array.Sort(number);

            foreach (int s in number)
            {
                if (s % 2 == 0)
                {
                    notOdd = Solution(notOdd, s);
                }
                else
                {
                    odd = Solution(odd, s);
                }
            }

            Console.WriteLine($"奇數:{odd}");
            Console.WriteLine($"偶數:{notOdd}");
            */

            /*
            // 3 迴圈倒置
            /// 用 Array.Reverse()
            Console.WriteLine("請輸入一串以逗號分隔的數字:");
            string str = Console.ReadLine();
            string[] number = str.Split(',');
            Array.Reverse(number);
            Console.WriteLine($"結果:{String.Join(",", number)}");
            */

            /*
            // 3 迴圈倒置
            /// 用 for 迴圈
            Console.WriteLine("請輸入一串以逗號分隔的數字:");
            string str = Console.ReadLine();
            string[] number = str.Split(',');
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (i != str.Length - 1)
                {
                    Console.Write(",");
                }
                Console.Write(str[i]);
            }
            */

            /*
            // 3 迴圈倒置
            /// 用 手動串接字串
            Console.WriteLine("請輸入一串以逗號分隔的數字:");
            string str = Console.ReadLine();
            string[] number = str.Split(',');
            string output = string.Empty;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (i != str.Length - 1)
                {
                    output += ",";
                }
                output += number[i];
            }
            Console.WriteLine(output);
            */

            /*
            // 4 迴圈倒置
            Console.WriteLine("請輸入一個整數:");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write((number - i) + 1);
                }
                Console.WriteLine();
            }
            */

            /*
            // 5 閏年
            /// 用 DataTime.IsLeapYear()
            Console.WriteLine("請輸入中華民國年份:");
            int year = int.Parse(Console.ReadLine()) + 1911;

            if (DateTime.IsLeapYear(year))
                Console.WriteLine("閏年");
            else
                Console.WriteLine("平年");
            */

            /*
            // 5 閏年
            /// 用 .DayOfYear
            Console.WriteLine("請輸入中華民國年份:");
            int year = int.Parse(Console.ReadLine()) + 1911;
            DateTime endDate = new DateTime(year, 12, 31);

            switch (endDate.DayOfYear)
            {
                case 365:
                    Console.WriteLine("平年");
                    break;
                case 366:
                    Console.WriteLine("閏年");
                    break;
            }
            */

            Console.ReadLine();
        }

        private static string Solution(string v, int u)
        {
            if(v == String.Empty)
            {
                v += u;
            }
            else
            {
                v += ("," + u);
            }
            return v;
        }

        private static bool IsOddNumber(int number)
        {
            if (number % 2 == 0)
                return false;
            else
                return true;
        }
    }
}
