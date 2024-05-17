using Microsoft.AspNetCore.Mvc;
using Sp2.Models;
using Sp2.Repositories;

namespace Sp2.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public IActionResult Index()
        {
            List<CompanyModel> companies = _companyRepository.BuscarTodos();
            return View(companies);
        }
        public IActionResult Criar()
        {
            var model = new ProfileuserModel
            {
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
        public IActionResult Criar(CompanyModel company)
        {
            company.dt_register = DateTime.Now;
            _companyRepository.Adicionar(company);
            return RedirectToAction("Index");
        }
    }
}
