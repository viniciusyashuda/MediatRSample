using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Application.Notification;

namespace MediatRSample.Application.EventHandlers
{
    public class LogEventHandler : INotificationHandler<PersonCadastratedNotification>, INotificationHandler<PersonEditedNotification>,
                                    INotificationHandler<PersonDeletedNotification>, INotificationHandler<ErrorNotification>
    {

        public Task Handle(PersonCadastratedNotification notification, CancellationToken cancellationToken) =>
            Task.Run(() =>
            {
                Console.WriteLine($"CREATION: '{notification.Id} - {notification.Name} - {notification.Age} - {notification.Gender}'");
            });

        public Task Handle(PersonEditedNotification notification, CancellationToken cancellationToken) =>
            Task.Run(() =>
            {
                Console.WriteLine($"EDITION: '{notification.Id} - {notification.Name} - {notification.Age} - {notification.Gender} - {notification.IsEffective}'");
            });

        public Task Handle(PersonDeletedNotification notification, CancellationToken cancellationToken) =>
            Task.Run(() =>
            {
                Console.WriteLine($"DELETION: '{notification.Id} - {notification.IsEffective}'");
            });

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken) =>
            Task.Run(() =>
            {
                Console.WriteLine($"ERROR: '{notification.Exception} \n {notification.ErrorStack}'");
            });
    }
}