using Eintech.CodingTask.Domain.Interfaces;
using Eintech.CodingTask.Domain.Models;
using Eintech.CodingTask.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eintech.CodingTask.WebApp.Controllers
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

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<PersonModel> Get()
        {
            return _personService.GetAll();
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post(PersonApi model)
        {
            if (!ModelState.IsValid)
                return;

            _personService.Add(model.Name);
        }
    }
}
