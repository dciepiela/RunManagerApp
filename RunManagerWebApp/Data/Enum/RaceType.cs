using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RunManagerWebApp.Data.Enum
{
    public enum RaceType
    {
        [Display(Name = "Trail")] 
        Trail = 1,
        [Display(Name = "Biegi z przeszkodami")] 
        Obstacles = 2,
        [Display(Name = "Biegi górskie")] 
        Mountain = 3,
        [Display(Name = "Biegi przełajowe")] 
        Cross = 4,
        [Display(Name = "Biegi na orientację")] 
        Orientation = 5,
        [Display(Name = "Biegi sztafetowe")] 
        Relay = 6,
        [Display(Name = "Biegi uliczne")] 
        Street = 7
    }


}
