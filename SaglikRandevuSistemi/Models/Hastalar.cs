using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class Hastalar
    {
        public int HastaID { get; set; }
        public string? HastaAdi { get; set; }
        public string? HastaSoyadi { get; set; }
        public string? HastaYas { get; set; }
        public string? HastaBoy { get; set; }
        public string? HastaKilo { get; set; }
        public string? HastaTel { get; set; }
        public string? HastaEmail { get; set; }
        public string? HastaAdres { get; set; }
        public int? SehirID { get; set; }
        public int? IlceID { get; set; }
        public int? CinsiyetID { get; set; }
        public int? KullaniciID { get; set; }
        public Cinsiyetler? Cinsiyetler{ get; set; } // Navigation: Hastanin cinsiyeti
        public Ilceler? Ilceler { get; set; } // Navigation: Hastanin ilcesi
        public Sehirler? Sehirler { get; set; } // Navigation: Hastanin sehri
        public Kullanicilar? Kullanicilar { get; set; } // Birebir
        public List<Randevular>? Randevulars { get; set; } = new List<Randevular>(); // Navigation: Hastalara ait randevular
    }
}
