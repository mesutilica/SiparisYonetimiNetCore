using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "İsim"), Required]
        public string Name { get; set; }
        [Display(Name = "Soyisim"), Required]
        public string Surname { get; set; }
        public string Email { get; set; }
        [Display(Name = "Mesaj"), Required]
        public string Message { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
