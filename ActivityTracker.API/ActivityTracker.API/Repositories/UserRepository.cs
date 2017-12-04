using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTracker.API.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly IEntityModel _db;
        private IFriendshipRepository _friendshipRepository;

        public UserRepository(IEntityModel db, IFriendshipRepository friendshipRepository)
        {
            _db = db;
            _friendshipRepository = friendshipRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _db.Users.Where(u => u.UserID == id).SingleOrDefaultAsync();
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
                User user = await _db.Users.Where(u => u.UserID == updatedUser.UserID).SingleOrDefaultAsync();
                user = updatedUser;
                await _db.SaveChangesAsync();
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
                _db.Users.Add(newUser);
                await _db.SaveChangesAsync();
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
                if (_db.Friendships.Any(a => a.UserID == userId && a.FriendID == friendsId && a.Status == "FRIENDS"))
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