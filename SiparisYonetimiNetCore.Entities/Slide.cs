using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Slide : IEntity
    {
        public int Id { get; set; }
        [StringLength(100), Display(Name = "Resim")]
        public string? Image { get; set; }
        [StringLength(100), Display(Name = "Başlık")]
        public string? Title { get; set; }
        [StringLength(500), Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [StringLength(150)]
        public string? Link { get; set; }
    }
}
