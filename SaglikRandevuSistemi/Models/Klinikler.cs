using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class Klinikler
    {
        public int KlinikID { get; set; }
        public string? KlinikAdi { get; set; }
        public List<Doktorlar>? Doktorlars { get; set; } = new List<Doktorlar>();
        public List<Randevular>? Randevulars { get; set; } = new List<Randevular>();
        public List<HastaneKlinikleri>? HastaneKlinikleris { get; set; } = new List<HastaneKlinikleri>();
    }
}
