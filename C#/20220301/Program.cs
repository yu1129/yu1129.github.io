using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220301
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // 1 序列倒置
            /// 拆開寫
            Console.WriteLine("請輸入一串以逗號分隔的數字:");
            string str = Console.ReadLine();
            List<string> result = str.Split(',').ToList();;
            result.Reverse();
            Console.WriteLine($"結果:{String.Join(",", result)}");
            */

            /*
            // 1 序列倒置
            /// 融合成一行
            Console.WriteLine("請輸入一串以逗號分隔的數字:");
            string str = Console.ReadLine();
            Console.WriteLine($"結果:{String.Join(",", str.Split(',').Reverse())}");
            */

            /*
            // 2 序列倒置
            /// 使用 Enumerable.Repeat
            Console.WriteLine("請輸入一個正數 :");
            int number = int.Parse(Console.ReadLine());
            //var result = Enumerable.Range(1, number);
            //result = result.Reverse();
            //for (int i = 1; i <= number; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write(result.ElementAt(i - 1));
            //    }
            //    Console.WriteLine();
            //}

            for (int i = 1; i <= number; i++)
            {
                foreach (int r in Enumerable.Repeat(number - i + 1, i))
                {
                    Console.Write(r);
                }
                Console.WriteLine();
            }
            */

            /*
            // 2 序列倒置
            /// 使用 Enumerable.Range() 和 Enumerable.Repeat()
            Console.WriteLine("請輸入一個正數 :");
            int number = int.Parse(Console.ReadLine());

            var rows = Enumerable.Range(1, number).Select((x) => Enumerable.Repeat(number + 1 - x, x));

            var rows_nagative = Enumerable.Range(-number, number).Select((x) => Enumerable.Repeat(-x, number + 1 - (-x)));
            */

            /*
            // 3 奇偶判斷
            /// 使用 ElementA()
            Console.WriteLine("請輸入一串以逗號分隔的數字字串:");
            string str = Console.ReadLine();
            List<string> numberStr = str.Split(',').ToList();
            List<int> number = new List<int>();
            List<int> odd = new List<int>();
            List<int> notOdd = new List<int>();

            for (int i = 0; i < numberStr.Count; i++)
            {
                number.Add(int.Parse(numberStr.ElementAt(i)));
            }
            number.Sort();

            foreach (int s in number)
            {
                if (IsOddNumber(s))
                    odd.Add(s);
                else
                    notOdd.Add(s);
            }

            Console.WriteLine($"奇數:{String.Join(",", odd)}");
            Console.WriteLine($"偶數:{String.Join(",", notOdd)}");
            */

            /*
            // 3 奇偶判斷
            /// 使用 GroupBy()
            Console.WriteLine("請輸入一串以逗號分隔的數字字串:");
            string str = Console.ReadLine();
            var splited = str.Split(',');
            var groups = splited.Select(x => int.Parse(x)).OrderBy(num => num).GroupBy(num => num % 2);

            Console.WriteLine(string.Join(Environment.NewLine, groups.Select((g) => $"{(g.Key == 0 ? "偶數" : "奇數")} : {string.Join(",", g)}")));
            */
           

            Console.ReadLine();
        }

        private static bool IsOddNumber(int s)
        {
            if (s % 2 == 0)
                return false;
            else
                return true;
        }
    }
}
