using RunManagerWebApp.Data.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunManagerWebApp.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        //[DisplayName("Nazwa teamu")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Nazwa teamu powinna zawierać od 2 do 50 znaków")]
        public string? Title { get; set; }
        //[DisplayName("Opis")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Opis powinien zawierać od 2 do 400 znaków")]
        public string? Description { get; set; }
        //[DisplayName("URL zdjęcia")]
        //[StringLength(100, MinimumLength = 2)]
        public string? Image { get; set; }

        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public RaceType RaceType { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
