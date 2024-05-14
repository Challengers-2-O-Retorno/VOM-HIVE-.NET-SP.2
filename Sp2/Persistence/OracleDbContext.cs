using Microsoft.EntityFrameworkCore;
using Sp2.Models;

namespace Sp2.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Campaign> Campaign { get; set; }

        public DbSet<Payhist> Payhist { get; set; }

        public DbSet<Paymethod> Paymethod { get; set; }
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
            
        }
    }
}
