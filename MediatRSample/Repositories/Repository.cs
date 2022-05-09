using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatRSample.Application.Models;

namespace MediatRSample.Repositories
{
    public class Repository : IRepository<Person>
    {
        private static Dictionary<int, Person> people = new();

        public async Task<IEnumerable<Person>> GetAllAsync() =>
            await Task.Run(() => people.Values.ToList());

        public async Task<Person> GetAsync(int id) =>
            await Task.Run(() => people.GetValueOrDefault(id));

        public async Task AddAsync(Person person) =>
            await Task.Run(() => people.Add(person.Id, person));

        public async Task EditAsync(Person person) =>
            await Task.Run(() =>
            {
                people.Remove(person.Id);
                people.Add(person.Id, person);
            });

        public async Task DeleteAsync(int id) =>
            await Task.Run(() => people.Remove(id));
    }
}