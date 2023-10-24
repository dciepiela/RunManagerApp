using RunManagerWebApp.Models;

namespace RunManagerWebApp.Data.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();
        Task<Club> GetByIdAsync(int id); //synchronizacja get
        Task<Club> GetByIdAsyncNotTracking(int id);
        void Add(Club club);
        void Update(Club club);
        void Delete(Club club);
        bool Save();
    }
}
