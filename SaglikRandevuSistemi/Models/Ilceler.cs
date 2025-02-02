using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class Ilceler
    {
        public int IlceID { get; set; }
        public string? IlceAdi { get; set; }
        public int? SehirID { get; set; }
        public Sehirler? Sehirler { get; set; }
        public List<Hastaneler>? Hastanelers { get; set; } = new List<Hastaneler>();
        public List<Hastalar>? Hastalars { get; set; } = new List<Hastalar>();
    }
}
