namespace SaglikRandevuSistemi.ViewModels
{
    public class RandevuDto
    {
        public int RandID { get; set; }
        public int? HastaID { get; set; }
        public string? Doktor { get; set; }
        public string? Hasta { get; set; }
        public string? Hastane { get; set; }
        public int? RandSaatID { get; set; }
        public int? RandDurumID { get; set; }
        public string? Klinik { get; set; }
        public DateOnly RandevuGun { get; set; }
    }
}
