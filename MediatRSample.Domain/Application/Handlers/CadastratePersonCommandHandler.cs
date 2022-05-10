using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Application.Commands;
using MediatRSample.Application.Models;
using MediatRSample.Application.Notification;
using MediatRSample.Domain.Application.Interfaces;

namespace MediatRSample.Application.Handlers
{
    public class CadastratePersonCommandHandler : IRequestHandler<CadastratePersonCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Person> _repository;

        public CadastratePersonCommandHandler(IMediator mediator, IRepository<Person> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(CadastratePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = new() { Name = request.Name, Age = request.Age, Gender = request.Gender };

            try
            {
                var people = await _repository.GetAllAsync();

                if (people.Any())
                    person.Id = people.Last().Id + 1;
                else
                    person.Id = 1;

                await _repository.AddAsync(person);
                await _mediator.Publish(new PersonCadastratedNotification { Id = person.Id, Name = person.Name, Age = person.Age, Gender = person.Gender });
                return await Task.FromResult("Person successfully created!");
            }
            catch (Exception exception)
            {
                await _mediator.Publish(new PersonCadastratedNotification { Id = person.Id, Name = person.Name, Age = person.Age, Gender = person.Gender });
                await _mediator.Publish(new ErrorNotification { Exception = exception.Message, ErrorStack = exception.StackTrace });
                return await Task.FromResult("An error occured while creating person!");
            }
        }
    }
}