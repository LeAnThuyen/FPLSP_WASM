using ApiUser.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiUser.Domain.AggregateModels.CategoryAggregate
{
    public class Category : Entity
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("urlPath")]
        public string UrlPath { get; set; }//dùng để tìm đường dẫn
    }
}
