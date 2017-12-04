using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivityTracker.API.IRepositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<String> UpdateUserAsync(User updatedUser);
        Task<String> CreateUserAsync(User newUser);
        bool IsFriendOfUser(int userId, int friendsId);
    }
}
