using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> FindAllAsync();
        Task<PersonDto> Add(PersonRequest personRequest);
        Task<PersonDto> ChangeName(PersonRequest person, int id);
        Task<bool> Delete(int id);

    }
}