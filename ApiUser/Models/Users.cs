using MongoDB.Bson.Serialization.Attributes;

namespace ApiUser.Models
{
    public class Users
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Class { get; set; }

    }
}
