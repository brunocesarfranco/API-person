using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private  IPersonService _personService;
        private  IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonDto> Add(PersonRequest personRequest)
        {
            var person = new Person()
            {
                Name = personRequest.Nome
            };

            person = await _personService.Add(person);
            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }

        public async Task<PersonDto> ChangeName(PersonRequest person, int id)
        {
            var personResult = await _personService.ChangeName(id, person.Nome);
            var personDto = _mapper.Map<PersonDto>(personResult);

            return personDto;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _personService.Delete(id);

            return result;
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }
    }
}
