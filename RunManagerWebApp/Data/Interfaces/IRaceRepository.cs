using RunManagerWebApp.Models;

namespace RunManagerWebApp.Data.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByIdAsync(int id); //synchronizacja get
        Task<Race> GetByIdAsyncNotTracking(int id);
        Task<IEnumerable<Race>> GetRacesByCity(string city);
        Task<IEnumerable<Race>> GetTopRacesAsync(int amountOfRaces);
        void Add(Race race);
        void Update(Race race);
        void Delete(Race race);
        bool Save();
    }
}
