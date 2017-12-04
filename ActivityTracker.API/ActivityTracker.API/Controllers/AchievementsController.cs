using ActivityTracker.API.IRepositories;
using System.Collections;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityTracker.API.Controllers
{
    [RoutePrefix("api/achievemnts")]
    public class AchievementsController : ApiController
    {
        private readonly IAchievementRepository _achievementRepository;

        public AchievementsController(IAchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }

        [Route("")]
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
 