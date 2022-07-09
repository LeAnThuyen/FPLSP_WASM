using ApiUser.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiUser.Domain.AggregateModels.UserAggregate
{
    public class UserRepo : Entity, IAggregateRoot
    {
        public UserRepo(string externalId, string firstName, string lastName)
        {
            (ExternalId, FirstName, LastName) = (externalId, firstName, lastName);
        }

        [BsonElement("externalId")]
        public string ExternalId { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]

        public string LastName { get; set; }

        public static UserRepo CreateNewUser(string externalId, string firstName, string lastName)
        {
            return new UserRepo(externalId, firstName, lastName);
        }

    }
}
