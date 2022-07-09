using ApiUser.Domain.SeedWork;
using System.Threading.Tasks;

namespace ApiUser.Domain.AggregateModels.ExamResultAggregate
{
    public interface IExamResultRepository : IRepositoryBase<ExamResult>
    {
        Task<ExamResult> GetDetails(string userId, string examId);
    }
}
