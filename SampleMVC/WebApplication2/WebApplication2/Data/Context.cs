using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { 
        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Test> Test { get; set; }
    }
}
