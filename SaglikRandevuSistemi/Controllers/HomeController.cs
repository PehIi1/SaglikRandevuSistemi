using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            if (HttpContext.Session.GetString("UserRole") != null)
            {
                var role = HttpContext.Session.GetString("UserRole");
                if (role == "Admin") return RedirectToAction("Index", "Admin");
                if (role == "Hasta") return RedirectToAction("HastaArayuz", "Hasta");
                if (role == "Doktor") return RedirectToAction("DoktorArayuz", "Doktor");
            }

            ViewData["IsPage"] = "index";
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserRole") != null)
            {
                var role = HttpContext.Session.GetString("UserRole");
                if (role == "Admin") return RedirectToAction("Index", "Admin"); 
                if (role == "Hasta") return RedirectToAction("HastaArayuz", "Hasta"); 
                if (role == "Doktor") return RedirectToAction("DoktorArayuz", "Doktor");
            }

            ViewData["IsPage"] = "login";
            return View();
        }
        [HttpPost]
        public IActionResult Login(string KullaniciAd, string Parola)
        {
            var kullanici = context.Kullanicilars
                .FirstOrDefault(ku => ku.KullaniciAdi == KullaniciAd && ku.Parola == Parola);

            if (kullanici == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı adı veya parola hatalıdır.";
                return RedirectToAction("Login");
            }

            var RolAdi = context.Rollers
                .Where(r => r.RolID == kullanici.RolID)
                .Select(r => r.RolAdi)
                .FirstOrDefault();
            if (RolAdi == null)
            {
                TempData["ErrorMessage"] = "Kullanıcıya atanmış bir rol bulunamadı.";
                return View();
            }

            HttpContext.Session.SetString("UserRole", RolAdi);

            if (kullanici.RolID == 1)
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (kullanici.RolID == 2)
            {
                var hasta = context.Hastalars.FirstOrDefault(h => h.KullaniciID == kullanici.KullaniciID);
                HttpContext.Session.SetString(
                    "HastaBilgi",
                    JsonConvert.SerializeObject(hasta, new JsonSerializerSettings
                    {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }));
                return RedirectToAction("HastaArayuz", "Hasta");
            }
            else if (kullanici.RolID == 3)
            {
                var doktor = context.Doktorlars.FirstOrDefault(d => d.KullaniciID == kullanici.KullaniciID);
                HttpContext.Session.SetString(
                    "DoktorBilgi",
                    JsonConvert.SerializeObject(doktor, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling= ReferenceLoopHandling.Ignore
                    }));
                return RedirectToAction("DoktorArayuz", "Doktor");
            }


            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult Login(string KullaniciAd, string Parola, string TekrarParola)
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Hakkimizda()
        {
            ViewData["IsPage"] = "footer";
            return View();
        }
        
        public IActionResult SSS()
        {
            ViewData["IsPage"] = "footer";
            return View();
        }

        public IActionResult HizmetPolitikasi()
        {
            ViewData["IsPage"] = "footer";
            return View();
        }

        public IActionResult GizlilikPolitikasi()
        {
            ViewData["IsPage"] = "footer";
            return View();
        }

    }
}
