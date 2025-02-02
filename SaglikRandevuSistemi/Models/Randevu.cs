namespace SaglikRandevuSistemi.Models
{
    public class Randevu
    {
        public int RandID { get; set; }
        public int? HastaID { get; set; }
        public int? DoktorID { get; set; }
        public int? HastaneID { get; set; }
        public int? RandSaatID { get; set; }
        public int? RandDurumID { get; set; }
        public int? KlinikID { get; set; }
        public DateOnly RandevuGun { get; set; }
    }
}
