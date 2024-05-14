using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sp2.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("id_product")]
        public int id_product { get; set; }

        [Required]
        [Column("nm_product")]
        public string? nm_product { get; set; }

        [Required]
        [Column("category_product")]
        public string? category_product { get; set; }

        [InverseProperty("Product")]
        public ICollection<Campaign> Campaigns { get; set; }
    }
}
