using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;


namespace ActivityTracker.API.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly EntityModel _db;

        public ActivityRepository(EntityModel db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Activity>> GetAllUserActivities(int userId)
        {
            //_db.Log = Console.Out;

            // Northwnd db = new Northwnd(@"c:\northwnd.mdf");


            try
            {
                _db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var activities = await _db.Activities.Where(a => a.UserID == userId).ToListAsync();
//                foreach (var a in activities)
//                {
//                    Console.WriteLine("\t {0}", a.ActivityID);
//                }
//
//                DbCommand dc = _db.GetCommand(activities);
//                Console.WriteLine("\nCommand Text: \n{0}", dc.CommandText);
//                Console.WriteLine("\nCommand Type: {0}", dc.CommandType);
//                Console.WriteLine("\nConnection: {0}", dc.Connection);
//
//                Console.ReadLine();
                return activities;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Activity> GetActivityByActivityId(int userId, int activityId)
        {
            try
            {
                Activity activity = await _db.Activities.Where(a => a.ActivityID == activityId && a.UserID == userId)
                    .SingleOrDefaultAsync();
                Console.WriteLine(activity.ToString());
                return activity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> UpdateUserActivity(Activity updatedActivity)
        {
            try
            {
                Activity activity = await _db.Activities
                    .Where(a => a.ActivityID == updatedActivity.ActivityID && a.UserID == updatedActivity.UserID)
                    .SingleOrDefaultAsync();
                activity = updatedActivity;
                await _db.SaveChangesAsync();
                return "Activity succesfully updated";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> CreateUserActivity(Activity activity)
        {
            try
            {
                _db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                var a = new
                {
                    CreatedDate = activity.CreatedDate,
                    Time = activity.Time,
                    DistanceInKilometers = activity.DistanceInKilometers,
                    UserID = activity.UserID,
                    ActivityTypeID = activity.ActivityTypeID
                };
                _db.Activities.Add(activity);

                await _db.SaveChangesAsync();
                return "Activity succesfully created";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> DeleteUserActivity(int activityId)
        {
            try
            {
                Activity activity = await _db.Activities.Where(a => a.ActivityID == activityId).SingleOrDefaultAsync();
                if (activity != null)
                {
                    _db.Activities.Remove(activity);
                }
                await _db.SaveChangesAsync();
                return "Activity has been deleted";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Activity>> GetActivityByActivityTypeId(int userId, int activityTypeId)
        {
            try
            {
                List<Activity> activities = await _db.Activities
                    .Where(a => a.UserID == userId && a.ActivityTypeID == activityTypeId)
                    .OrderByDescending(a => a.CreatedDate)
                    .ToListAsync();

                return activities;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Activity>> GetActivitiesForUserByFilter(int userId, string filter = "created")
        {
            try
            {
                List<Activity> activities;
                switch (filter.ToLower())
                {
                    case "distance":
                        activities = await _db.Activities
                            .Where(a => a.UserID == userId)
                            .OrderByDescending(a => a.DistanceInKilometers)
                            .ToListAsync();
                        break;
                    case "time":
                        activities = await _db.Activities
                            .Where(a => a.UserID == userId)
                            .OrderByDescending(a => a.DistanceInKilometers)
                            .ToListAsync();
                        break;
                    default:
                        activities = await _db.Activities
                            .Where(a => a.UserID == userId)
                            .OrderByDescending(a => a.CreatedDate)
                            .ToListAsync();
                        break;
                }
                return activities;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Activity>> GetActivitiesByGoalID(int userId, int goalId)
        {
            try
            {
                List<Activity> activity = await _db.Activities
                    .Where(a => a.GoalID == goalId && a.UserID == userId)
                    .OrderByDescending(a => a.CreatedDate)
                    .ToListAsync();
                return activity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Activity>> GetActivitiesByFriendsId(int friendsId)
        {
            try
            {
                List<Activity> activities = await _db.Activities
                    .Where(a => a.UserID == friendsId)
                    .OrderByDescending(a => a.CreatedDate)
                    .ToListAsync();
                return activities;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}