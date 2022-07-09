using ApiUser.Domain.AggregateModels.QuestionsAggregate;
using ApiUser.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiUser.Infrastructure.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle, IOptions<ExamSettings> settings, IMediator mediator) : base(mongoClient, clientSessionHandle, settings, mediator, Constants.Collections.Question)
        {
        }
    }
}
