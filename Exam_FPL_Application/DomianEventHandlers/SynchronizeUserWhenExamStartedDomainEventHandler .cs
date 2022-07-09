using ApiUser.Domain.AggregateModels.UserAggregate;
using ApiUser.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exam_FPL_Application.DomianEventHandlers
{

    //đồng bộ tatasc cả các user khi bắt đầu làm bài thi
    public class SynchronizeUserWhenExamStartedDomainEventHandler : INotificationHandler<ExamStartDomainEvent>
    {
        private readonly IUserRepository _userRepository;
        public SynchronizeUserWhenExamStartedDomainEventHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(ExamStartDomainEvent notification, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(notification.UserId);
            if (user == null)
            {
                _userRepository.StartTransaction();
                user = UserRepo.CreateNewUser(notification.UserId, notification.FirstName, notification.LastName);
                await _userRepository.InsertAsync(user);
                await _userRepository.CommitTransactionAsync(user, cancellationToken);
            }
        }
    }
}
