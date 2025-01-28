using Microsoft.AspNetCore.Mvc;
using SaglikRandevuSistemi.Filters;

namespace SaglikRandevuSistemi.Controllers
{
    [CustomAuthorization("Doktor")]
    public class DoktorController : Controller
    {
        public IActionResult DoktorArayuz()
        {
            return View();
        }
        public IActionResult DoktorProfil()
        {
            return View();
        }
    }
}
