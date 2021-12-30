using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAllAsync();
        Task<PersonAggregate.Person> Add(PersonAggregate.Person person);
        Task<PersonAggregate.Person> ChangeName(int id, string name);
        Task<bool> Delete(int id);


    }
}
