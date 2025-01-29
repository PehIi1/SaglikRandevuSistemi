using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaglikRandevuSistemi.Filters;
using SaglikRandevuSistemi.Models;

namespace SaglikRandevuSistemi.Controllers
{
    [CustomAuthorization("Doktor")]
    public class DoktorController : Controller
    {
        public readonly DataContext context;

        public DoktorController(DataContext dataContext)
        {
            this.context = dataContext;
        }

        public IActionResult DoktorArayuz()
        {
            return View();
        }
        public IActionResult DoktorProfil()
        {
            var doktorJson = HttpContext.Session.GetString("DoktorBilgi");
            if (string.IsNullOrEmpty(doktorJson))
            {
                TempData["Error"] = "Session yok, hasta bilgileri bulunamadi";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Cinsiyetler = context.Cinsiyetlers.ToList();

            var doktor = JsonConvert.DeserializeObject<Doktorlar>(doktorJson);

            doktor.Klinikler = context.Kliniklers.FirstOrDefault(kl => kl.KlinikID == doktor.KlinikID);
            doktor.Hastaneler = context.Hastanelers.FirstOrDefault(hs => hs.HastaneID == doktor.HastaneID);

            return View(doktor);
        }

        public IActionResult ProfilGuncelle(Doktorlar model)
        {
            var doktor = context.Doktorlars.FirstOrDefault(d => d.DrID == model.DrID);
            if (doktor != null)
            {
                doktor.DrAdi = model.DrAdi;
                doktor.DrSoyadi = model.DrSoyadi;
                doktor.DrYas = model.DrYas;
                doktor.DrTel = model.DrTel;
                doktor.CinsiyetID = model.CinsiyetID;
                doktor.DrEmail = model.DrEmail;

                context.SaveChanges();
            }

            HttpContext.Session.Remove("DoktorBilgi");

            var yenidoktor = JsonConvert.SerializeObject(doktor);
            HttpContext.Session.SetString("DoktorBilgi", yenidoktor);

            TempData["Success"] = "Profiliniz başarıyla güncellendi!";
            return RedirectToAction("DoktorProfil");
        }
    }
}
