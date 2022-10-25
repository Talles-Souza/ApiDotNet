﻿using Application.DTO;
using Application.Hypermedia.Filters;
using Application.Service.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Controllers
{
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult> Create([FromBody] PersonDTO person)
        {
            var result = await _personService.Create(person);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult> FindByAll()
        {
            var result = await _personService.FindAll();
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);

        }
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult> FindById(int id)
        {
            var result = await _personService.FindById(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult> Update([FromBody] PersonDTO person)
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
