using RunningApp.Models;
using System.Diagnostics.Eventing.Reader;

namespace RunningApp.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> GetAll();
        Task<UserProfile> GetByIdAsync(int id);
        bool Add(UserProfile user);
        bool Update(UserProfile user);
        bool Delete(UserProfile user);
        bool Save();
    }
}
