using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaglikRandevuSistemi.Filters;
using SaglikRandevuSistemi.Models;
using SaglikRandevuSistemi.ViewModels;

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
            var hastaJson = HttpContext.Session.GetString("DoktorBilgi");

            var hasta = JsonConvert.DeserializeObject<Hastalar>(hastaJson);

            Doktorlar doc = context.Doktorlars.Where(x=>x.KullaniciID == hasta.KullaniciID).FirstOrDefault();

            List<Randevu> randevular = context.Randevu.Where(x => x.DoktorID == doc.DrID && x.RandevuGun > DateOnly.FromDateTime(DateTime.Now)).ToList();
            List<Randevu> gecmisrandevular = context.Randevu.Where(x => x.DoktorID == doc.DrID && x.RandevuGun < DateOnly.FromDateTime(DateTime.Now)).ToList();

            List<RandevuDto> dto = new();
            List<RandevuDto> olddto = new();

            foreach (var item in randevular)
            {
                string hastaadi = context.Hastalars.First(x => x.KullaniciID == item.HastaID).HastaAdi;
                string hastahane = context.Hastanelers.First(x => x.HastaneID == item.HastaneID).HastaneAdi;
                string klinik = context.Kliniklers.First(x => x.KlinikID == item.KlinikID).KlinikAdi;

                RandevuDto randevuDto = new();

                randevuDto.RandDurumID = 1;
                randevuDto.RandevuGun = item.RandevuGun;
                randevuDto.RandSaatID = item.RandSaatID;
                randevuDto.Klinik = klinik;
                randevuDto.Hastane = hastahane;
                randevuDto.Hasta = hastaadi;

                dto.Add(randevuDto);
            }

            foreach (var item in gecmisrandevular)
            {
                string hastaadi = context.Hastalars.First(x => x.KullaniciID == item.HastaID).HastaAdi;
                string hastahane = context.Hastanelers.First(x => x.HastaneID == item.HastaneID).HastaneAdi;
                string klinik = context.Kliniklers.First(x => x.KlinikID == item.KlinikID).KlinikAdi;

                RandevuDto randevuDto = new();

                randevuDto.RandDurumID = 1;
                randevuDto.RandevuGun = item.RandevuGun;
                randevuDto.RandSaatID = item.RandSaatID;
                randevuDto.Klinik = klinik;
                randevuDto.Hastane = hastahane;
                randevuDto.Hasta = hastaadi;

                olddto.Add(randevuDto);
            }

            RandevuMixDto viewModel = new RandevuMixDto
            {
                eski = olddto,
                yeni = dto
            };

            return View(viewModel);
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
