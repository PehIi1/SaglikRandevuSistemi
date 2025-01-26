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
            ViewBag.Sehirler = sehirler;
            ViewBag.Ilceler = ilceler;
            ViewBag.Cinsiyetler = cinsiyetler;
            ViewBag.Kullanicilar = kullanicilar;
            ViewBag.Klinikler = klinikler;
            ViewBag.Hastaneler = hastaneler;
            return View(model);
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
                return RedirectToAction("VeriEkleme");
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


    }
}
