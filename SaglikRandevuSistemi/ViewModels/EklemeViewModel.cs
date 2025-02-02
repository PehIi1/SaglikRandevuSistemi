using Microsoft.AspNetCore.Mvc.Rendering;
using SaglikRandevuSistemi.Models;

namespace SaglikRandevuSistemi.ViewModels
{
    public class EklemeViewModel
    {
        public int SelectedSehirID { get; set; }
        public int SelectedIlceID { get; set; }
        public List<SelectListItem> Sehirler { get; set; }
        public List<SelectListItem> Ilceler { get; set; }

        public Hastalar? Hastas { get; set; }
        public Doktorlar? Doktors { get; set; }
        public Hastaneler? Hastanes { get; set; }
        public Klinikler? Kliniks { get; set; }
        public Sehirler? Sehirs { get; set; }
        public Ilceler? Ilces { get; set; }
        public Randevular? Randevus { get; set; }
    }
}
