using ApiUser.Domain.AggregateModels.ExamAggregate;
using ApiUser.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiUser.Infrastructure.Repositories
{
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle, IOptions<ExamSettings> settings, IMediator mediator) : base(mongoClient, clientSessionHandle, settings, mediator, Constants.Collections.Exam)
        {
        }

        public async Task<Exam> GetExamByIdAsync(string id)
        {
            var filter = Builders<Exam>.Filter.Eq(c => c.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Exam>> GetExamListAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }
    }
}
