using Microsoft.AspNetCore.Mvc;
using SaglikRandevuSistemi.Filters;

namespace SaglikRandevuSistemi.Controllers
{
    [CustomAuthorization("Hasta")]
    public class HastaController : Controller
    {
        public IActionResult HastaArayuz()
        {
            return View();
        }

        public IActionResult HastaProfil()
        {
            return View();
        }

        public IActionResult AramaFiltresi()
        {
            return View();
        }

        public IActionResult RandevuListeleme()
        {
            return View();
        }
    }
}
