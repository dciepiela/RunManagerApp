using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunManagerWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public int? Pace { get; set; }
        public int? Milage { get; set; }
        public string? ProfileImage { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Race> Races { get; set; }

    }
}
