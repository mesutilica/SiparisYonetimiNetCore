using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Required, Display(Name = "Adı")]
        public string Name { get; set; }
        [StringLength(50), Required, Display(Name = "Soyadı")]
        public string Surname { get; set; }
        [StringLength(50), Required]
        public string Email { get; set; }
        [StringLength(15), Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [StringLength(500), Display(Name = "Adres")]
        public string? Address { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // ScaffoldColumn(false) kodu mvc de ekranları oluştururken CreateDate için ekranda alan oluşmasını engeller
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
