using ApiUser.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiUser.Domain.AggregateModels.ExamAggregate
{
    public interface IExamRepository : IRepositoryBase<Exam>
    {

        Task<IEnumerable<Exam>> GetExamListAsync();
        Task<Exam> GetExamByIdAsync(string id);
    }
}
