using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataList = new List<TestModel>()
            {
                new TestModel() {Id = "C8763", Info = "9527",},
                new TestModel() {Id = "C8763", Info = "7704",},
                new TestModel() {Id = "C8763", Info = "7706",},
                new TestModel() {Id = "C9487", Info = "7706",},
            };

            var result = dataList.GroupBy(d => d.Id).Select(d => new ResultModel { Id = d.Key, Info = d.Select(dd => dd.Info).ToList() }).ToList();

            Console.WriteLine(JsonConvert.SerializeObject(result));

            Console.ReadLine();
        }
    }
    public class TestModel
    {
        public string Id { get; set; }
        public string Info { get; set; }
    }
    public class ResultModel
    {
        public string Id { get; set; }
        public List<string> Info { get; set; }
    }
}
