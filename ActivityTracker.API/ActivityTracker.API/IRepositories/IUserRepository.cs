using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ActivityTracker.API.IRepositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<String> UpdateUserAsync(User updatedUser);
        Task<String> CreateUserAsync(User newUser);
        Task<String> CreateUserAsync(IdentityUser identityUser, User newUser);
        bool IsFriendOfUser(int userId, int friendsId);
    }
}
