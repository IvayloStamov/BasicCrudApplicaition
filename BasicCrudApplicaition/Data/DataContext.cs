using BasicCrudApplicaition.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrudApplicaition.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

    }
}
