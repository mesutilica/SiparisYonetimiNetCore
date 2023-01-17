using System.ComponentModel.DataAnnotations;

namespace SiparisYonetimiNetCore.WebUI.Models
{
    public class AdminLoginViewModel
    {
        [StringLength(50), Required(ErrorMessage = "{0} gereklidir!")]
        public string Email { get; set; }
        [StringLength(50), Display(Name = "Şifre"), Required(ErrorMessage = "{0} gereklidir!")]
        public string Password { get; set; }
    }
}
