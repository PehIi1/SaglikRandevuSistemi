using System.ComponentModel.DataAnnotations;

namespace SaglikRandevuSistemi.Models
{
    public class DrOptions
    {
        [Key]
        public int OptionsID { get; set; }
        public int? DrID { get; set; }
        public string? DrName { get; set; }
        public bool? opt1 { get; set; } = false;
        public bool? opt2 { get; set; } = false;
        public bool? opt3 { get; set; } = false;
        public bool? opt4 { get; set; } = false;
        public bool? opt5 { get; set; } = false;
        public bool? opt6 { get; set; } = false;
        public bool? opt7 { get; set; } = false;
        public bool? opt8 { get; set; } = false;
        public DateOnly? Day { get; set; }
        public int? HastaneID { get; set; }
        public int? KlinikID { get; set; }
        public int? CityId { get; set; }
    }
}
