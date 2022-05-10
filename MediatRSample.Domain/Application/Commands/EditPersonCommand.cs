using MediatR;

namespace MediatRSample.Application.Commands
{
    public class EditPersonCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }
}