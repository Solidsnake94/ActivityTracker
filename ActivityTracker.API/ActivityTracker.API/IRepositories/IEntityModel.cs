using ActivityTracker.API.Entities;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ActivityTracker.API.IRepositories
{
    public interface IEntityModel : IDisposable
    {
        IDbSet<Achievement> Achievements { get; set; }
        IDbSet<Activity> Activities { get; set; }
        IDbSet<ActivityType> ActivityTypes { get; set; }
        IDbSet<Friendship> Friendships { get; set; }
        IDbSet<Goal> Goals { get; set; }
        IDbSet<Location> Locations { get; set; }
        IDbSet<sysdiagram> sysdiagrams { get; set; }
        IDbSet<User> Users { get; set; }
        IDbSet<UserBodyDetail> UserBodyDetails { get; set; }

        Task<int> SaveChangesAsync();
    }
}