using BasicCrudApplicaition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BasicCrudApplicaition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
         private static List<Person> people = new List<Person>()
         {
             new Person()
             {
                 Id = 1, FirstName = "Martin", LastName = "Indzhov",
                 Age = 25, City = "Stara Zagora"
             }
         };

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            return Ok(people);  
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Person>> Get(int Id)
        {
            Person person = people.Find(x => x.Id == Id);
            if(person != null)
            {
                return Ok(person);  
            }
            return BadRequest($"No Person with an Id {Id} found.");
        }

         
        [HttpPost]
        public async Task<ActionResult<List<Person>>> Add(Person input)
        {

            
            if(people.Any(x => x.Id == input.Id))
            {
                return BadRequest($"There is already a person with the Id {input.Id}");
            }          
            
            people.Add(input);
            return Ok(people);

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Person>>> Delete(int Id)
        {
            var person = people.Find(x => x.Id == Id);
            if (person != null)
            {
                people.Remove(person);
                return Ok(people);
            }
            return BadRequest($"No Person with an Id {Id} found.");
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Update(Person input)
        {
            var person = people.Find(x => x.Id == input.Id);
            person.FirstName = input.FirstName;
            person.LastName = input.LastName;
            person.Age = input.Age;
            person.City = input.City;

            return Ok(person);
        }
    }
}
