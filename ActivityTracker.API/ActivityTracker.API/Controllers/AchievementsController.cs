using ActivityTracker.API.Repositories;
using System.Collections;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityTracker.API.Controllers
{
    public class AchievementsController : ApiController
    {
        private readonly AchievementRepository _achievementRepository = new AchievementRepository();

        [Route()]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserAchievements(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable achievements = await _achievementRepository.GetAllUserAchievements(userId);
            return Ok(achievements);
        }
    }
}
 