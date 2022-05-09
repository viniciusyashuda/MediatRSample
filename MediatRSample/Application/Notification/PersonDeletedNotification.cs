using MediatR;

namespace MediatRSample.Application.Notification
{
    public class PersonDeletedNotification : INotification
    {
        public int Id { get; set; }
        public bool IsEffective { get; set; }
    }
}
