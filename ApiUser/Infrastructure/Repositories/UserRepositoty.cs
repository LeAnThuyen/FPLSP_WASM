using ApiUser.Domain.AggregateModels.UserAggregate;
using ApiUser.Infrastructure.SeedWork;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ApiUser.Infrastructure.Repositories
{
    public class UserRepositoty : BaseRepository<UserRepo>, IUserRepository
    {
        public UserRepositoty(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle, IOptions<ExamSettings> settings, IMediator mediator) : base(mongoClient, clientSessionHandle, settings, mediator, Constants.Collections.User)
        {
        }

        public async Task<UserRepo> GetUserByIdAsync(string externalId)
        {
            var filter = Builders<UserRepo>.Filter.Eq(s => s.ExternalId, externalId);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
