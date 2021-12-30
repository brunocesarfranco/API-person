using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Person> Add(Person person) 
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return person;

        }

        public async Task<Person> ChangeName(int id, string name)
        {
            var person = await _context.Person.FirstOrDefaultAsync(e => e.BusinessEntityID == id);

            if(person == null)
            {
                return null;
            }

            person.Name = name;
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> Delete(int id)
        {
            var person = await _context.Person.FirstOrDefaultAsync(e => e.BusinessEntityID == id);
            
            if (person == null)
            {
                return false;
            }
            _context.Person.Remove(person);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.Run(() => _context.Person);
    }
}
