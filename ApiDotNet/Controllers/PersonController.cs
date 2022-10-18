using Application.Service.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Person person)
        {
            var result = await _personService.Create(person);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> FindByAll()
        {
            var result = await _personService.FindAll();
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var result = await _personService.FindById(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Person person)
        {
            var result = await _personService.Update(person);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _personService.Delete(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}
