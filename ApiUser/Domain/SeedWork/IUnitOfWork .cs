using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiUser.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
