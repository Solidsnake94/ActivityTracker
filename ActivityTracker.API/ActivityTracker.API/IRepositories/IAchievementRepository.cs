using ActivityTracker.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivityTracker.API.IRepositories
{
    public interface IAchievementRepository
    {
        Task<IEnumerable<Achievement>> GetAllUserAchievements(int userId);
    }
}