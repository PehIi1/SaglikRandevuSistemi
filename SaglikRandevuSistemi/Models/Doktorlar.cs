using SaglikRandevuSistemi.Models;
using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class Doktorlar
    {
        public int DrID { get; set; }
        public string? DrAdi { get; set; }
        public string? DrSoyadi { get; set; }
        public string? DrYas { get; set; }
        public string? DrTel { get; set; }
        public string? DrEmail { get; set; }
        public int? KlinikID { get; set; }
        public int? HastaneID { get; set; }
        public int? CinsiyetID { get; set; }
        public int? KullaniciID { get; set; }
        public Cinsiyetler? Cinsiyetler { get; set; }
        public Klinikler? Klinikler { get; set; }
        public Hastaneler? Hastaneler { get; set; }
        public Kullanicilar? Kullanicilar { get; set; }
        public List<Randevular>? Randevulars { get; set; } = new List<Randevular>();
    }
}
