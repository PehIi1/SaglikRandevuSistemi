using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class Hastaneler
    {
        public int HastaneID { get; set; }
        public string? HastaneAdi { get; set; }
        public int? SehirID { get; set; }
        public int? IlceID { get; set; }
        public Ilceler? Ilceler { get; set; }
        public Sehirler? Sehirler { get; set; }
        public List<Randevular>? Randevulars { get; set; } = new List<Randevular>();
        public List<Doktorlar>? Doktorlars { get; set; } = new List<Doktorlar>();
        public List<HastaneKlinikleri>? HastaneKlinikleris { get; set; } = new List<HastaneKlinikleri>();
    }
}