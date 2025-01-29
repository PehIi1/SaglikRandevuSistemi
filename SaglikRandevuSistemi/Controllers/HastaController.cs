using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaglikRandevuSistemi.Filters;
using SaglikRandevuSistemi.Models;

namespace SaglikRandevuSistemi.Controllers
{
    [CustomAuthorization("Hasta")]
    public class HastaController : Controller
    {
        private readonly DataContext context;

        public HastaController(DataContext dataContext)
        {
            this.context = dataContext;
        }

        public IActionResult HastaArayuz()
            {

            var hastaJson = HttpContext.Session.GetString("HastaBilgi");
            if (string.IsNullOrEmpty(hastaJson))
            {

            }
            else
            {
                var hasta = JsonConvert.DeserializeObject<Hastalar>(hastaJson);
            }

            return View();
        }

        public IActionResult HastaProfil()
        {
            var hastaJson = HttpContext.Session.GetString("HastaBilgi");
            if (string.IsNullOrEmpty(hastaJson))
            {
                TempData["Error"] = "Session yok, hasta bilgileri bulunamadi";
                return RedirectToAction("Login","Home");
            }
            ViewBag.Sehirler = context.Sehirlers.ToList();
            ViewBag.Ilceler = context.Ilcelers.ToList();
            ViewBag.Cinsiyetler = context.Cinsiyetlers.ToList();


            var hasta = JsonConvert.DeserializeObject<Hastalar>(hastaJson);

            return View(hasta);
        }

        public IActionResult AramaFiltresi()
        {
            return View();
        }

        public IActionResult RandevuListeleme()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProfilGuncelle( string HastaAdi, string HastaSoyadi, int CinsiyetID, string HastaYas, string HastaBoy, string HastaKilo, string HastaTel, string HastaEmail, int SehirID, int IlceID, string HastaAdres, int HastaID)
        {
            var hasta = context.Hastalars.FirstOrDefault(h => h.HastaID == HastaID);

            if (hasta != null)
            {
                hasta.HastaAdi = HastaAdi;
                hasta.HastaSoyadi = HastaSoyadi;
                hasta.HastaYas = HastaYas;
                hasta.HastaBoy = HastaBoy;
                hasta.HastaKilo = HastaKilo;
                hasta.HastaEmail = HastaEmail;
                hasta.HastaTel = HastaTel;
                hasta.HastaAdres = HastaAdres;
                if (CinsiyetID != 0)
                {
                    hasta.CinsiyetID = CinsiyetID;
                }
                if (SehirID != 0)
                {
                    hasta.SehirID = SehirID;
                }
                if (IlceID != 0)
                {
                    hasta.IlceID = IlceID;
                }

                context.SaveChanges();
            }

            HttpContext.Session.Remove("HastaBilgi");

            var yeniHastaJson = JsonConvert.SerializeObject(hasta);
            HttpContext.Session.SetString("HastaBilgi", yeniHastaJson);

            TempData["Success"] = "Profiliniz başarıyla güncellendi!";
            return RedirectToAction("HastaProfil");
        }
    }
}
