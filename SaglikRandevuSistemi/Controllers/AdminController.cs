using Microsoft.AspNetCore.Mvc;
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
            return View(new EklemeViewModel());
        }


    }
}
