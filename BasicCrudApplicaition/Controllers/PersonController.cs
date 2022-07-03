using BasicCrudApplicaition.Data;
using BasicCrudApplicaition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BasicCrudApplicaition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly DataContext _context;
        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            return Ok(await _context.People.ToListAsync());  
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Person>> Get(int Id)
        {
            Person person = await _context.People.FindAsync(Id);
            if(person != null)
            {
                return Ok(person);  
            }
            return BadRequest($"No Person with an Id {Id} found.");
        }

         
        [HttpPost]
        public async Task<ActionResult<List<Person>>> Add(Person input)
        {            
            if(await _context.People.AnyAsync(x => x.Id == input.Id))
            {
                return BadRequest($"There is already a person with the Id {input.Id}");
            }          
            
            _context.People.Add(input);
            await _context.SaveChangesAsync();

            return Ok(await _context.People.ToListAsync());

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Person>>> Delete(int Id)
        {
            var person = await _context.People.FindAsync(Id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
                return Ok(await _context.People.ToListAsync());
            }
            return BadRequest($"No Person with an Id {Id} found.");
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Update(Person input)
        {
            var person = await _context.People.FindAsync(input.Id);
            if(person == null)
            {
                return BadRequest("Person not found");
            }
            person.FirstName = input.FirstName;
            person.LastName = input.LastName;
            person.Age = input.Age;
            person.City = input.City;

            await _context.SaveChangesAsync();

            return Ok(await _context.People.ToListAsync());     
        }
    }
}
