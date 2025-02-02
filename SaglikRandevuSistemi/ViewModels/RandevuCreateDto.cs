namespace SaglikRandevuSistemi.ViewModels
{
    public class RandevuCreateDto
    {
        public int DrID { get; set; }
        public string DrName { get; set; }
        public int KlinikID { get; set; }
        public int HastaneID { get; set; }
        public DateOnly date { get; set; }
    }
}
