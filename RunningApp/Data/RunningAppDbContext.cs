using Microsoft.EntityFrameworkCore;
using RunningApp.Models;

namespace RunningApp.Data
{
    public class RunningAppDbContext : DbContext
    {
        public RunningAppDbContext(DbContextOptions<RunningAppDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RunningActivity> RunningActivities { get; set; }

    }
}
