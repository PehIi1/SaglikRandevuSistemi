using SaglikRandevuSistemi.Models;

namespace SaglikRandevuSistemi.ViewModels
{
    public class RandevuMixDto
    {
        public List<RandevuDto> yeni { get; set; }
        public List<RandevuDto> eski { get; set; }
    }
}
