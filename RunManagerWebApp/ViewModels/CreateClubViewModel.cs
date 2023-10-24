using RunManagerWebApp.Data.Enum;
using RunManagerWebApp.Models;

namespace RunManagerWebApp.ViewModels
{
    public class CreateClubViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Address Address { get; set; }
        public RaceType RaceType { get; set; }
        public string AppUserId { get; set; }
    }
}
