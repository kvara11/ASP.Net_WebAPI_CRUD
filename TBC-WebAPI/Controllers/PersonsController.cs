using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBC_WebAPI.Database;
using webApi_test.Models;

namespace TBC_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonsDbContext _context;
        public PersonsController(PersonsDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_context.Persons);
        }

        [HttpGet("id", Name = "GetByFilter")]
        public IActionResult GetByFilter(string? firstName = null, string? lastName = null, string? number = null)
        {

            var data = _context.Persons.Where(x => x.Firstname == firstName || x.Lastname == lastName || x.IdentityNumber == number).ToList();

            return data == null ? NotFound() : Ok(data);
        }

        [HttpPost(Name = "Insert")]
        public IActionResult Insert(Persons person)
        {
             _context.Persons.Add(person);
             _context.SaveChanges();

            return Ok(person.ID);
        }

        [HttpPut("{id}" , Name = "Update")]
        public IActionResult Update(int id, Persons person)
        {
            if(id != person.ID) return BadRequest();

            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();

        }
    }
}

// same with async

//[HttpGet]
//public async Task<IEnumerable<Persons>> GetAll()
//{
//    return await _context.Persons.ToListAsync();
//}


//[HttpPost]
//public ActionResult AddPerson([FromBody] Persons newPerson)
//{
//    bool success = true;

//    if (success)
//        Created("", newPerson);
//    return BadRequest();
//}


//[HttpGet("{firstName}, {lastName}, {identityNumber}")]
//public async Task<IActionResult> Get([FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string identityNumber)
//{
//    var person = await _context.Persons.FindAsync(firstName, lastName, identityNumber);
//    return person == null ? NotFound() : Ok(person);
//}

//[HttpPut("{id}")]
//public async Task<IActionResult> Update(int id, Persons person)
//{
//    if (id != person.ID) return BadRequest();

//    _context.Entry(person).State = EntityState.Modified;
//    await _context.SaveChangesAsync();
//    return NoContent();

//}