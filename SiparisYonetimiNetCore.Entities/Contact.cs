using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "İsim"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Name { get; set; }
        [Display(Name = "Soyisim"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }
        [Display(Name = "Mesaj"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Message { get; set; }
        [Display(Name = "Mesaj Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
