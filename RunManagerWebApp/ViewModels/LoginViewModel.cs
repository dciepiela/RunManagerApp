using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace RunManagerWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Adres email jest wymagany.")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Hasło jest wymagane.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
