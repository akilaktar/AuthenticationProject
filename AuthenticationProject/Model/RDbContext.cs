using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationProject.Model
{
    public class RDbContext : IdentityDbContext
    {
        public RDbContext(DbContextOptions<RDbContext> options):base(options)
        {
                
        }
        public DbSet<Register> Register { get; set; }

    }
}
