using Microsoft.EntityFrameworkCore;
using okko.uzapi.Models;

namespace okko.uzapi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option) : base(option)
        {
        }
        public DbSet<Persons> Persons { get; set; }
    }
}
