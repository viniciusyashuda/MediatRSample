using MediatR;

namespace MediatRSample.Application.Notification
{
    public class ErrorNotification : INotification
    {
        public string Exception { get; set; }
        public string ErrorStack { get; set; }
    }
}