using System.Linq;
using System.Threading.Tasks;
using MediatRSample.Application.Models;
using MediatRSample.Repositories;
using PersonTest.Generate;
using Xunit;

namespace PersonTest
{
    public class PersonTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            await PersonMockGenerate.GeneratePersonAsync();
            var people = await PersonMockGenerate.GetAllPeopleAsync();
            var status = false;
            if (people.Count > 0)
                status = true;

            Assert.True(status);
        }

        [Fact]
        public async Task GetTest()
        {
            await PersonMockGenerate.GeneratePersonAsync();
            var person = await PersonMockGenerate.GetPersonAsync(1);
            if (person == null)
                person = new Person();

            Assert.Equal(1, person.Id);
        }

        [Fact]
        public async Task PostTest()
        {
            await PersonMockGenerate.GeneratePersonAsync();
            var personAdded = await PersonMockGenerate.GetPersonAsync(1);

            Assert.NotNull(personAdded);
        }

        [Fact]
        public async Task EditTest()
        {
            await PersonMockGenerate.EditPersonAsync();
            var personEdited = await PersonMockGenerate.GetPersonAsync(1);

            Assert.Equal("vinicius", personEdited.Name);
        }

        [Fact]
        public async Task DeleteTest()
        {
            await PersonMockGenerate.GeneratePersonAsync();
            await PersonMockGenerate.DeletePersonAsync(1);
            var personToDelete = await PersonMockGenerate.GetPersonAsync(1);

            Assert.Null(personToDelete);
        }
    }
}
