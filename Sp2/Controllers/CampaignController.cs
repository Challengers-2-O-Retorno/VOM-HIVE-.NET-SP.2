using Microsoft.AspNetCore.Mvc;
using Sp2.Models;
using Sp2.Repositories;
using Sp2.ViewModels;
using System.Transactions;

namespace Sp2.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ICampaignRepository _campaignRepository;

        private readonly IProductRepository _productRepository;

        public CampaignController(ICampaignRepository campaignRepository, IProductRepository productRepository)
        {
            _campaignRepository = campaignRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var campaigns = _campaignRepository.BuscarTodos();
            var viewModel = new List<CampaignWithProductViewModel>();

            foreach (var campaign in campaigns)
            {
                var product = _productRepository.ListarPorId(campaign.id_product);
                viewModel.Add(new CampaignWithProductViewModel
                {
                    Campaign = campaign,
                    Product = product
                });
            }

            return View(viewModel);
        }

        public IActionResult Criar(int id_company, int id_product)
        {
            var model = new CampaignModel
            {
                id_company = id_company,
                id_product = id_product,
                dt_register = DateTime.Now
            };
            return View(model);
        }

        public IActionResult Editar(int id_campaign)
        {
            CampaignModel campaign = _campaignRepository.ListarPorId(id_campaign);
            return View(campaign);
        }

        public IActionResult ApagarConfirmacao(int id_campaign)
        {
            CampaignModel campaign = _campaignRepository.ListarPorId(id_campaign);
            return View(campaign);
        }
        public IActionResult CampaignProduct(CampaignModel camapaign)
        {
            camapaign.dt_register = DateTime.Now;
            _campaignRepository.Adicionar(camapaign);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id_campaign, int id_product)
        {
            //_productRepository.Apagar(id_product);
            _campaignRepository.Apagar(id_campaign);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(CampaignModel camapaign)
        {
            camapaign.dt_register = DateTime.Now;
            _campaignRepository.Adicionar(camapaign);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(CampaignModel campaign)
        {
            campaign.dt_register = DateTime.Now;
            _campaignRepository.Atualizar(campaign);
            return RedirectToAction("Index");
        }
    }
}
