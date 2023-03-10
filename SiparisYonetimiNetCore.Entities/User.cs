using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} gereklidir!"), Display(Name = "Adı")] // Veritabanında oluşan kolonun nvarcharmax yerine nvarchar(50) olması için
        public string Name { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} gereklidir!"), Display(Name = "Soyadı")]
        public string Surname { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} gereklidir!")]
        public string Email { get; set; }
        [StringLength(15), Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [StringLength(50), Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }
        [StringLength(50), Display(Name = "Şifre"), Required(ErrorMessage = "{0} gereklidir!")]
        public string Password { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
