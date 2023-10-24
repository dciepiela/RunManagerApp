using Microsoft.EntityFrameworkCore;
using RunManagerWebApp.Data;
using RunManagerWebApp.Data.Interfaces;
using RunManagerWebApp.Models;

namespace RunManagerWebApp.Repository
{
    public class RaceRepository:IRaceRepository
    {
        private readonly AppDbContext _context;

        public RaceRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void Add(Race race)
        {
            _context.Add(race);
            _context.SaveChanges();
        }

        public void Delete(Race race)
        {
            _context.Remove(race);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            //_context.Set<Race>().ToListAsync();
            return await _context.Races.ToListAsync();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            return await _context.Races.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Race> GetByIdAsyncNotTracking(int id)
        {
            return await _context.Races.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Race>> GetRacesByCity(string city)
        {
            return await _context.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetTopRacesAsync(int amountOfRaces)
        {
            return await _context.Races.Where(r => r.RaceDate >= DateTime.Now).OrderBy(r=>r.RaceDate).Take(amountOfRaces).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public void Update(Race race)
        {
            _context.Update(race);
            _context.SaveChanges();
        }
    }
}
