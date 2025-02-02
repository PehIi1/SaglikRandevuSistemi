using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
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
            if (KullaniciAd == null || Parola == null)
            {
                TempData["ErrorMessage"] = "Boş bırakılan yerleri doldurunuz!";
                return RedirectToAction("Login", "Home");
            }

            var kullanici = context.Kullanicilars
                .FirstOrDefault(ku => ku.KullaniciAdi == KullaniciAd);

            if (kullanici == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı adı hatalıdır! Lütfen tekrar deneyiniz.";
                return RedirectToAction("Login");
            }

            if (!BCrypt.Net.BCrypt.Verify(Parola, kullanici.Parola))
            {
                TempData["ErrorMessage"] = "Parola hatalıdır! Lütfen tekrar deneyiniz.";
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
        public IActionResult Register(string KayitKullaniciAdi, string KayitParola, string KayitTekrarParola)
        {
            if (KayitKullaniciAdi == null || KayitParola == null)
            {
                TempData["ErrorMessage"] = "Boş bırakılan yerleri doldurunuz!";
                return RedirectToAction("Login", "Home");
            }
            if (context.Kullanicilars.Any(ku => ku.KullaniciAdi == KayitKullaniciAdi))
            {
                TempData["ErrorMessage"] = "Bu kullanıcı adı zaten alınmış, Lütfen başka bir tane deneyiniz!";
                return RedirectToAction("Login", "Home");
            }
            if (KayitParola != KayitTekrarParola)
            {
                TempData["ErrorMessage"] = "Girdiğiniz parolalar eşleşmiyor!";
                return RedirectToAction("Login", "Home");
            }
            if (KayitParola.Length < 8 || KayitParola.Length > 20)
            {
                TempData["ErrorMessage"] = "Parola en az 8, en fazla 20 karakterli olabilir!";
                return RedirectToAction("Login", "Home");
            }



            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(KayitParola);

            var yenikullanici = new Kullanicilar
            {
                KullaniciAdi = KayitKullaniciAdi,
                Parola = hashedPassword,
                RolID = 2
            };

            context.Kullanicilars.Add(yenikullanici);
            context.SaveChanges();

            var yenihasta = new Hastalar
            {
                KullaniciID = yenikullanici.KullaniciID
            };

            context.Hastalars.Add(yenihasta);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Kaydınız oluşturulmuştur! Artık giriş yapabilirsiniz.";


            return RedirectToAction("Login", "Home");
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
