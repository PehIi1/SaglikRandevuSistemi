using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class Randevular
    {
        public int RandID { get; set; }
        public int? HastaID { get; set; }
        public int? DoktorID { get; set; }
        public int? HastaneID { get; set; }
        public int? RandSaatID { get; set; }
        public int? RandDurumID { get; set; }
        public int? KlinikID { get; set; }
        public DateOnly RandevuGun { get; set; }
        public Doktorlar? Doktorlar { get; set; }
        public Hastalar? Hastalar { get; set; }
        public Hastaneler? Hastaneler { get; set; }
        public Klinikler? Klinikler { get; set; }
        public RandevuDurumlari? RandevuDurumlari { get; set; }
        public RandevuSaatleri? RandevuSaatleri { get; set; }
    }
}
