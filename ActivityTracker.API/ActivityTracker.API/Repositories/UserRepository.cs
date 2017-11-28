using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTracker.API.Repositories
{
    public class UserRepository
    {
        private EntityModel db;
        private FriendshipRepository _friendshipRepository;

        public UserRepository()
        {
            db = new EntityModel();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await db.Users.Where(u => u.UserID == id).SingleOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> UpdateUserAsync(User updatedUser)
        {
            try
            {
                User user = await db.Users.Where(u => u.UserID == updatedUser.UserID).SingleOrDefaultAsync();
                user = updatedUser;
                await db.SaveChangesAsync();
                return "User successfully updated";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<String> CreateUserAsync(User newUser)
        {
            try
            {
                db.Users.Add(newUser);
                await db.SaveChangesAsync();
                return "User succesfully created";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

//        public async Task<IEnumerable<User>> GetFriendsByUserId(int userId)
//        {
//            try
//            {
//                var friends = _friendshipRepository.GetFriendListForUser(userId);
//                
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

        public bool IsFriendOfUser(int userId, int friendsId)
        {
            try
            {
                if (db.Friendships.Any(a => a.UserID == userId && a.FriendID == friendsId && a.Status == "FRIENDS"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}