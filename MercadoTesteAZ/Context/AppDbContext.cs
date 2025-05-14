using Microsoft.EntityFrameworkCore;

namespace MarketAzCorp.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
