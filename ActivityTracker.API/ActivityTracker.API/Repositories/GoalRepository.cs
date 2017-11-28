using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTracker.API.Repositories
{
    public class GoalRepository
    {
        private EntityModel db;

        public GoalRepository()
        {
            db = new EntityModel();
        }

        public async Task<IEnumerable<Goal>> GetAllUserGoals(int userId)
        {
            List<Goal> goals = await db.Goals.Where(a => a.UserID == userId).ToListAsync();
            return goals;
        }

        public async Task<List<Goal>> GetGoalForUserByFilter(int userId, string filter = "startdate")
        {
            try
            {
                List<Goal> goals;
                switch (filter.ToLower())
                {
                    case "enddate":
                        goals = await db.Goals
                            .Where(a => a.UserID == userId)
                            .OrderByDescending(a => a.EndDate)
                            .ToListAsync();
                        break;

                    default:
                        goals = await db.Goals
                            .Where(a => a.UserID == userId)
                            .OrderByDescending(a => a.StartDate)
                            .ToListAsync();
                        break;
                }
                return goals;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Goal>> GetGoalsByStatus(int userId, bool status = true)
        {
            try
            {
                List<Goal> goals = await db.Goals
                    .Where(a => a.UserID == userId && a.Completed == status)
                    .OrderByDescending(a => a.StartDate)
                    .ToListAsync();
                return goals;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Goal>> GetGoalsByFriendsId(int friendId)
        {
            try
            {
                List<Goal> goals = await db.Goals.Where(a => a.UserID == friendId && a.IsPublic == true).ToListAsync();
                return goals;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> CreateGoal(Goal goal)
        {
            try
            {
                db.Goals.Add(goal);
                await db.SaveChangesAsync();
                return "Goal has been created";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> UpdateGoal(Goal updateGoal)
        {
            try
            {
                Goal goal = await db.Goals.Where(a => a.UserID == updateGoal.UserID).SingleOrDefaultAsync();
                goal = updateGoal;
                await db.SaveChangesAsync();
                return "Goal has been updated";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> DeleteGoal(int id)
        {
            try
            {
                Goal goal = await db.Goals.Where(a => a.UserID == id).SingleOrDefaultAsync();
                if (goal != null)
                {
                    db.Goals.Remove(goal);
                }
                await db.SaveChangesAsync();
                return "Goal has been deleted";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}