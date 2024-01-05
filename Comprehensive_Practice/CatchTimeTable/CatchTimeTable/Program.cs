using CatchTimeTable.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using CatchTimeTable.DTO;
using Microsoft.Extensions.DependencyInjection;
using static CatchTimeTable.DTO.SourceData;

HandleData();

var _timer = new System.Threading.Timer(state =>
{
    HandleData();
}, null, 0, 60000);

Console.ReadLine();

async void HandleData()
{
    string apiUrl = "https://trainsmonitor.ntmetro.com.tw/public/api/getCurrentTimetableV2/V";
    string apiKey = "jhPkrAPxa5fH3Chfn4YNgIAQnVZILl2r18hKgmA";
    string userAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Mobile Safari/537.36";

    // 設定POST要傳遞的資料（如果需要）
    //var postData = new { key1 = "value1", key2 = "value2" }; // 這是一個範例，根據實際需求修改
    var postData = new { };

    // 設定Cookie
    var cookies = new System.Net.CookieContainer();
    cookies.Add(new System.Net.Cookie("JSESSIONID", "CCDBC79EDE6BDE0090F04D1C3D2914B", "/", "trainsmonitor.ntmetro.com.tw"));

    // 使用HttpClient發送POST請求
    using (var httpClient = new HttpClient(new HttpClientHandler { CookieContainer = cookies }))
    {
        httpClient.DefaultRequestHeaders.Add("ApiKey", apiKey);
        httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);

        // 如果有需要，將資料轉換成JSON格式
        var content = new StringContent(JsonConvert.SerializeObject(postData), System.Text.Encoding.UTF8, "application/json");

        // 發送POST請求
        var response = await httpClient.PostAsync(apiUrl, content);

        // 檢查回應是否成功
        if (response.IsSuccessStatusCode)
        {
            // 取得回應內容
            string responseBody = await response.Content.ReadAsStringAsync();

            var sourceObj = JsonConvert.DeserializeObject<SourceData>(responseBody);
            var allData = sourceObj.data.gpsData;
            var resultList = new List<TimeTable>();
            //var context = new TimeDataContext();

            for (int i = 0; i < allData.Length; i++)
            {
                if (i < 3)
                {
                    foreach (var property in allData[i].GetType().GetProperties())
                    {
                        var value = (CarPassed)property.GetValue(allData[i]);
                        var temp = new TimeTable();

                        if (value == null)
                            continue;

                        if (value.timeRouteId == 3)
                            resultList.Add(new TimeTable() { RouteId = "V-1", Direction = 0, Stop = property.Name, Time = value.drivingTime, Car = (value.carNum==String.Empty ? null : value.carNum) });
                        else
                            resultList.Add(new TimeTable() { RouteId = "V-2", Direction = 0, Stop = property.Name, Time = value.drivingTime, Car = (value.carNum == String.Empty ? null : value.carNum) });
                    }
                }
                else
                {
                    foreach (var property in allData[i].GetType().GetProperties())
                    {
                        var value = (CarPassed)property.GetValue(allData[i]);
                        var temp = new TimeTable();

                        if (value == null)
                            continue;

                        if (value.timeRouteId == 3)
                            resultList.Add(new TimeTable() { RouteId = "V-1", Direction = 1, Stop = property.Name, Time = value.drivingTime, Car = (value.carNum == String.Empty ? null : value.carNum) });
                        else
                            resultList.Add(new TimeTable() { RouteId = "V-2", Direction = 1, Stop = property.Name, Time = value.drivingTime, Car = (value.carNum == String.Empty ? null : value.carNum) });
                    }
                }
            }

            Console.WriteLine("回應內容: " + JsonConvert.SerializeObject(resultList));
            try
            {
                var serviceProvider = new ServiceCollection().AddDbContext<TimeDataContext>().BuildServiceProvider();

                using (var dbContext = serviceProvider.GetRequiredService<TimeDataContext>())
                {
                    dbContext.AddRange(resultList);
                    dbContext.SaveChanges();
                }

                Console.WriteLine("成功新增資料");
            }
            catch (Exception ex)
            {
                Console.WriteLine("新增資料失敗");
            }
        }
        else
        {
            Console.WriteLine("請求失敗，狀態碼: " + response.StatusCode);
        }
    }
}