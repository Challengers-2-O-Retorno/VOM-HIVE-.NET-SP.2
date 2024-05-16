using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sp2.Models
{
    [Table("Subscription_company")]
    public class SubscriptioncompanyModel
    {
        [Key]
        [Column("id_sub")]
        public int id_sub { get; set; }

        [Required]
        [Column("value_sub")]
        public decimal value_sub { get; set; }

        [Required]
        [Column("dt_start")]
        public DateTime dt_start { get; set; }

        [Required]
        [Column("dt_end")]
        public DateTime dt_end { get; set; }

        [Required]
        [Column("status")]
        public string? status { get; set; }

        [ForeignKey("Company")]
        public int id_company { get; set; }
        public Company Company { get; set; }
    }
}
