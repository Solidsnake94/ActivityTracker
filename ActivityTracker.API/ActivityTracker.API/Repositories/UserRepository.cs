using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using ActivityTracker.API.Utillities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTracker.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IEntityModel _db;

       
        public UserRepository()
        {
            _db = new EntityModel();
           
        }

//        public UserRepository(IEntityModel db)
//        {
//            _db = db;
//        }


        public IEnumerable<User> GetAllUsers()
        {
            return _db.ActivityUsers;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _db.ActivityUsers.Where(u => u.UserID == id).SingleOrDefaultAsync();
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
                User user = await _db.ActivityUsers.Where(u => u.UserID == updatedUser.UserID).SingleOrDefaultAsync();
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
                _db.ActivityUsers.Add(newUser);
                await _db.SaveChangesAsync();
                return "User succesfully created";
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<String> CreateUserAsync(IdentityUser identityUser, User newUser)
        {
            try
            {
                User user = new User
                {
                    IdentityID = identityUser.Id,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    BirthDate = newUser.BirthDate,
                    Email = newUser.Email,
                    Password = identityUser.PasswordHash,
                    PowerUser = newUser.PowerUser,
                    LocationID = newUser.LocationID 
                };
                _db.ActivityUsers.Add(user);
                await _db.SaveChangesAsync();
                return "User succesfully created";
            }
            //            catch (Exception e)
            //            {
            //                throw e;
            //            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
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