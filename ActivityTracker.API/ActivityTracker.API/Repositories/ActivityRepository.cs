﻿using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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
            try
            {
                List<Activity> activities = await db.Activities.Where(a => a.ActivityID == userId).ToListAsync();
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
                Activity activity = await db.Activities.Where(a => a.ActivityID == activityId && a.UserID == userId)
                    .SingleOrDefaultAsync();
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
                Activity activity = await db.Activities
                    .Where(a => a.ActivityID == updatedActivity.ActivityID && a.UserID == updatedActivity.UserID)
                    .SingleOrDefaultAsync();
                activity = updatedActivity;
                await db.SaveChangesAsync();
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
                db.Activities.Add(activity);
                await db.SaveChangesAsync();
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
                Activity activity = await db.Activities.Where(a => a.ActivityID == activityId).SingleOrDefaultAsync();
                if (activity != null)
                {
                    db.Activities.Remove(activity);
                }
                await db.SaveChangesAsync();
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
                List<Activity> activities = await db.Activities
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
                        activities = await db.Activities
                            .Where(a => a.UserID == userId)
                            .OrderByDescending(a => a.DistanceInKilometers)
                            .ToListAsync();
                        break;
                    case "time":
                        activities = await db.Activities
                            .Where(a => a.UserID == userId)
                            .OrderByDescending(a => a.DistanceInKilometers)
                            .ToListAsync();
                        break;
                    default:
                        activities = await db.Activities
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
                List<Activity> activity = await db.Activities
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
                List<Activity> activities = await db.Activities
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