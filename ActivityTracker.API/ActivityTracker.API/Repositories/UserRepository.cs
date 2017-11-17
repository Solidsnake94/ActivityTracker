using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ActivityTracker.API.Repositories
{
    public class UserRepository
    {
        private EntityModel db;

        public UserRepository()
        {
            db = new EntityModel();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users;
        }

        public User GetUserById(int id)
        {
            return db.Users.Where(u => u.UserID == id).SingleOrDefault();
        }

        public async Task<String> UpdateUserAsync(User updatedUser)
        {
            User user = await db.Users.Where(u => u.UserID == updatedUser.UserID).SingleOrDefaultAsync();
            user = updatedUser;
            await db.SaveChangesAsync();
            return "User successfully updated";
        }

        public async Task<String> CreateUserAsync(User newUser)
        {
            db.Users.Add(newUser);
            await db.SaveChangesAsync();
            return "User succesfully created";
        }


    }
}