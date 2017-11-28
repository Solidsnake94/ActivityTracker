using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTracker.API.Repositories
{
    public class AchievementRepository
    {
        private EntityModel db;

        public AchievementRepository()
        {
            db = new EntityModel();
        }

        public async Task<IEnumerable<Achievement>> GetAllUserAchievements( int userId)
        {
            try
            {
                List<Achievement> achievements = await db.Achievements.Where(a => a.UserID == userId).ToListAsync();
                return achievements;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}