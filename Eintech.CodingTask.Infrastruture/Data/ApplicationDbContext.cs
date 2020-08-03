using Eintech.CodingTask.Infrastruture.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eintech.CodingTask.Infrastruture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
