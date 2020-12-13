using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Context
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {
        }

        public DbSet<Zaiko> Zaiko { get; set; }

        public DbSet<Staff> Staff { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zaiko>()
                .HasKey(z => z.ZaikoCode);
            modelBuilder.Entity<Staff>()
                .HasKey(s => s.Seq_id);
        }
    }
}
