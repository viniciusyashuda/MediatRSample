using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Application.Commands;
using MediatRSample.Application.Models;
using MediatRSample.Application.Notification;
using MediatRSample.Repositories;

namespace MediatRSample.Application.Handlers
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Person> _repository;

        public EditPersonCommandHandler(IMediator mediator, IRepository<Person> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            Person person = new() { Id = request.Id, Name = request.Name, Age = request.Age, Gender = request.Gender };

            try
            {
                await _repository.EditAsync(person);
                await _mediator.Publish(new PersonEditedNotification { Id = request.Id, Name = request.Name, Age = request.Age, Gender = request.Gender, IsEffective = true });
                return await Task.FromResult("Person successfully edited!");
            }
            catch (Exception exception)
            {
                await _mediator.Publish(new PersonEditedNotification { Id = request.Id, Name = request.Name, Age = request.Age, Gender = request.Gender, IsEffective = false });
                await _mediator.Publish(new ErrorNotification { Exception = exception.Message, ErrorStack = exception.StackTrace });
                return await Task.FromResult("An error occured while editing person!");
            }

        }
    }
}