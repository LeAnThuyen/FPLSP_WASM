using ApiUser.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiUser.Domain.AggregateModels.QuestionsAggregate
{
    public class Answer : Entity
    {
        public Answer(string id, string content, bool isCorrect = false) => (Id, Content, IsCorrect) = (id, content, isCorrect);

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}
