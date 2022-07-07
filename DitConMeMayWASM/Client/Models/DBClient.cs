using MongoDB.Driver;
using System.Collections.Generic;

namespace DitConMeMayWASM.Models
{
    public class DBClient
    {
        private readonly IMongoCollection<Users> _users;
        public DBClient()
        {

            var client = new MongoClient("mongodb://thuyen:thuyen123@examfpl.cq4ra.mongodb.net/examfpl?serverSelectionTimeoutMS=3000&connectTimeoutMS=3000&socketTimeoutMS=3000");
            var database = client.GetDatabase("Cmsfpldb");
            _users = database.GetCollection<Users>("Cms");
        }


        public List<Users> GetAllUser()
        {
            return _users.Find(c => c.Class == "IT7128812").ToList();

        }
        public string addUser()
        {
            Users users = new Users()
            {

                FullName = "thuyen",
                Class = "IT16302"
            };
            _users.InsertOne(users);
            return "Thêm Thành Công";
        }
    }
}
