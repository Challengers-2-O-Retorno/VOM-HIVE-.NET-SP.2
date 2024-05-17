using Sp2.Models;
using System.ComponentModel.DataAnnotations;

namespace Sp2.ViewModels
{
    public class CampaignViewModel
    {
        [Required(ErrorMessage = "O nome da campanha é obrigatório.")]
        public string nm_campaign { get; set; }

        public CampaignModel CampaignView { get; set; }
        public ProductModel ProductView { get; set; }
    }
}
