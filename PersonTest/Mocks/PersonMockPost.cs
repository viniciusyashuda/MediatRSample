using System.Threading.Tasks;
using MediatRSample.Application.Models;
using MediatRSample.Infraestructure.Repositories;

namespace PersonTest.Mocks
{
    public static class PersonMockPost
    {
        public static Repository GetRepository()
        {
            Repository repository = new();
            return repository;
        }

        public static async Task GeneratePersonAsync()
        {
            var person = new Person() { Id = 1, Name = "shuda", Age = 18, Gender = 'M' };
            await GetRepository().AddAsync(person);
        }
    }
}
