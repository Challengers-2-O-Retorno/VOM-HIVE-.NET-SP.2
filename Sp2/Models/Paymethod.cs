using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sp2.Models
{
    [Table("Pay_method")]
    public class Paymethod
    {
        [Key]
        public int id_method { get; set; }

        [Required]
        [Column("nm_method")]
        public int nm_method { get; set; }

        [ForeignKey("Payhist")]
        public int id_history { get; set; }
        public virtual Payhist Payhist { get; set; }

        [ForeignKey("Subscription_company")]
        public int id_sub { get; set; }
        public virtual Subscriptioncompany Subscription_company { get; set; }
    }
}
