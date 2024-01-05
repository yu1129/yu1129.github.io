using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Models;
using MongoDB.Models.MongoDB_DataModel;
using System.Diagnostics;

namespace MongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMongoDatabase _db;

        public HomeController(ILogger<HomeController> logger, IMongoDatabase db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TestMongoDB()
        {
            var collection = _db.GetCollection<Student>("students");
            var documents = await collection.Find(x => true).ToListAsync();

            return View(documents);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
