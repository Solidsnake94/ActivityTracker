using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTracker.API.Repositories
{
    public class AchievementRepository:IAchievementRepository
    {
        private readonly IEntityModel _db;

        public AchievementRepository(IEntityModel db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Achievement>> GetAllUserAchievements( int userId)
        {
            try
            {
                List<Achievement> achievements = await _db.Achievements.Where(a => a.UserID == userId).ToListAsync();
                return achievements;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}