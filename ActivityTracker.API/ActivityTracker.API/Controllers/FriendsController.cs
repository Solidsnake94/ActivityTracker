using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityTracker.API.Controllers
{
    [RoutePrefix("api/friends")]
    public class FriendsController : ApiController
    {

        private readonly IFriendshipRepository _friendshipRepository;

        public FriendsController(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateFriendship(Friendship friendship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _friendshipRepository.CreateFriendshipRequest(friendship);
            return Ok("Friendship Created");
        }

        [Route("create")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateFriendship(Friendship friendship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _friendshipRepository.UpdateFriendship(friendship);
            return Ok("Friendship Updated");
        }

        [Route("create")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteFriendship(int friendshipId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _friendshipRepository.DeleteFriendship(friendshipId);
            return Ok("Friendship Deleted");
        }
    }
}
