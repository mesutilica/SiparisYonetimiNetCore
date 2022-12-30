using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        [StringLength(100), Required, Display(Name = "Marka Adı")]
        public string Name { get; set; }
        [StringLength(100)]
        public string? Logo { get; set; }
        [Display(Name = "Marka Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // view larda bu kolon oluşmasın!
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public virtual List<Product>? Products { get; set; }
    }
}
