using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.WebUI.Models
{
    public class HomePageViewModel
    {
        public List<Slide>? Slides { get; set; }
        public List<Slider>? Products { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}
