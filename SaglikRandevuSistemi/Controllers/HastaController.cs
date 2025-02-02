using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SaglikRandevuSistemi.Filters;
using SaglikRandevuSistemi.Migrations;
using SaglikRandevuSistemi.Models;
using SaglikRandevuSistemi.ViewModels;

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

        [HttpPost]
        [Route("search")]
        public IActionResult Search([FromForm] SearchDto dto)
        {


            var query = context.DrOptions.Where(x => x.CityId == dto.Province);

            if (dto.hastane != 0)
            {
                query = query.Where(x => x.HastaneID == dto.hastane);
            }

            if (dto.hekim != 0)
            {
                query = query.Where(x => x.DrID == dto.hekim);
            }

            if (dto.klinik != 0)
            {
                query = query.Where(x => x.KlinikID == dto.klinik);
            }

            List<DrOptions> drOptions = query.ToList();

            List<Doktorlar> doktorlars = new();
            foreach (var dr in drOptions)
            {
                Doktorlar d = context.Doktorlars.FirstOrDefault(x => x.DrID == dr.DrID);
                doktorlars.Add(d);
            }

            DrOptionsViewModel viewModel = new DrOptionsViewModel
            {
                DrOptions = drOptions,
                Doktorlars = doktorlars
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("droptions")]
        public IActionResult DrOptions([FromForm] DrOptions dto)
        {
            var userinfo = HttpContext.Session.GetString("HastaBilgi");
            var user = JsonConvert.DeserializeObject<Hastalar>(userinfo);

            Randevu randevular = new Randevu();

            randevular.KlinikID = dto.KlinikID;
            randevular.DoktorID = dto.DrID;
            randevular.HastaID = user.KullaniciID;
            randevular.HastaneID = dto.HastaneID;
            if (dto.opt1 == true)
            {
                randevular.RandSaatID = 8;
            }
            else if (dto.opt2 == true)
            {
                randevular.RandSaatID = 9;
            }
            else if (dto.opt3 == true)
            {
                randevular.RandSaatID = 10;
            }
            else if (dto.opt4 == true)
            {
                randevular.RandSaatID = 11;
            }
            else if (dto.opt5 == true)
            {
                randevular.RandSaatID = 13;
            }
            else if (dto.opt6 == true)
            {
                randevular.RandSaatID = 14;
            }
            else if (dto.opt7 == true)
            {
                randevular.RandSaatID = 15;
            }
            else if (dto.opt8 == true)
            {
                randevular.RandSaatID = 16;
            }
            randevular.RandDurumID = 1;
            randevular.RandevuGun = dto.Day.Value;

            context.Add(randevular);
            context.SaveChanges();

            DrOptions drOptions = context.DrOptions.Where(x => x.OptionsID == dto.OptionsID).FirstOrDefault();

            if (dto.opt1 == true)
            {
                drOptions.opt1 = true;
            }
            else if (dto.opt2 == true)
            {
                drOptions.opt2 = true;
            }
            else if (dto.opt3 == true)
            {
                drOptions.opt3 = true;
            }
            else if (dto.opt4 == true)
            {
                drOptions.opt4 = true;
            }
            else if (dto.opt5 == true)
            {
                drOptions.opt5 = true;
            }
            else if (dto.opt6 == true)
            {
                drOptions.opt6 = true;
            }
            else if (dto.opt7 == true)
            {
                drOptions.opt7 = true;
            }
            else if (dto.opt8 == true)
            {
                drOptions.opt8 = true;
            }
            context.DrOptions.Update(drOptions);
            context.SaveChanges();

            return RedirectToAction("HastaArayuz");
        }


        public IActionResult HastaArayuz()
        {

            var hastaJson = HttpContext.Session.GetString("HastaBilgi");

            var hasta = JsonConvert.DeserializeObject<Hastalar>(hastaJson);

            List<Randevu> randevular = context.Randevu.Where(x => x.HastaID == hasta.KullaniciID && x.RandevuGun > DateOnly.FromDateTime(DateTime.Now)).ToList();
            List<Randevu> gecmisrandevular = context.Randevu.Where(x => x.HastaID == hasta.KullaniciID && x.RandevuGun < DateOnly.FromDateTime(DateTime.Now)).ToList();

            List<RandevuDto> dto = new();
            List<RandevuDto> olddto = new();

            foreach(var item in randevular)
            {
                string doc = context.Doktorlars.First(x => x.DrID == item.DoktorID).DrAdi;
                string hastahane = context.Hastanelers.First(x => x.HastaneID == item.HastaneID).HastaneAdi;
                string klinik = context.Kliniklers.First(x => x.KlinikID == item.KlinikID).KlinikAdi;

                RandevuDto randevuDto = new();

                randevuDto.RandDurumID = 1;
                randevuDto.RandevuGun = item.RandevuGun;
                randevuDto.RandSaatID = item.RandSaatID;
                randevuDto.Klinik = klinik;
                randevuDto.Hastane = hastahane;
                randevuDto.Doktor = doc;

                dto.Add(randevuDto);
            }

            foreach (var item in gecmisrandevular)
            {
                string doc = context.Doktorlars.First(x => x.DrID == item.DoktorID).DrAdi;
                string hastahane = context.Hastanelers.First(x => x.HastaneID == item.HastaneID).HastaneAdi;
                string klinik = context.Kliniklers.First(x => x.KlinikID == item.KlinikID).KlinikAdi;

                RandevuDto randevuDto = new();

                randevuDto.RandDurumID = 1;
                randevuDto.RandevuGun = item.RandevuGun;
                randevuDto.RandSaatID = item.RandSaatID;
                randevuDto.Klinik = klinik;
                randevuDto.Hastane = hastahane;
                randevuDto.Doktor = doc;

                olddto.Add(randevuDto);
            }

            RandevuMixDto viewModel = new RandevuMixDto
            {
                eski = olddto,
                yeni = dto
            };

            return View(viewModel);
        }

        public IActionResult HastaProfil()
        {
            var hastaJson = HttpContext.Session.GetString("HastaBilgi");
            if (string.IsNullOrEmpty(hastaJson))
            {
                TempData["Error"] = "Session yok, hasta bilgileri bulunamadi";
                return RedirectToAction("Login", "Home");
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
        public IActionResult ProfilGuncelle(string HastaAdi, string HastaSoyadi, int CinsiyetID, string HastaYas, string HastaBoy, string HastaKilo, string HastaTel, string HastaEmail, int SehirID, int IlceID, string HastaAdres, int HastaID)
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
