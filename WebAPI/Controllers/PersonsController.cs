using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _service;

        public PersonsController(IService<Person> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var result = await _service.AddAsync(person);
            return Created(string.Empty, result);
        }
    }
}
