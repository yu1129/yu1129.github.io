using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220126
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //Lab7_1 印出條件以外的數
            for (int number= 1; number <= 100; number++)
            {
                if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0)
                    continue;
                
                Console.WriteLine(number);
            }
            */

            /*
            //Lab7_2 最大公因數
            ///解法1 : 用迴圈解(從number1開始項1找)
            Console.WriteLine("輸入兩個整數:");
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int gcd = 0;

            if (number1 > number2)
            {
                int temp = number1;
                number1 = number2;
                number2 = temp;
            }
            for (int i = number1; i >= 1; i--)
            {
                if (number1 % i == 0 && number2 % i == 0)
                {
                    gcd = i;
                    break;
                }
            }
            Console.WriteLine($"最大公因數:{gcd}");
            */

            /*
            //Lab7_2 最大公因數
            ///解法2 : 輾轉相除法
            Console.WriteLine("輸入兩個整數:");
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            if (number1 > number2)
            {
                int temp = number1;
                number1 = number2;
                number2 = temp;
            }
            while (true)
            {
                if (number2 == 0)
                    break;
                int temp = number1;
                number1 = number2;
                number2 = temp % number2;
            }
            Console.WriteLine($"最大公因數:{number1}");
            */

            /*
            //Lab7_2 最大公因數
            ///解法3 : 短除法
            Console.WriteLine("輸入兩個整數:");
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int gcd = 1;

            if (number1 > number2)
            {
                int temp = number1;
                number1 = number2;
                number2 = temp;
            }
            for (int i = 2; i <= number1; i++)
            {
                if (number1 % i == 0 && number2 % i == 0)
                {
                    number1 /= i;
                    number2 /= i;
                    gcd *= i;
                    --i;
                }
                //else
                //{
                //    continue;
                //}
            }
            Console.WriteLine($"最大公因數:{gcd}");
            */

            /*
            //Lab8_1 逆著順序輸出
            ///解法1 : 利用迴圈，使陣列反印
            string[] str = new string[3];

            Console.WriteLine("---輸入三段文字:");
            for (int i = 0; i < 3; i++)
            {
                str[i] = Console.ReadLine();
            }

            Console.WriteLine("---輸出:");
            for (int i = 2; i >= 0; i--)
            {
                Console.Write($"{str[i]},");
            }
            //Console.WriteLine(String.Join(",", str));
            */

            /*
            //Lab8_1 逆著順序輸出
            ///解法2 : 使用字元陣列反轉
            string[] str = new string[3];

            Console.WriteLine("--輸入三段文字:");
            for (int i = 0; i < 3; i++)
            {
                str[i] = Console.ReadLine();
            }

            Console.WriteLine("--輸出:");
            for (int i = 0; i < 3; i++)
            {
                char[] strChar = str[i].ToCharArray();
                Array.Reverse(strChar);
                string result = new string(strChar);
                str[i] = result;
                Console.Write(str[i]);
                Console.Write(",");
            }
            //Console.WriteLine(String.Join(",", str));
            */

            /*
            //Lab8_2 切牌
            ///解法1 : 再新增一個新陣列承接
            int[] group = new int[6];
            int[] result = new int[6];

            Console.WriteLine("請輸入6個整數:");
            for (int i = 0; i < 6; i++)
            {
                group[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("原本的順序:");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(group[i]);
                Console.Write(",");
            }
            Console.WriteLine();

            Console.WriteLine("------");

            Console.Write("切牌後順序:");
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        result[i] = group[i];
                        break;
                    case 1:
                        result[i + 1] = group[i];
                        break;
                    case 2:
                        result[i + 2] = group[i];
                        break;
                }
            }
            for (int i = 3; i < 6; i++)
            {
                switch (i)
                {
                    case 3:
                        result[i - 2] = group[i];
                        break;
                    case 4:
                        result[i - 1] = group[i];
                        break;
                    case 5:
                        result[i] = group[i];
                        break;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                Console.Write(result[i]);
                Console.Write(",");
            }
            */

            /*
            //Lab8_2 切牌
            ///解法2 : 利用索引特性，來交錯列印
            int[] group = new int[6];

            Console.WriteLine("請輸入6個整數:");
            for (int i = 0; i < 6; i++)
            {
                group[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("原本的順序:");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(group[i]);
                Console.Write(",");
            }
            Console.WriteLine();

            Console.WriteLine("------");

            Console.Write("切牌後順序:");
            for (int i = 0; i < group.Length/2; i++)
            {
                Console.Write($"{group[i]},{group[i + group.Length/2]},");
            }
            Console.WriteLine();
            */

            /*
            //Lab9_1 印出顏文字
            string str = @"\/";
            Console.WriteLine($"{str}\'\"\'{str}");
            */

            /*
            //Lab9_2 印出河川
            Console.WriteLine("請輸入一個整數:");
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number * 2; i++)
            {
                for(int j = 1; j <= number; j++)
                {
                    if (i % 2 == 0)
                        Console.Write(@"/");
                    else
                        Console.Write(@"\");
                }
                Console.WriteLine();
                
            }
            */

            /*
            //Lab9_ 3 統計數字出現次數
            ///解法1 : 用陣列統計
            Console.WriteLine("請輸入一串數字:");
            string number = Console.ReadLine();
            int[] count = new int[10];

            for (int i = 0; i < number.Length; i++)
            {
                
                int temp = Convert.ToInt32(number[i].ToString());
                count[temp] += 1;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"數字 {i} 出現 {count[i]} 次");
            }
            */

            /*
            //Lab9_ 3 統計數字出現次數
            ///解法2 : 用迴圈統計
            Console.WriteLine("請輸入一串數字:");
            string str = Console.ReadLine();
            int count = 0;

            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == Convert.ToChar(i.ToString()))
                        count += 1;
                }
                Console.WriteLine($"數字 {i} 出現 {count} 次");
                count = 0;
            }
            */

            /*
            //Lab10_1 判斷是否為直角三角形
            CheckIsRightTriangle(3, 4, 5);
            CheckIsRightTriangle(13, 5, 12);
            CheckIsRightTriangle(24, 25, 7);
            CheckIsRightTriangle(9, 40, 41);
            CheckIsRightTriangle(3, 3, 3);
            */

            /*
            //Lab10_2 判斷第幾象限
            FindQuadrant(3.3, 4);
            FindQuadrant(-2, 4.4);
            FindQuadrant(-3.3, -5.5);
            FindQuadrant(2, -5);

            FindQuadrant(2, 0);
            FindQuadrant(0, -5);
            FindQuadrant(0, 0);
            */

            Console.ReadLine();
        }
        static void CheckIsRightTriangle(int a, int b, int c)
        {
            if (a + b > c || b + c > a || a + c > b)
            {
                if ((a * a + b * b == c * c) || (a * a + c * c == b * b) || (b * b + c * c == a * a))
                {
                    Console.WriteLine($"{a}, {b}, {c} 可以組成直角三角形");
                    return;
                }
                Console.WriteLine($"{a}, {b}, {c} 無法組成直角三角形");
            }
        }
        static void FindQuadrant(double a, double b)
        {
            if (a > 0 && b != 0)
            {
                if(b > 0)
                {
                    Console.WriteLine($"({a}, {b}) 屬於第一象限");
                    return;
                }
                Console.WriteLine($"({a}, {b}) 屬於第四象限");
                return;
            }
            else if (a < 0 && b != 0)
            {
                if (b > 0)
                {
                    Console.WriteLine($"({a}, {b}) 屬於第二象限");
                    return;
                }
                Console.WriteLine($"({a}, {b}) 屬於第三象限");
                return;
            }
            else if (a == 0 || b == 0)
                Console.WriteLine($"({a}, {b}) 不屬於任何象限");
            
        }
        
    }
}
