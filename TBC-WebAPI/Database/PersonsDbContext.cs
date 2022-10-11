using Microsoft.EntityFrameworkCore;
using webApi_test.Models;

namespace TBC_WebAPI.Database
{
    public class PersonsDbContext : DbContext
    {
        public PersonsDbContext(DbContextOptions<PersonsDbContext> options) : base(options) { }

        public PersonsDbContext() { }

        public DbSet<Persons> Persons { get; set; } 
    }
}
