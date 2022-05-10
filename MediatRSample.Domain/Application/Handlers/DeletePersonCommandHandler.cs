using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Application.Commands;
using MediatRSample.Application.Models;
using MediatRSample.Application.Notification;
using MediatRSample.Domain.Application.Interfaces;

namespace MediatRSample.Application.Handlers
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Person> _repository;

        public DeletePersonCommandHandler(IMediator mediator, IRepository<Person> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteAsync(request.Id);
                await _mediator.Publish(new PersonDeletedNotification { Id = request.Id, IsEffective = true });
                return await Task.FromResult("Person successfully deleted!");
            }
            catch (Exception exception)
            {
                await _mediator.Publish(new PersonDeletedNotification { Id = request.Id, IsEffective = false });
                await _mediator.Publish(new ErrorNotification { Exception = exception.Message, ErrorStack = exception.StackTrace });
                return await Task.FromResult("An error occured while deleting person!");
            }
        }
    }
}