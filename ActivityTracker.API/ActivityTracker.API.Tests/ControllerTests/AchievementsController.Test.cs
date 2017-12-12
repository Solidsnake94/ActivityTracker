using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Assert = NUnit.Framework.Assert;

namespace ActivityTracker.API.Tests.ControllerTests
{
    [TestClass]
    public class AchievementsController
    {
        [TestMethod]
        public async Task Test_Get_Achievements_For_User()
        {
            //Arrange
            var achievementMock = new Mock<IAchievementRepository>();
            var achievement = new Achievement()
            {
                UserID = 1,
                AchievementID = 1,
                AchievementTitle = "Bla",
                Description = "Bla bla bla"
            };

            var achievements = GetAchievements();
            achievements.Add(achievement);

            achievementMock.Setup(x => x.GetAllUserAchievements(1)).ReturnsAsync(achievements);

            var system = new Controllers.AchievementsController(achievementMock.Object);

            IHttpActionResult actionResult = await system.GetUserAchievements(1);

            var contentResult = ((OkNegotiatedContentResult<IEnumerable>) actionResult).Content;

            var enumerable = contentResult as IList<Achievement> ?? contentResult.Cast<Achievement>().ToList();
            Assert.AreEqual(4, enumerable.ToArray().Length);
            Assert.IsTrue(enumerable.ToArray().Contains(achievement));
        }
        
        public List<Achievement> GetAchievements()
        {
            return new List<Achievement>()
            {
                new Achievement()
                {
                    UserID = 1,
                    AchievementID = 1,
                    AchievementTitle = "Bla",
                    Description = "Bla bla bla"
                },
                new Achievement()
                {
                    UserID = 1,
                    AchievementID = 2,
                    AchievementTitle = "Bla 2",
                    Description = "Bla bla"
                },
                new Achievement()
                {
                    UserID = 1,
                    AchievementID = 2,
                    AchievementTitle = "Bla 3",
                    Description = "Bla bla"
                }
            };
        }
    }
}