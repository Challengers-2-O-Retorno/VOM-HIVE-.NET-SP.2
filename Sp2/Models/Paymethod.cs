using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sp2.Models
{
    [Table("Pay_method")]
    public class PaymethodModel
    {
        [Key]
        public int id_method { get; set; }

        [Required]
        [Column("nm_method")]
        public int nm_method { get; set; }

        [ForeignKey("Payhist")]
        public int id_history { get; set; }
        public virtual PayhistModel Payhist { get; set; }

        [ForeignKey("Subscription_company")]
        public int id_sub { get; set; }
        public virtual SubscriptioncompanyModel Subscription_company { get; set; }
    }
}
