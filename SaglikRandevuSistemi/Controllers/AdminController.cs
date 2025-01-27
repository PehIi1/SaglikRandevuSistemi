using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaglikRandevuSistemi.Models;
using SaglikRandevuSistemi.ViewModels;

namespace SaglikRandevuSistemi.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataContext context;

        public AdminController(DataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HastalarTables()
        {
            var Hastalar = context.Hastalars
                .Include(c => c.Cinsiyetler)
                .Include(s => s.Sehirler)
                .Include(i => i.Ilceler)
                .Include(ku => ku.Kullanicilar)
                .OrderBy(ord => ord.HastaID)
                .ToList();
            return View(Hastalar);
        }

        public IActionResult DoktorlarTables()
        {
            var Doktorlar = context.Doktorlars
                .Include(kl => kl.Klinikler)
                .Include(hs => hs.Hastaneler)
                .Include(c => c.Cinsiyetler)
                .Include(ku => ku.Kullanicilar)
                .OrderBy(ord => ord.DrID)
                .ToList();

            return View(Doktorlar);
        }

        public IActionResult RandevuListeleme() { return View(); }

        public IActionResult VeriEkleme()
        {
            List<SelectListItem> sehirler = context.Sehirlers
                .Select(s => new SelectListItem
                {
                    Value = s.SehirID.ToString(),
                    Text = s.SehirAdi
                }).ToList();

            var model = new EklemeViewModel
            {
                Sehirler = sehirler,
                Ilceler = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = "",
                        Text = "Önce bir şehir seçiniz.."
                    }
                }

            };

            List<SelectListItem> ilceler = (from ilc in context.Ilcelers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = ilc.IlceAdi,
                                                Value = ilc.IlceID.ToString()
                                            }).ToList();
            List<SelectListItem> cinsiyetler = (from cn in context.Cinsiyetlers.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = cn.CinsiyetAdi,
                                                    Value = cn.CinsiyetID.ToString()
                                                }).ToList();
            List<SelectListItem> kullanicilar = (from ku in context.Kullanicilars.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = ku.KullaniciAdi,
                                                    Value = ku.KullaniciID.ToString()
                                                }).ToList();
            List<SelectListItem> klinikler = (from kl in context.Kliniklers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = kl.KlinikAdi,
                                                     Value = kl.KlinikID.ToString()
                                                 }).ToList();
            List<SelectListItem> hastaneler = (from hs in context.Hastanelers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = hs.HastaneAdi,
                                                     Value = hs.HastaneID.ToString()
                                                 }).ToList();
            List<SelectListItem> randevusaati = context.RandevuSaatleris
                .Select(rs => new SelectListItem
                {
                    Value = rs.RandSaatID.ToString(),
                    Text = $"{rs.RandSaatTarihi:dd.MM.yyyy}/{rs.RandSaatZamani:HH:mm}"
                }).ToList();
            List<SelectListItem> randevudurumu = context.RandevuDurumlaris
                .Select(rd => new SelectListItem
                {
                    Value = rd.RandDurumID.ToString(),
                    Text = rd.RandDurumAdi
                }).ToList();
            List<SelectListItem> hastalar = context.Hastalars
                .Select(h => new SelectListItem
                {
                    Value = h.HastaID.ToString(),
                    Text = $"{h.HastaAdi} {h.HastaSoyadi}"
                }).ToList();
            List<SelectListItem> doktorlar = context.Doktorlars
                .Select(d => new SelectListItem
                {
                    Value = d.DrID.ToString(),
                    Text = $"{d.DrAdi} {d.DrSoyadi}"
                }).ToList();

            ViewBag.Hastalar = hastalar;
            ViewBag.Doktorlar = doktorlar;
            ViewBag.Sehirler = sehirler;
            ViewBag.Ilceler = ilceler;
            ViewBag.Cinsiyetler = cinsiyetler;
            ViewBag.Kullanicilar = kullanicilar;
            ViewBag.Klinikler = klinikler;
            ViewBag.Hastaneler = hastaneler;
            ViewBag.RandevuSaatleri = randevusaati;
            ViewBag.RandevuDurumlari = randevudurumu;
            return View(model);
        }
        
        public IActionResult VeriSilme(int id, string Sayfa)
        {
            return RedirectToAction(Sayfa);
        }

        [HttpGet]
        public JsonResult GetIlceler(int sehirID)
        {
            var ilceler = context.Ilcelers
                .Where(i => i.SehirID == sehirID)
                .Select(i => new { Text = i.IlceAdi, Value = i.IlceID }).ToList();

            return Json(ilceler);
        }

        [HttpPost]
        public IActionResult VeriEkleme(EklemeViewModel model, string tablo)
        {

            if (tablo == "Hastalar" && model.Hastas.HastaAdi != null)
            {
                context.Hastalars.Add(model.Hastas);
                context.SaveChanges();
                return RedirectToAction("HastalarTables");
            }
            else if(tablo == "Doktorlar" && model.Doktors.DrAdi != null)
            {
                context.Doktorlars.Add(model.Doktors);
                context.SaveChanges();
                return RedirectToAction("DoktorlarTables");
            }
            else if(tablo == "Hastaneler" && model.Hastanes.HastaneAdi != null)
            {
                context.Hastanelers.Add(model.Hastanes);
                context.SaveChanges();
                return RedirectToAction("HastanelerTables");
            }
            else if(tablo == "Klinikler" && model.Kliniks.KlinikAdi != null)
            {
                context.Kliniklers.Add(model.Kliniks);
                context.SaveChanges();
                return RedirectToAction("KliniklerTables");
            }
            else if(tablo == "Sehirler" && model.Sehirs.SehirAdi != null)
            {
                context.Sehirlers.Add(model.Sehirs);
                context.SaveChanges();
                return RedirectToAction("SehirlerTables");
            }
            else if(tablo == "Ilceler" && model.Ilces.IlceAdi != null)
            {
                context.Ilcelers.Add(model.Ilces);
                context.SaveChanges();
                return RedirectToAction("IlcelerTables");
            }
            else if(tablo == "Randevular" && model.Randevus.DoktorID != null)
            {
                context.Randevulars.Add(model.Randevus);
                context.SaveChanges();
                return RedirectToAction("RandevularTables");
            }
            else
            {
                TempData["ErrorMessage"] = "Ekleme islemi gerceklestirilemedi";
                return RedirectToAction("Index");
            }
        }

        public IActionResult HastanelerTables()
        {
            var Hastaneler = context.Hastanelers
                .Include(hs => hs.Sehirler)
                .Include(hs => hs.Ilceler)
                .OrderBy(hs => hs.HastaneID)
                .ToList();

            return View(Hastaneler);
        }

        public IActionResult KliniklerTables()
        {
            var Klinikler = context.Kliniklers
                .OrderBy(kl => kl.KlinikID)
                .ToList();

            return View(Klinikler);
        }

        public IActionResult SehirlerTables()
        {
            var sehirlerr = context.Sehirlers
                .OrderBy(s => s.SehirID)
                .ToList();

            return View(sehirlerr);
        }

        public IActionResult IlcelerTables()
        {
            var ilcelerr = context.Ilcelers
                .Include(i => i.Sehirler)
                .OrderBy(i => i.IlceID)
                .ToList();

            return View(ilcelerr);
        }

        public IActionResult RandevularTables()
        {
            var randevularr = context.Randevulars
                .Include(rand => rand.Hastalar)
                .Include(rand => rand.Doktorlar)
                .Include(rand => rand.Hastaneler)
                .Include(rand => rand.Klinikler)
                .Include(rand => rand.RandevuSaatleri)
                .Include(rand => rand.RandevuDurumlari)
                .OrderBy(rand => rand.RandevuDurumlari.RandDurumID)
                .ToList();

            return View(randevularr);
        }

    }
}
