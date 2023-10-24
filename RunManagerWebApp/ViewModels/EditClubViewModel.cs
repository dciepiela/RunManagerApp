﻿using RunManagerWebApp.Data.Enum;
using RunManagerWebApp.Models;

namespace RunManagerWebApp.ViewModels
{
    public class EditClubViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public RaceType RaceType { get; set; }

    }
}
