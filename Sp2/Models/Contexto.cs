using Microsoft.EntityFrameworkCore;

namespace Sp2.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
}
