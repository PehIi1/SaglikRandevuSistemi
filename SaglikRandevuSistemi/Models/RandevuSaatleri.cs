using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class RandevuSaatleri
    {
        public int RandSaatID { get; set; }
        public DateOnly RandSaatTarihi { get; set; }
        public TimeOnly RandSaatZamani { get; set; }
        public List<Randevular>? Randevulars { get; set; } = new List<Randevular>();
    }
}
