using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class Sehirler
    {
        public int SehirID { get; set; }
        public string? SehirAdi { get; set; }
        public List<Hastalar>? Hastalars { get; set; } = new List<Hastalar>();
        public List<Hastaneler>? Hastanelers { get; set; } = new List<Hastaneler>();
        public List<Ilceler>? Ilcelers { get; set; } = new List<Ilceler>();
    }
}
