using MongoDB.Bson.Serialization.Attributes;

namespace DitConMeMayWASM.Models
{
    public class Users
    {

        [BsonId]


        public string FullName { get; set; }
        public string Class { get; set; }

    }
}
