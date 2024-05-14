using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sp2.Models
{
    [Table("Pay_method")]
    public class Paymethod
    {
        [Required]
        [Column("nm_method")]
        public int nm_method { get; set; }

        [ForeignKey("Payhist")]
        public int id_history { get; set; }
        public Payhist Payhists { get; set; }

        [ForeignKey("Subscription_company")]
        public int id_sub { get; set; }
    }
}
