using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class RandevuDurumlari
    {
        public int RandDurumID { get; set; }
        public string? RandDurumAdi { get; set; }
        public List<Randevular>? Randevulars { get; set; } = new List<Randevular>();
    }
}
