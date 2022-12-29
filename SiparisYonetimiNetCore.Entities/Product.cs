using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [StringLength(100), Required, Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        [Display(Name = "Ürün Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }
        [Display(Name = "Stok")]
        public int Stock { get; set; }
        [StringLength(150)]
        [Display(Name = "Ürün Resmi")]
        public string? Image { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Anasayfa")]
        public bool IsHome { get; set; }
        [Display(Name = "Ürün Kategorisi")]
        public int CategoryId { get; set; }
        [Display(Name = "Ürün Markası")]
        public int BrandId { get; set; }
        [Display(Name = "Ürün Markası")]
        public virtual Brand? Brand { get; set; }
        [Display(Name = "Ürün Kategorisi")]
        public virtual Category? Category { get; set; } // Ürün classı üzerinden ürünün kategori bilgisine entity framework ile ulaşabilmek için
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
