using BasicCrudApplicaition.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrudApplicaition.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
        }
    }
}
