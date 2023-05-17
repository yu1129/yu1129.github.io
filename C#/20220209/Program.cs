using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20220209;

namespace _20220209
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //Lab11_1 糖果店
            Candyshop order1 = new Candyshop();
            order1.Storename = "Build店";
            order1.Manager = "Dann";
            order1.List = new string[2] {"棒棒糖", "軟糖"};

            Candyshop order2 = new Candyshop();
            order2.Storename = "School店";
            order2.Manager = "Jimmy";
            order2.List = new string[3] {"沙士糖", "酸莓糖", "可樂糖"};

            order1.Store();
            order2.Store();
            */

            /*
            //Lab11_2 菜單算總價
            Menu order1 = new Menu();
            order1.foods = new Food[2]
            {
                new Food{Name = "便當", Price = 70, Counter = 4},
                new Food{Name = "羹湯", Price = 35, Counter = 3}
            };

            Console.WriteLine(order1.GetTotalPrice());
            */

            /*
            //Lab11_3 對戰
            Role r1 = new Role();
            r1.Name = "小明";
            r1.AttackPower = 3;
            r1.Blood = 12;
            r1.Defense = 3;

            Role r2 = new Role();
            r2.Name = "小美";
            r2.AttackPower = 6;
            r2.Blood = 7;
            r2.Defense = 1;

            Battle(r2, r1);
            */

            Console.ReadLine();
        }
        static void Battle(Role a, Role b)
        {
            do
            {
                b.Blood -= (a.AttackPower - b.Defense);
                if (b.Blood <= 0)
                {
                    Console.WriteLine($"{a.Name}攻擊{b.Name}，造成{a.AttackPower - b.Defense}損傷，{b.Name}死亡");
                    break;
                }
                else
                {
                    Console.WriteLine($"{a.Name}攻擊{b.Name}，造成{a.AttackPower - b.Defense}損傷，{b.Name}剩下{b.Blood}血量");
                }
                a.Blood -= (b.AttackPower - a.Defense);
                if (a.Blood <= 0)
                {
                    Console.WriteLine($"{b.Name}攻擊{a.Name}，造成{b.AttackPower - a.Defense}損傷，{a.Name}死亡");
                    break;
                }
                else
                {
                    Console.WriteLine($"{b.Name}攻擊{a.Name}，造成{b.AttackPower - a.Defense}損傷，{a.Name}剩下{a.Blood}血量");
                }
            }
            while (a.Blood > 0 && b.Blood > 0);
        }
    }
    public class Candyshop
    {
        public string Storename { get; set; }
        public string Manager { get; set; }
        public string[] List { get; set; }
        public void Store()
        {
            Console.WriteLine($"店名 : {Storename}");
            Console.WriteLine($"店長 : {Manager}");
            Console.WriteLine($"糖果清單 : \n\t{String.Join("\n\t", List)}");
            
            Console.WriteLine("-------------------");
        }
    }
    public class Menu
    {
        public Food[] foods { get; set; }

        public int GetTotalPrice()
        {
            int total = 0;

            foreach (Food food in foods)
            {
                total += food.CalculateSubTotal();
            }
            return total;
        }
    }
    public class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Counter { get; set; }

        public int CalculateSubTotal()
        {
            return Price * Counter;
        }
    }
    public class Role
    {
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public int Blood { get; set; }
        public int Defense { get; set; }
    }
}
