using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using System.Collections;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityTracker.API.Controllers
{
    [RoutePrefix("api/activities")]
    public class ActivitiesController : ApiController
    {
        private readonly IActivityRepository _activityRepository;

        private readonly IUserRepository _userRepository;

        public ActivitiesController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public ActivitiesController(IActivityRepository activityRepository, IUserRepository userRepository)
        {
            _activityRepository = activityRepository;
            _userRepository = userRepository;

        }

        //api/activities/create
        [Route("create")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _activityRepository.CreateUserActivity(activity);
            return Ok("Activity created");
        }

        [Route("create")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _activityRepository.UpdateUserActivity(activity);
            return Ok("Activity has been updated");
        }

        // DELETE api/activities/5
        [Route("create")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteActivity(int activityId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _activityRepository.DeleteUserActivity(activityId);
            return Ok("Activity has been deleted");
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllUserActivities(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEnumerable activities = await _activityRepository.GetAllUserActivities(userId);
            return Ok(activities);
        }

        //api/activities?userId=1&activityId=1
        // Get Activity by activity ID
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetActivityById(int userId, int activityId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Activity activity = await _activityRepository.GetActivityByActivityId(userId, activityId);
            return Ok(activity);
        }

        [Route("activitytype")]
        [HttpGet]
        public async Task<IHttpActionResult> GetActivityByActivityType(int userId, int activityTypeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable activities = await _activityRepository.GetActivityByActivityTypeId(userId, activityTypeId);
            return Ok(activities);
        }

        [Route("filter")]
        [HttpGet]
        public async Task<IHttpActionResult> GetActivityByFilter(int userId, string filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable activities = await _activityRepository.GetActivitiesForUserByFilter(userId, filter);
            return Ok(activities);
        }

        [Route("goal")]
        [HttpGet]
        public async Task<IHttpActionResult> GetActivityByGoalID(int userId, int goalId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable activities = await _activityRepository.GetActivitiesByGoalID(userId, goalId);
            return Ok(activities);
        }

        [Route("friends")]
        [HttpGet]
        public async Task<IHttpActionResult> GetActivitiesByFriendsId(int userId, int friendsId)
        {
            if (!ModelState.IsValid && !_userRepository.IsFriendOfUser(userId,friendsId))
            {
                return BadRequest(ModelState);
            }

            IEnumerable activities = await _activityRepository.GetActivitiesByFriendsId(friendsId);
            return Ok(activities);
        }
        // Create activity
    }
}