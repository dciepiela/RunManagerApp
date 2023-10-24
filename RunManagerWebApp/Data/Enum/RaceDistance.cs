using System.ComponentModel.DataAnnotations;

namespace RunManagerWebApp.Data.Enum
{
    public enum RaceDistance
    {
        [Display(Name = "2 km")]
        DwaK = 1,
        [Display(Name = "5 km")]
        PiecK = 2,
        [Display(Name = "6 km")]
        SzescK = 3,
        [Display(Name = "10 km")]
        DziesiecK = 4,
        [Display(Name = "21 km")]
        PółMaraton = 5,
        [Display(Name = "42 km")]
        Maraton = 6,
        [Display(Name = "42+ km")]
        Ultra = 7,
        [Display(Name = "Inny dystans")]
        Other = 8
    }
}
