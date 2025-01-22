using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaglikRandevuSistemi.Models;
using SaglikRandevuSistemi.ViewModels;

namespace SaglikRandevuSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext context;

        public HomeController(DataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var doktorlar = context.Doktorlars.ToList();

            ViewData["IsPage"] = "index";
            return View(doktorlar);
        }

        public IActionResult Login()
        {
            ViewData["IsPage"] = "login";
            return View();
        }

        public IActionResult Hakkimizda()
        {
            ViewData["IsPage"] = "footer";
            return View();
        }

        public IActionResult render()
        {
            var roller = this.context.Rollers.Include(r => r.Kullanicilars).Select(r => new RolViewModel
            {
                RolAdi = r.RolAdi,
                Kullanicilar = string.Join(',', r.Kullanicilars.Select(ku => ku.KullaniciAdi))
            });

            return View(roller);
        }
        
        public IActionResult SSS()
        {
            return View();
        }

        public IActionResult HizmetPolitikasi()
        {
            return View();
        }

        public IActionResult GizlilikPolitikasi()
        {
            return View();
        }

    }
}
