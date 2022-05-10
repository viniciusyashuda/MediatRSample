using MediatR;

namespace MediatRSample.Application.Notification
{
    public class PersonEditedNotification : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public bool IsEffective { get; set; }
    }
}
