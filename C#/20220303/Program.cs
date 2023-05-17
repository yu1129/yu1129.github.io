using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220303
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //影片資料集合
            List<Video> videoList = new List<Video>() {
                new Video() { Name = "天竺鼠車車", Country = "日本", Duration = 2.6, Type = "動漫" },
                new Video() { Name = "鬼滅之刃", Country = "日本", Duration = 25, Type = "動漫" },
                new Video() { Name = "鬼滅之刃-無限列車", Country = "日本", Duration = 100, Type = "電影" },
                new Video() { Name = "甜蜜家園SweetHome", Country = "韓國", Duration = 50, Type = "影集" },
                new Video() { Name = "The 100 地球百子", Country = "歐美", Duration = 48, Type = "影集" },
                new Video() { Name = "冰與火之歌Game of thrones", Country = "歐美", Duration = 60, Type = "影集" },
                new Video() { Name = "半澤直樹", Country = "日本", Duration = 40, Type = "影集" },
                new Video() { Name = "古魯家族：新石代", Country = "歐美", Duration = 90, Type = "電影" },
                new Video() { Name = "角落小夥伴電影版：魔法繪本裡的新朋友", Country = "日本", Duration = 77, Type = "電影" },
                new Video() { Name = "TENET天能", Country = "歐美", Duration = 80, Type = "電影" },
                new Video() { Name = "倚天屠龍記2019", Country = "中國", Duration = 58, Type = "影集" },
                new Video() { Name = "下一站是幸福", Country = "中國", Duration = 45, Type = "影集" },
            };

            //人物資料集合
            List<Person> personList = new List<Person>()
            {
                new Person() { Name = "Bill", CountryPrefer = new List<string>() { "中國", "日本" }, TypePrefer = new List<string>() { "影集" } },
                new Person() { Name = "Jimmy", CountryPrefer = new List<string>() { "日本" }, TypePrefer = new List<string>() { "動漫", "電影" } },
                new Person() { Name = "Andy", CountryPrefer = new List<string>() { "歐美", "日本" }, TypePrefer = new List<string>() { "影集", "電影" } },
            };

            // 1. 找出所有日本的影片名稱
            Console.WriteLine($"{Environment.NewLine}Q: 找出所有日本的影片名稱");
            
            /// 逐一抽出
            var result1 = videoList.Where((x) => x.Country == "日本").Select((x) => x.Name).ToList();
            foreach (string s in result1)
            {
                Console.WriteLine(s);
            }

            /*
            /// Method 寫法
            Console.WriteLine(String.Join("\n", videoList.Where((v) => v.Country == "日本").Select((v) => v.Name)));

            /// Qurey 寫法
            Console.WriteLine(String.Join("\n", from v in videoList
                                                where v.Country == "日本"
                                                select v.Name));
            */

            // 2. 找出所有歐美的影片且類型為"影集"的影片名稱
            Console.WriteLine($"{Environment.NewLine}Q: 找出所有歐美的影片且類型為'影集'的影片名稱");
            
            /// 一個一個取出
            var result2 = videoList.Where((x) => x.Country == "歐美").Where((x) => x.Type == "影集").Select((x) => x.Name);
            foreach (string s in result2)
            {
                Console.WriteLine(s);
            }

            /*
            /// Method 寫法
            Console.WriteLine(String.Join("\n", videoList.Where((x) => x.Country == "歐美" && x.Type == "影集").Select((x) => x.Name)));

            /// Qurey 寫法
            Console.WriteLine(String.Join("\n", from v in videoList
                                                where v.Country == "歐美" && v.Type == "影集"
                                                select v.Name));
            */

            // 3. 是否有影片片長超過120分鐘的影片
            Console.WriteLine($"{Environment.NewLine}Q: 是否有影片片長超過120分鐘的影片");
            
            /// if else 判斷
            var result3 = videoList.Where((x) => x.Duration > 120).Select((x) => x.Name);
            if (result3.Count() == 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                foreach (string s in result3)
                {
                    Console.WriteLine(s);
                }
            }

            /*
            /// 三元運算子
            Console.WriteLine(videoList.Any((x) => x.Duration > 120) ? "是" : "否");
            */

            // 4. 請列出所有人的名稱，並且用大寫英文表示，ex: Bill -> BILL
            Console.WriteLine($"{Environment.NewLine}Q: 請列出所有人的名稱，並且用大寫英文表示");
            
            /// 一個一個取出
            var result4 = personList.Select((x) => x.Name.ToUpper());
            foreach (string s in result4)
            {
                Console.WriteLine(s);
            }

            /*
            /// Method 寫法
            Console.WriteLine(String.Join("\n", personList.Select((x) => $"{x.Name}\t->\t{x.Name.ToUpper()}")));
            */

            // 5. 將所有影片用片長排序(最長的在前)，並顯示排序過的排名以及片名，ex: No1: 天竺鼠車車
            Console.WriteLine($"{Environment.NewLine}Q: 將所有影片用片長排序(最長的在前)，並顯示排序過的排名以及片名");
            
            /// 一個一個取出
            var result5 = videoList.OrderByDescending((x) => x.Duration).ToList();
            int i = 12;
            foreach (Video s in result5)
            {
                Console.Write($"No.{i--} :\t");
                Console.WriteLine(s.Name);
            }

            /*
            /// Qurey 寫法
            Console.WriteLine(String.Join("\n", videoList.OrderByDescending((x) => x.Duration).Select((x, index) => $"No{(index + 1).ToString().PadLeft(2)}: {x.Name}")));
            */

            // 6. 將所有影片進行以"類型"分類，並顯示以下樣式(注意縮排)
            /* 
            動漫:
                天竺鼠車車
                鬼滅之刃
            */
            Console.WriteLine($"{Environment.NewLine}Q: 將所有影片進行以'類型'分類");
            
            /// 一個一個取出
            var result6 = videoList.GroupBy((x) => x.Type, (x) => x.Name);
            foreach (var s in result6)
            {
                Console.WriteLine($"{s.Key}:");
                foreach (var n in s)
                {
                    Console.WriteLine($"\t{n}");
                }
            }

            /*
            /// Method 寫法
            Console.WriteLine(Environment.NewLine, videoList.GroupBy(v => v.Type).Select(g => $"{g.Key}: {string.Concat(g.Select(v => "\n\t" + v.Name))}"));

            /// Qurey 寫法
            Console.WriteLine(Environment.NewLine, from v in videoList
                                                   group v by v.Type into g
                                                   select $"{g.Key}: {string.Concat(g.Select(v => "\n\t" + v.Name))}");
            */

            // 7. 找到第一個喜歡歐美影片的人
            Console.WriteLine($"{Environment.NewLine}Q: 找到第一個喜歡歐美影片的人");
            
            /// 使用 Where
            var result7 = personList.Where((x) => x.CountryPrefer.Contains("歐美")).Select((x) => x.Name).First();
            Console.WriteLine(result7);

            /*
            /// 使用 FirstOrDefault
            Console.WriteLine(personList.FirstOrDefault((x) => x.CountryPrefer.Contains("歐美")).Name);

            /// Qurey 寫法
            Console.WriteLine((from p in personList
                              where p.CountryPrefer.Contains("歐美")
                              select p.Name).FirstOrDefault());
            */

            // 8. 找到每個人喜歡的影片(根據國家以及類型)，ex: Bill: 天竺鼠車車, 倚天屠龍記2019
            Console.WriteLine($"{Environment.NewLine}Q: 找到每個人喜歡的影片");
            
            /// 使用 foreach 找
            foreach (var a in personList)
            {
                IEnumerable<Video> temp = Enumerable.Empty<Video>();

                Console.WriteLine($@"{a.Name}: ");
                foreach (var b in a.CountryPrefer)
                {
                    temp = videoList.Where((x) => x.Country == b);
                    foreach (var c in a.TypePrefer)
                    {
                        var temp1 = temp.Where((x) => x.Type == c);
                        foreach (var d in temp1)
                        {
                            Console.WriteLine($"\t{d.Name}");
                        }
                    }
                }
            }

            /*
            /// 使用 method
            personList.Select((p) => $"{p.Name}: {string.Join(",", videoList.Where((v) => p.CountryPrefer.Contains(v.Country) && p.TypePrefer.Contains(v.Type)).Select((v) => v.Name))}");
            */
            
            //personList.Select(p => $"{p.Name}: {videoList.Where()}");

            /*
            ///使用 建立新清單
            List<PersonTotal> people = new List<PersonTotal>();

            foreach (var a in personList)
            {
                foreach (var b in a.CountryPrefer)
                {
                    foreach (var c in a.TypePrefer)
                    {
                        people.Add(new PersonTotal { Name = a.Name, CountryPrefer = b, TypePrefer = c });
                    }
                }
            }


            var result8 = people.Join
                (videoList, p => p.CountryPrefer, v => v.Country,
                (p, v) => new { name = p.Name, country = p.CountryPrefer, ptype = p.TypePrefer, type = v.Type, film = v.Name })
                .Where((x) => x.ptype == x.type).GroupBy((x) => x.name, (x) => x.film);
            foreach (var e in result8)
            {
                Console.WriteLine($"{e.Key} :");
                foreach (var f in e)
                {
                    Console.WriteLine($"\t{f}");
                }
            }
            */

            //foreach (var e in people)
            //{
            //    Console.Write($"{e.Name} : ");
            //    Console.Write($"{e.CountryPrefer} : ");
            //    Console.Write($"{e.TypePrefer} : ");
            //    Console.WriteLine();
            //}

            // 9. 列出所有類型的影片總時長，ex: 動漫: 100min
            Console.WriteLine($"{Environment.NewLine}Q: 列出所有類型的影片總時長");
            
            /// 一個一個取出
            var result9 = videoList.GroupBy((x) => x.Type, (x) => x.Duration);
            foreach (var s in result9)
            {
                Console.Write($"{s.Key} :");
                double temp1 = s.Sum();
                Console.WriteLine($"\t{temp1}");
            }

            /*
            /// Method 寫法
            Console.WriteLine(string.Join(Environment.NewLine, videoList.GroupBy((x) => x.Type).Select((y) => $"{y.Key}: {y.Sum((x) => x.Duration)}min")));
            
            /// Qurey 寫法
            Console.WriteLine(string.Join(Environment.NewLine, from v in videoList
                                                               group v by v.Type into g
                                                               select $"{g.Key}: {g.Sum(v => v.Duration)}min"));
            */

            // 10. 列出所有國家出產的影片數量，ex: 日本: 3部
            Console.WriteLine($"{Environment.NewLine}Q: 列出所有國家出產的影片數量");
            var result10 = videoList.GroupBy((x) => x.Country, (x) => x.Name);
            foreach (var s in result10)
            {
                Console.Write($"{s.Key} :");
                int count = s.Count();
                Console.WriteLine($"\t{count}");
            }

            /*
            /// Method 寫法
            Console.WriteLine(String.Join(Environment.NewLine, videoList.GroupBy((x) => x.Country).Select((y) => $"{y.Key}: {y.Count()}部")));

            /// Qurey 寫法
            Console.WriteLine(String.Join(Environment.NewLine, from v in videoList
                                                               group v by v.Country into g
                                                               select $"{g.Key}: {g.Count()}部"));
            */


            Console.ReadLine();
        }
    }
}
