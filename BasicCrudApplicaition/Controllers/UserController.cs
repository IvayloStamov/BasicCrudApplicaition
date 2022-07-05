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
    public class UserController : ControllerBase
    {

        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await _context.People.ToListAsync());  
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> Get(int Id)
        {
            User user = await _context.People.FindAsync(Id);
            if(user != null)
            {
                return Ok(user);  
            }
            return BadRequest($"No user with an Id {Id} found.");
        }

         
        [HttpPost]
        public async Task<ActionResult<List<User>>> Add(User input)
        {            
            if(await _context.People.AnyAsync(x => x.Id == input.Id))
            {
                return BadRequest($"There is already a user with the Id {input.Id}");
            }          
            
            _context.People.Add(input);
            await _context.SaveChangesAsync();

            return Ok(await _context.People.ToListAsync());

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<User>>> Delete(int Id)
        {
            var user = await _context.People.FindAsync(Id);
            if (user != null)
            {
                _context.People.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(await _context.People.ToListAsync());
            }
            return BadRequest($"No user with an Id {Id} found.");
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(User input)
        {
            var user = await _context.People.FindAsync(input.Id);
            if(user == null)
            {
                return BadRequest("Person not found");
            }
            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.Age = input.Age;
            user.City = input.City;

            await _context.SaveChangesAsync();

            return Ok(await _context.People.ToListAsync());     
        }
    }
}
