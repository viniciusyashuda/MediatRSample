using System.Threading.Tasks;
using MediatRSample.Infraestructure.Repositories;

namespace PersonTest.Mocks
{
    public class PersonMockDelete
    {
        public static Repository GetRepository()
        {
            Repository repository = new();
            return repository;
        }

        public static async Task DeletePersonAsync(int id)
        {
            var personToDelete = await PersonMockGet.GetPersonAsync(id);
            await GetRepository().DeleteAsync(personToDelete.Id);
        }
    }
}
