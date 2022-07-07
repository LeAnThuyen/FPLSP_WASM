using ApiUser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private List<Users> lst;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private IMongoCollection<Users> _users;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<Users>> GetAllCustomersAsync()
        {
            //for testing purpose
            lst = new List<Users>();
            Users user = new Users()
            {
                Id = "1",
                Class = "IT1212",
                FullName = "AnhThuyen"
            };
            Users user2 = new Users()
            {
                Id = "2",
                Class = "IT112",
                FullName = "Fucking"
            };
            lst.Add(user);
            lst.Add(user2);
            var list = (from s in lst select new Users { Id = s.Id, Class = s.Class, FullName = s.FullName }).ToList();
            return list;

            //return await _service.GetAllCustomersAsync();
        }

        [HttpGet]
        [Route("mongo")]
        public async Task<IEnumerable<Users>> GetAllUser()
        {
            //for testing purpose

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://thuyen:thuyen123@examfpl.cq4ra.mongodb.net/examfpl?retryWrites=true&w=majority");

            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
            };

            var client2 = new MongoClient(settings);
            var lst = client2.GetDatabase("Cmsfpldb");
            var sss = lst.GetCollection<Users>("Cms");
            var yourFilter = Builders<Users>.Filter.Where(c => c.FullName == "anhthuyendeptrai");
            return sss.Find(yourFilter).ToList();

        }
        [HttpPost]
        [Route("mongoadd")]
        public async Task<string> Add(Users us)
        {
            //for testing purpose

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://thuyen:thuyen123@examfpl.cq4ra.mongodb.net/examfpl?retryWrites=true&w=majority");

            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
            };

            var client2 = new MongoClient(settings);
            var lst = client2.GetDatabase("Cmsfpldb");
            var sss = lst.GetCollection<Users>("Cms");
            await sss.InsertOneAsync(us);
            return "Thêm Thành Công";

        }
    }
}
