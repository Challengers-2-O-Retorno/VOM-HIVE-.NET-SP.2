using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sp2.Models;
using Sp2.Repositories;

namespace Sp2.Controllers
{
    public class ProfileuserController : Controller
    {
        private readonly IProfileuserRepository _profileRepository;

        public ProfileuserController(IProfileuserRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public IActionResult Index()
        {
            List<ProfileuserModel> profiles = _profileRepository.BuscarTodos();
            return View(profiles);
        }
        public IActionResult Criar(int id_company)
        {
            var model = new ProfileuserModel
            {
                id_company = id_company,
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
        public IActionResult Criar(ProfileuserModel profile)
        {
            profile.dt_register = DateTime.Now;
            _profileRepository.Adicionar(profile);
            return RedirectToAction("Index");
        }
    }
}
