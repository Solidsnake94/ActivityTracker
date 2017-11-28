using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTracker.API.Repositories
{
    public class FriendshipRepository
    {
        private EntityModel db;

        public FriendshipRepository()
        {
            db = new EntityModel();
        }

        public async Task<string> CreateFriendshipRequest(Friendship friendship)
        {
            try
            {
                db.Friendships.Add(friendship);
                await db.SaveChangesAsync();

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
                Friendship friendship = await db.Friendships
                    .Where(a => a.UserID == updatedfriendship.UserID && a.FriendID == updatedfriendship.FriendID)
                    .FirstOrDefaultAsync();
                if (friendship != null)
                {
                    friendship = updatedfriendship;
                }
                await db.SaveChangesAsync();
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
                Friendship friendship = await db.Friendships.Where(a => a.FriendshipID == id).FirstOrDefaultAsync();
                if (friendship != null)
                {
                    db.Friendships.Remove(friendship);
                }
                await db.SaveChangesAsync();
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
                List<int> friends = await db.Friendships
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
                List<int> pendingFriends = await db.Friendships
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