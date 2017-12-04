﻿using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using System.Collections;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityTracker.API.Controllers
{
    [RoutePrefix("api/goals")]
    public class GoalsController : ApiController
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IUserRepository _userRepository;

        public GoalsController(IGoalRepository goalRepository, IUserRepository userRepository)
        {
            _goalRepository = goalRepository;
            _userRepository = userRepository;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateGoal(Goal goal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _goalRepository.CreateGoal(goal);
            return Ok("Goal created");
        }

        [Route("create")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateGoal(Goal goal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _goalRepository.UpdateGoal(goal);
            return Ok("Goal was updated");
        }

        [Route("create")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteGoal(int goalId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _goalRepository.DeleteGoal(goalId);
            return Ok("Goal Deleted");
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetGoalByUserId(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable goals = await _goalRepository.GetAllUserGoals(userId);
            return Ok(goals);
        }

        [Route("filter")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserGoalsByFilter(int userId, string filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable goals = await _goalRepository.GetGoalForUserByFilter(userId, filter);
            return Ok(goals);
        }

        [Route("status")]
        [HttpGet]
        public async Task<IHttpActionResult> GetGoalsByStatus(int userId, bool status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable goals = await _goalRepository.GetGoalsByStatus(userId, status);
            return Ok(goals);
        }

        [Route("friends")]
        [HttpGet]
        public async Task<IHttpActionResult> GetGoalsByFriendId(int userId, int friendId)
        {
            if (!ModelState.IsValid && !_userRepository.IsFriendOfUser(userId, friendId))
            {
                return BadRequest(ModelState);
            }

            IEnumerable goals = await _goalRepository.GetGoalsByFriendsId(friendId);
            return Ok(goals);
        }
    }
}