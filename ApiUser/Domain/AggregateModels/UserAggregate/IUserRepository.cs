using ApiUser.Domain.SeedWork;
using System.Threading.Tasks;

namespace ApiUser.Domain.AggregateModels.UserAggregate
{
    public interface IUserRepository : IRepositoryBase<UserRepo>
    {
        Task<UserRepo> GetUserByIdAsync(string externalId);
    }
}
