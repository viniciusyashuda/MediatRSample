using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatRSample.Application.Models;
using MediatRSample.Infraestructure.Repositories;

namespace PersonTest.Mocks
{
    public class PersonMockGet
    {
        public static Repository GetRepository()
        {
            Repository repository = new();
            return repository;
        }

        public static async Task<Person> GetPersonAsync(int id)
        {
            var person = await GetRepository().GetAsync(id);
            return person;
        }

        public static async Task<List<Person>> GetAllPeopleAsync()
        {
            var people = await GetRepository().GetAllAsync();
            return people.ToList();
        }
    }
}
