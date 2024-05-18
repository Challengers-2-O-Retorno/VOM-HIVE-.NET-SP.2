using Microsoft.AspNetCore.Mvc;
using Sp2.Models;
using Sp2.Repositories;

namespace Sp2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            List<ProductModel> products = _productRepository.BuscarTodos();
            return View(products);
        }

        [HttpGet]
        public IActionResult Criar(int id_company)
        {
            ViewBag.id_company = id_company;
            return View();
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
        public IActionResult Criar(ProductModel product, int id_company)
        {
            _productRepository.Adicionar(product);

            int id_product = product.id_product;

            return RedirectToAction("Criar", "Campaign", new {id_product = id_product, id_company = id_company});
        }
    }
}
