using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sp2.Models
{
    [Table("Pay_hist")]
    public class PayhistModel
    {
        [Key]
        [Column("id_history")]
        public int id_history { get; set; }

        [Required]
        [Column("value_pay")]
        public decimal value_pay { get; set; }

        [Required]
        [Column("dt_payment")]
        public DateTime dt_payment { get; set; }

        [Required]
        [Column("dt_due")]
        public DateTime dt_due { get; set; }

        [Required]
        [Column("nfe")]
        public byte[]? nfe { get; set; }

        //[InverseProperty("Paymethod")]
        public ICollection<PaymethodModel> Pay_method { get; set; }
    }
}
