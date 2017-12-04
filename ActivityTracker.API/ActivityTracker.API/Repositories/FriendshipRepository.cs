using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTracker.API.Repositories
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly IEntityModel _db;

        public FriendshipRepository(IEntityModel db)
        {
            _db = db;
        }

        public async Task<string> CreateFriendshipRequest(Friendship friendship)
        {
            try
            {
                _db.Friendships.Add(friendship);
                await _db.SaveChangesAsync();

                return "Friendship request created";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> UpdateFriendship(Friendship updatedfriendship)
        {
            try
            {
                Friendship friendship = await _db.Friendships
                    .Where(a => a.UserID == updatedfriendship.UserID && a.FriendID == updatedfriendship.FriendID)
                    .FirstOrDefaultAsync();
                if (friendship != null)
                {
                    friendship = updatedfriendship;
                }
                await _db.SaveChangesAsync();
                return "Friendship updated";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> DeleteFriendship(int id)
        {
            try
            {
                Friendship friendship = await _db.Friendships.Where(a => a.FriendshipID == id).FirstOrDefaultAsync();
                if (friendship != null)
                {
                    _db.Friendships.Remove(friendship);
                }
                await _db.SaveChangesAsync();
                return "Friendship deleted";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<int>> GetFriendListForUser(int userId)
        {
            try
            {
                List<int> friends = await _db.Friendships
                    .Where(a => a.UserID == userId && a.Status.ToUpper() == "FRIENDS")
                    .Select(a => a.FriendID).ToListAsync();
                return friends;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<int>> GetPendingFriendRequests(int userId)
        {
            try
            {
                List<int> pendingFriends = await _db.Friendships
                    .Where(a => a.UserID == userId && a.Status.ToUpper() == "PENDING")
                    .Select(a => a.FriendID).ToListAsync();
                return pendingFriends;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}