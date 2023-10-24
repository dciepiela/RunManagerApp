using Microsoft.EntityFrameworkCore;
using RunManagerWebApp.Data;
using RunManagerWebApp.Data.Interfaces;
using RunManagerWebApp.Models;

namespace RunManagerWebApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context= context;
        }
        public void Add(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public void Update(AppUser appUser)
        {
            _context.Update(appUser);
            _context.SaveChanges();
        }
    }
}
