using Microsoft.EntityFrameworkCore;
using RunningApp.Data;
using RunningApp.Interfaces;
using RunningApp.Models;

namespace RunningApp.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly RunningAppDbContext _context;

        public UserProfileRepository(RunningAppDbContext context)
        {
            this._context = context;
        }

        public bool Add(UserProfile user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(UserProfile user)
        {
            _context.Remove(user);
            return Save();
        }

        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _context.UserProfiles.FirstOrDefaultAsync(a=> a.UserId == id);
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
           return saved > 0? true: false;
        }

        public bool Update(UserProfile user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return Save();
        }
    }
}
