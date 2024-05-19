using Microsoft.EntityFrameworkCore;
using Sp2.Models;

namespace Sp2.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<ProductModel> Product { get; set; }

        public DbSet<CampaignModel> Campaign { get; set; }

        public DbSet<CompanyModel> Company { get; set; }


        public DbSet<ProfileuserModel> ProfileUser { get; set; }
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyModel>()
                .HasMany(c => c.Campaigns)
                .WithOne(ca => ca.Company)
                .HasForeignKey(ca => ca.id_company)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyModel>()
                .HasMany(c => c.Profile_users)
                .WithOne(pu => pu.Company)
                .HasForeignKey(pu => pu.id_company)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductModel>()
                .HasMany(p => p.Campaigns)
                .WithOne(ca => ca.Product)
                .HasForeignKey(ca => ca.id_product)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
