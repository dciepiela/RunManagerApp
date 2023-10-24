using Microsoft.AspNetCore.Mvc;
using RunManagerWebApp.Models;
using RunManagerWebApp.ViewModels;

namespace RunManagerWebApp.Data.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Race>> GetAllUserRaces();
        Task<List<Club>> GetAllUserClubs();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        void Update(AppUser user);
        bool Save();
    }
}
