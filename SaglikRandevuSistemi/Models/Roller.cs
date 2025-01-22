using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class Roller
    {
        public int RolID { get; set; }
        public string? RolAdi { get; set; }
        public List<Kullanicilar>? Kullanicilars { get; set; } = new List<Kullanicilar>();
    }
}
