using Authorization_ASP.Net_Core_Database_5._0.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authorization_ASP.Net_Core_Database_5._0.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

       public DbSet<ApplicationUser> Users { get; set; }
    }
}
