using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220505
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // 1 費氏數列
            /// 解法 1
            int number = 1;
            while (true)
            {
                int i = cal(number);

                if (i >= 1836311903)
                {
                    Console.Write(i.ToString());
                    break;
                }
                //else if (i == 1836311903)
                //{
                //}
                else
                {
                    Console.Write(i.ToString() + ",");
                }

                number++;

            }

            ///解法 2
            int A = 0;
            int X = 1;
            while(X > 0)
            {
                Console.WriteLine(X);

                X += A;
                A = X - A;
            }
            */

            /*
            // 4 字串替換
            /// 解法 1
            string[] numberChinese = new string[] { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            char[] number = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            string numberString = Console.ReadLine();
            char[] numberArray = numberString.ToCharArray();
            string[] result = new string[numberString.Length];

            for (int i = 0; i < numberString.Length; i++)
            {
                result[i] = numberChinese[Array.IndexOf(number, numberArray[i])].ToString();
                Console.Write(result[i].ToString());
            }

            /// 解法 2
            string input = Console.ReadLine();
            List<string> zhTw_Number = new List<string>{ "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            var ans2 = input;
            for (int i = 0; i < 10; i++)
            {
                ans2 = ans2.Replace(i.ToString(), zhTw_Number[i]);
            }

            /// 解法 3
            var ans3 = input.Select(c =>
                                zhTw_Number[int.Parse(c.ToString())]
                                //zhTw_number[(int)char.GetNumbericValue(c)]
                                //zhTw_Number[cal - '0']
                                );

            /// 解法 4
            Dictionary<char, string> zhTw_Number2 = new Dictionary<char, string>
            {
                {'0', "零"}, {'1', "一"}, {'2', "二"}, {'3', "三"}, {'4', "四"}, {'5', "五"}, {'6', "六"}, {'7', "七"}, {'8', "八"}, {'9', "九"}
            };
            */

            
            // 6 簡單數學計算
            /// 解法 1
            int max = int.Parse(Console.ReadLine());
            int result = 0;

            while (true)
            {
                if (max <= 1)
                {
                    Console.WriteLine("請重新輸入");
                    max = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i <= max; i++){
                if(i % 2 == 0)
                {
                    result += (i * -1);
                }
                else
                {
                    result += i;
                }
            }
            Console.WriteLine(result);

            /// 解法 2
            int pairs = max / 2;
            int ans = -pairs;

            if (max % 2 != 0)
            {
                ans += max;
            }

            




            Console.ReadLine();
        }
        static int cal(int number)
        {
            if (number == 1 || number == 2)
            {
                return 1;
            }
            else
            {
                return cal(number - 1) + cal(number - 2);
            }
        }
    }
}
