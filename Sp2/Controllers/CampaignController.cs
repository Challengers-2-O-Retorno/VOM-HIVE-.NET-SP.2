using Microsoft.AspNetCore.Mvc;
using Sp2.Models;
using Sp2.Repositories;

namespace Sp2.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignController(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public IActionResult Index()
        {
            List<CampaignModel> campaigns = _campaignRepository.BuscarTodos();
            return View(campaigns);
        }

        public IActionResult Criar(int id_company, int id_product)
        {
            var model = new CampaignModel
            {
                id_campaing = id_company,
                id_product = id_product,
                dt_register = DateTime.Now
            };
            return View(model);
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(CampaignModel camapaign)
        {
            camapaign.dt_register = DateTime.Now;
            _campaignRepository.Adicionar(camapaign);
            return RedirectToAction("Index");
        }
    }
}
