using RunManagerWebApp.Models;

namespace RunManagerWebApp.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<AppUser> GetUserById(string id);

        void Add(AppUser appUser);
        void Update(AppUser appUser);
        void Delete(AppUser appUser);
        bool Save();
    }
}
