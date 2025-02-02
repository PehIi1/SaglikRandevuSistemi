using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class Kullanicilar
    {
        public int KullaniciID { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? Parola { get; set; }
        public int? RolID { get; set; }
        public Roller? Roller { get; set; }
        public Doktorlar? Doktorlar { get; set; } // birebir oldugu icun List degil
        public Hastalar? Hastalar { get; set; } // birebir oldugu icin List degil
    }
}
