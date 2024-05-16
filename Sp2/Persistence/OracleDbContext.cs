using Microsoft.EntityFrameworkCore;
using Sp2.Models;

namespace Sp2.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<CampaignModel> Campaign { get; set; }

        public DbSet<CompanyModel> Company { get; set; }

        public DbSet<PayhistModel> Payhist { get; set; }

        public DbSet<PaymethodModel> Paymethod { get; set; }
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
            
        }
    }
}
