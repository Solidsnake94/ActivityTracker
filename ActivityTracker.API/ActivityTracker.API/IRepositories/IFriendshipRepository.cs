using ActivityTracker.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivityTracker.API.IRepositories
{
    public interface IFriendshipRepository
    {
        Task<string> CreateFriendshipRequest(Friendship friendship);
        Task<string> UpdateFriendship(Friendship updatedfriendship);
        Task<string> DeleteFriendship(int id);
        Task<List<int>> GetFriendListForUser(int userId);
        Task<List<int>> GetPendingFriendRequests(int userId);
    }
}
       
