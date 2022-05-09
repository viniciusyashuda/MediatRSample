using MediatR;

namespace MediatRSample.Application.Commands
{
    public class CadastratePersonCommand : IRequest<string>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }
}