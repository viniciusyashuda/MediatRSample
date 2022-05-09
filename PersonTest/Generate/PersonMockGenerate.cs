using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatRSample.Application.Models;
using MediatRSample.Repositories;

namespace PersonTest.Generate
{
    public static class PersonMockGenerate
    {
        public static IRepository<Person> GetRepository()
        {
            IRepository<Person> repository = new Repository();
            return repository;
        }

        public static async Task GeneratePersonAsync()
        {
            var person = new Person() { Id = 1, Name = "shuda", Age = 18, Gender = 'M' };
            await GetRepository().AddAsync(person);
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

        public static async Task EditPersonAsync()
        {
            var person = new Person() { Id = 1, Name = "vinicius", Age = 18, Gender = 'M' };
            await GetRepository().EditAsync(person);
        }

        public static async Task DeletePersonAsync(int id)
        {
            var personToDelete = await GetPersonAsync(id);
            await GetRepository().DeleteAsync(personToDelete.Id);
        }
    }
}
