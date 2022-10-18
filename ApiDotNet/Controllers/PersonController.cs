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

        [HttpGet]
        public async Task<ActionResult> FindByAll()
        {
            var result = await _personService.FindAll();
                return Ok(result);

        }
         [HttpPost]  
        public async Task<ActionResult> Create([FromBody]Person person)
        {
            var result = await _personService.Create(person);
            return Ok(result);
            
        }
    }
}
