using Microsoft.EntityFrameworkCore;

namespace CustomerAPICrud.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
    }
}
