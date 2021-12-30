using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

        }

        public async Task<Person> Add(Person person)
        {
            return await _personRepository.Add(person);
        }

        public Task<Person> ChangeName(int id, string name)
        {
            var person = _personRepository.ChangeName(id, name);

            return person;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _personRepository.Delete(id);

            return result;
        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();
    }
}
