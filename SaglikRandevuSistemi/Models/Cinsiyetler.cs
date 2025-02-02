using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class Cinsiyetler
    {
        public int CinsiyetID { get; set; }
        public string? CinsiyetAdi { get; set; }
        public List<Doktorlar>? Doktorlars { get; set; } = new List<Doktorlar>();
        public List<Hastalar>? Hastalars { get; set; } = new List<Hastalar>();
    }
}
