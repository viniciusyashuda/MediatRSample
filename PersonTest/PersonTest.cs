using System.Threading.Tasks;
using MediatRSample.Application.Models;
using PersonTest.Mocks;
using Xunit;

namespace PersonTest
{
    public class PersonTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            await PersonMockPost.GeneratePersonAsync();
            var people = await PersonMockGet.GetAllPeopleAsync();
            var status = false;
            if (people.Count > 0)
                status = true;

            Assert.True(status);
        }

        [Fact]
        public async Task GetTest()
        {
            await PersonMockPost.GeneratePersonAsync();
            var person = await PersonMockGet.GetPersonAsync(1);
            if (person == null)
                person = new Person();

            Assert.Equal(1, person.Id);
        }

        [Fact]
        public async Task PostTest()
        {
            await PersonMockPost.GeneratePersonAsync();
            var personAdded = await PersonMockGet.GetPersonAsync(1);

            Assert.NotNull(personAdded);
        }

        [Fact]
        public async Task EditTest()
        {
            await PersonMockPut.EditPersonAsync();
            var personEdited = await PersonMockGet.GetPersonAsync(1);

            Assert.Equal("vinicius", personEdited.Name);
        }

        [Fact]
        public async Task DeleteTest()
        {
            await PersonMockPost.GeneratePersonAsync();
            await PersonMockDelete.DeletePersonAsync(1);
            var personToDelete = await PersonMockGet.GetPersonAsync(1);

            Assert.Null(personToDelete);
        }
    }
}
