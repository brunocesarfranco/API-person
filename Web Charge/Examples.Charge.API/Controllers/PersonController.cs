using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
using Examples.Charge.Application.Dtos;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {

        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Response(null);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Post([FromBody] PersonRequest personRequest) 
        {  
            var response = await _facade.Add(personRequest);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDto>> Put([FromBody] PersonRequest personRequest, int id)
        {
            var response = await _facade.ChangeName(personRequest, id);
            if (response != null)
            {
                return Ok(response);            
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _facade.Delete(id);
            if (result) 
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        } 
    }
}
