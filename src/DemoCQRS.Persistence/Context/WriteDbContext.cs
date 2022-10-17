using DemoCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoCQRS.Write.Context
{
    public class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options)
           : base(options)
        {
        }
        public DbSet<Person> People { get; set; }
    }
}
