using ActivityTracker.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivityTracker.API.IRepositories
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetAllUserActivities(int userId);
        Task<Activity> GetActivityByActivityId(int userId, int activityId);
        Task<string> UpdateUserActivity(Activity updatedActivity);
        Task<string> CreateUserActivity(Activity activity);
        Task<string> DeleteUserActivity(int activityId);
        Task<IEnumerable<Activity>> GetActivityByActivityTypeId(int userId, int activityTypeId);
        Task<IEnumerable<Activity>> GetActivitiesForUserByFilter(int userId, string filter = "created");
        Task<IEnumerable<Activity>> GetActivitiesByGoalID(int userId, int goalId);
        Task<IEnumerable<Activity>> GetActivitiesByFriendsId(int friendsId);
    }
}