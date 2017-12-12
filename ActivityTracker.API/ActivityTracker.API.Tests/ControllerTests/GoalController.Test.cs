using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using ActivityTracker.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Assert = NUnit.Framework.Assert;

namespace ActivityTracker.API.Tests.ControllerTests
{
    [TestClass]
    public class GoalController
    {
        [TestMethod]
        public async Task Test_Get_Goals_For_User()
        {
            //Arrange
            var goalRepository = new Mock<IGoalRepository>();
            var goal = new Goal()
            {
                GoalID = 4,
                Completed = false,
                UserID = 1,
                GoalName = "Fourth Goal"
            };

            var goals = GetGoals();
            goals.Add(goal);

            goalRepository.Setup(x => x.GetAllUserGoals(1)).ReturnsAsync(goals);

            var system = new Controllers.GoalsController(goalRepository.Object);

            IHttpActionResult actionResult = await system.GetGoalByUserId(1);

            var contentResult = ((OkNegotiatedContentResult<IEnumerable>) actionResult).Content;

            var enumerable = contentResult as IList<Goal> ?? contentResult.Cast<Goal>().ToList();
            Assert.AreEqual(4, enumerable.ToArray().Length);
            Assert.IsTrue(enumerable.ToArray().Contains(goal));
        }

       

        [TestMethod]
        public async Task Test_User_Creates_Goal()
        {
            var mockSet = new Mock<DbSet<Goal>>();
            var db = new Mock<IEntityModel>();
            db.Setup(x => x.Goals).Returns(mockSet.Object);

            var goalRepository = new Mock<GoalRepository>(db.Object);

            var model = GetGoals()[1];

            var system = new Controllers.GoalsController(goalRepository.Object);
            await system.CreateGoal(model);

            mockSet.Verify(m => m.Add(It.IsAny<Goal>()), Times.Once());
            db.Verify(m => m.SaveChangesAsync(), Times.Once());
        }

        [TestMethod]
        public async Task Test_Getting_Goals_Sorted_By_Filter()
        {
            var goalRepository = new Mock<IGoalRepository>();

            var goals = GetGoals();

            goalRepository.Setup(x => x.GetGoalForUserByFilter(1, "enddate")).ReturnsAsync(goals);

            var system = new Controllers.GoalsController(goalRepository.Object);

            IHttpActionResult actionResult = await system.GetUserGoalsByFilter(1, "enddate");

            var contentResult = ((OkNegotiatedContentResult<IEnumerable>) actionResult).Content;

            var enumerable = contentResult as IList<Goal> ?? contentResult.Cast<Goal>().ToList();
            Assert.AreEqual(3, enumerable.ToArray().Length);
            Assert.AreEqual(enumerable.ToArray().First().EndDate, goals[0].EndDate);
        }

        public List<Goal> GetGoals()
        {
            return new List<Goal>()
            {
                new Goal()
                {
                    GoalID = 1,
                    Completed = true,
                    UserID = 1,
                    GoalName = "Target",
                    EndDate = DateTime.Today.AddDays(10),
                },
                new Goal()
                {
                    GoalID = 2,
                    Completed = false,
                    UserID = 1,
                    GoalName = "Second Goal",
                    EndDate = DateTime.Today.AddDays(6),
                },
                new Goal()
                {
                    GoalID = 3,
                    Completed = false,
                    UserID = 1,
                    GoalName = "Third Goal",
                    EndDate = DateTime.Today.AddDays(3),
                }
            };
        }
    }
}