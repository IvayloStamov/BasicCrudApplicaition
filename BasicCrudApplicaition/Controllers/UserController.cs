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
            return Ok(await _context.Users.ToListAsync());  
        }

        [HttpGet("{Id}/{Name}")]
        public async Task<ActionResult<User>> Get(int Id, string Name)
        {
            User user = await _context.Users.FindAsync(Id);
            if(user != null)
            {
                return Ok(user);  
            }
            return BadRequest($"No user with an Id {Id} found.");
        }

         
        [HttpPost]
        public async Task<ActionResult<List<User>>> Add(User input)
        {            
            if(await _context.Users.AnyAsync(x => x.UserId == input.UserId))
            {
                return BadRequest($"There is already a user with the Id {input.UserId}");
            }          
            
            _context.Users.Add(input);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<User>>> Delete(int Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(await _context.Users.ToListAsync());
            }
            return BadRequest($"No user with an Id {Id} found.");
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(User input)
        {
            var user = await _context.Users.FindAsync(input.UserId);
            if(user == null)
            {
                return BadRequest("Person not found");
            }
            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.Age = input.Age;
            user.City = input.City;

            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());     
        }
    }
}
