using BasicCrudApplicaition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrudApplicaition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            var people = new List<Person>()
            {
                new Person()
                {
                    Id = 1, FirstName = "Martin", LastName = "Indzhov",
                    Age = 25, City = "Stara Zagora"
                }
            };
            return Ok(people);  
        }
    }
}
