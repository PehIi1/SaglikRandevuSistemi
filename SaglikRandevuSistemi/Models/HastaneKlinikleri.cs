using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class HastaneKlinikleri
    {
        public int HastaneID { get; set; }
        public int KlinikID { get; set; }
        public Hastaneler? Hastaneler { get; set; }
        public Klinikler? Klinikler { get; set; }
    }
}
