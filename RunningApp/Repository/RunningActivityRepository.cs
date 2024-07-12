using Microsoft.EntityFrameworkCore;
using RunningApp.Data;
using RunningApp.Interfaces;
using RunningApp.Models;

namespace RunningApp.Repository
{
    public class RunningActivityRepository : IRunningActivityRepository
    {
        private readonly RunningAppDbContext _context;

        public RunningActivityRepository(RunningAppDbContext context)
        {
            this._context = context;
        }

        public bool Add(RunningActivity activity)
        {
            _context.Add(activity);
            return Save();
        }

        public bool Delete(RunningActivity activity)
        {
            _context.Remove(activity);
            return Save();
        }

        public async Task<IEnumerable<RunningActivity>> GetAll()
        {
            return await _context.RunningActivities.ToListAsync();
        }

        public async Task<RunningActivity> GetByIdAsync(int id)
        {
            return await _context.RunningActivities.FirstOrDefaultAsync(a => a.RunningActivityId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(RunningActivity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            return Save();
        }
    }
}
