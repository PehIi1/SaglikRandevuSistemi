using Microsoft.AspNetCore.Mvc;

namespace SaglikRandevuSistemi.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult HastaArayuz()
        {
            return View();
        }
    }
}
