using System.Threading.Tasks;
using MediatRSample.Application.Models;
using MediatRSample.Infraestructure.Repositories;

namespace PersonTest.Mocks
{
    public class PersonMockPut
    {
        public static Repository GetRepository()
        {
            Repository repository = new();
            return repository;
        }

        public static async Task EditPersonAsync()
        {
            var person = new Person() { Id = 1, Name = "vinicius", Age = 18, Gender = 'M' };
            await GetRepository().EditAsync(person);
        }
    }
}
