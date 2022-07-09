using MediatR;

namespace ApiUser.Domain.Events
{
    public class ExamStartDomainEvent : INotification
    {
        public ExamStartDomainEvent(string userId, string firstName, string lastName)
           => (UserId, FirstName, LastName) = (userId, firstName, lastName);
        public string UserId { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
