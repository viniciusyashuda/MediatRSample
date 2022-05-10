using System.Threading.Tasks;
using MediatR;
using MediatRSample.Application.Commands;
using MediatRSample.Application.Models;
using MediatRSample.Domain.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Person> _repository;

        public PeopleController(IMediator mediator, IRepository<Person> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
             Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await _repository.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post(CadastratePersonCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EditPersonCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var @object = new DeletePersonCommand { Id = id };
            var result = await _mediator.Send(@object);
            return Ok(result);
        }
    }
}