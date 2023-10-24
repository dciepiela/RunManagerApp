using RunManagerWebApp.Data.CustomValidation;
using RunManagerWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunManagerWebApp.Models
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM yyyy HH:mm}", ApplyFormatInEditMode = false)]
        [GreaterDate]
        public DateTime RaceDate { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public RaceType RaceType { get; set; }

        public RaceDistance RaceDistance { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
