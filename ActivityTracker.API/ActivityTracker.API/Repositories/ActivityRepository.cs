using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ActivityTracker.API.Repositories
{
    public class ActivityRepository
    {
        private EntityModel db;

        public ActivityRepository()
        {
            db = new EntityModel();
        }

        public async Task<IEnumerable<Activity>> GetAllUserActivities(int userId)
        {
            List<Activity> activities = await db.Activities.Where(a => a.ActivityID == userId).ToListAsync();
            return activities;
        }

        public async Task<Activity> GetUserActivityById(int userId, int activityId)
        {
            Activity activity = await db.Activities.Where(a => a.ActivityID == activityId && a.UserID == userId).SingleOrDefaultAsync();
            return activity;
        }

        public async Task<string> UpdateUserActivity(Activity updatedActivity)
        {
            Activity activity = await db.Activities.Where(a => a.ActivityID == updatedActivity.ActivityID && a.UserID == updatedActivity.UserID).SingleOrDefaultAsync();
            activity = updatedActivity;
            await db.SaveChangesAsync();
            return "Activity succesfully updated";
        }

        public async Task<string> CreateUserActivity(Activity activity)
        {
            db.Activities.Add(activity);
            await db.SaveChangesAsync();
            return "Activity succesfully created";
        }


    }
}