using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using okko.uzapi.Models;

namespace okko.uzapi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option) : base(option)
        {
        }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<WebImages> WebImages { get; set; }
    }
}
