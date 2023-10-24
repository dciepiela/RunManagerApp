using Microsoft.EntityFrameworkCore;
using RunManagerWebApp.Data;
using RunManagerWebApp.Data.Interfaces;
using RunManagerWebApp.Models;

namespace RunManagerWebApp.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly AppDbContext _context;

        public ClubRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Club club)
        {
            _context.Add(club);
            _context.SaveChanges();
        }

        public void Delete(Club club)
        {
            _context.Remove(club);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
           return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _context.Clubs.Include(i=>i.Address).FirstOrDefaultAsync(i=>i.Id ==id);
        }   
        
        public async Task<Club> GetByIdAsyncNotTracking(int id)
        {
            return await _context.Clubs.Include(i=>i.Address).AsNoTracking().FirstOrDefaultAsync(i=>i.Id ==id);
        }
        //public async Task<IEnumerable<Club>> GetClubByCity(string city)
        //{
        //    return await _context.Clubs.Where(c => c.Address.City.Contains(city)).ToListAsync();
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;

        }
        public void Update(Club club)
        {
            _context.Update(club);
            _context.SaveChanges();
        }
    }
}
