using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace RunManagerWebApp.ViewModels
{
    public class RegisterViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Adres email jest wymagany.")]
        public string Email { get; set;}

        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Potwierdź hasło")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Potwierdzene hasła jest wymagane.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasło nie pasuje")]
        public string ConfirmPassword { get; set; }
    }
}
