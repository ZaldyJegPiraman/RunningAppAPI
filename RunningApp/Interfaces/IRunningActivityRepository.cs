using RunningApp.Models;

namespace RunningApp.Interfaces
{
    public interface IRunningActivityRepository
    {
        Task<IEnumerable<RunningActivity>> GetAll();
        Task<RunningActivity> GetByIdAsync(int id);
        bool Add(RunningActivity user);
        bool Update(RunningActivity user);
        bool Delete(RunningActivity user);
        bool Save();
    }
}
