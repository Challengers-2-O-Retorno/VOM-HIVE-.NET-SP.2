using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sp2.Models
{
    public class CampaignModel
    {
        [Key]
        [Column("id_campaing")]
        public int id_campaing { get; set; }

        [Required]
        [Column("nm_campaing")]
        public string? nm_campaign { get; set; }

        [Required]
        [Column("target")]
        public string? target { get; set; }

        [Required]
        [Column("dt_register")]
        public DateTime dt_register { get; set; }

        //CLOB
        [Required]
        [Column("details")]
        public string? details { get; set; }

        [Required]
        [Column("status")]
        public string? status { get; set; }

        [ForeignKey("Company")]
        public int id_company { get; set; }
        public Company Company { get; set; }

        [ForeignKey("Product")]
        public int id_product { get; set; }
        public Product Product { get; set; }
    }

}
