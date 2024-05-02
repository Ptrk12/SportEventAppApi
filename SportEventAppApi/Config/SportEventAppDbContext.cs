using Microsoft.EntityFrameworkCore;

namespace SportEventAppApi.Config
{
    public class SportEventAppDbContext : DbContext
    {
        public SportEventAppDbContext(DbContextOptions<SportEventAppDbContext> options) : base(options)
        {
            
        }
    }
}
