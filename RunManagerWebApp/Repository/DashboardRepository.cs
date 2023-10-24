using Microsoft.EntityFrameworkCore;
using RunManagerWebApp.Data;
using RunManagerWebApp.Data.Interfaces;
using RunManagerWebApp.Models;

namespace RunManagerWebApp.Repository
{
    public class DashboardRepository: IDashboardRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccesor;
        public DashboardRepository(AppDbContext context, IHttpContextAccessor httpContextAccesor)
        {
            _context = context;
            _httpContextAccesor = httpContextAccesor;
        }


        public async Task<List<Club>> GetAllUserClubs()
        {
            var currentUser = _httpContextAccesor.HttpContext?.User.GetUserId();
            var userClubs = _context.Clubs.Where(r => r.AppUser.Id == currentUser);
            return userClubs.ToList();
        }

        public async Task<List<Race>> GetAllUserRaces()
        {
            var currentUser = _httpContextAccesor.HttpContext?.User.GetUserId();
            var userRaces = _context.Races.Where(r => r.AppUser.Id == currentUser);
            return userRaces.ToList();
        }
        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        public void Update(AppUser user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
