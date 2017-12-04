using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivityTracker.API.IRepositories
{
    public interface IGoalRepository
    {
        Task<IEnumerable<Goal>> GetAllUserGoals(int userId);
        Task<List<Goal>> GetGoalForUserByFilter(int userId, string filter);
        Task<IEnumerable<Goal>> GetGoalsByStatus(int userId, bool status = true);
        Task<IEnumerable<Goal>> GetGoalsByFriendsId(int friendId);
        Task<String> CreateGoal(Goal goal);
        Task<String> UpdateGoal(Goal updateGoal);
        Task<String> DeleteGoal(int id);
    }
}