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
    public class ActivitiesController
    {
        //Arrange  
        [TestMethod]
        public async Task Test_Get_Activity_By_ActivityID()
        {
            //Arrange
            var activitiesRepository = new Mock<IActivityRepository>();

            var model = new Activity()
            {
                ActivityID = 1,
                ActivityTypeID = 1,
                DistanceInKilometers = 22,
                CreatedDate = DateTime.Today,
                Time = TimeSpan.FromMinutes(22),
                UserID = 1
            };
            activitiesRepository.Setup(x => x.GetActivityByActivityId(1, 1)).ReturnsAsync(model);
            var system = new Controllers.ActivitiesController(activitiesRepository.Object);

            IHttpActionResult actionResult = await system.GetActivityById(1, 1);
            var contentResult = actionResult as OkNegotiatedContentResult<Activity>;


            Assert.AreEqual(model.UserID, contentResult.Content.UserID);
        }

        [TestMethod]
        public async Task Test_Get_Activities_By_Activity_Type()
        {
            var activitiesRepository = new Mock<IActivityRepository>();

            var activityType1 = new Activity
            {
                ActivityID = 1,
                ActivityTypeID = 1,
                DistanceInKilometers = 22,
                CreatedDate = DateTime.Today,
                Time = TimeSpan.FromMinutes(22),
                UserID = 1
            };
            var mockListType1 = new List<Activity>
            {
                activityType1,
                new Activity
                {
                    ActivityID = 2,
                    ActivityTypeID = 1,
                    DistanceInKilometers = 22,
                    CreatedDate = DateTime.Today,
                    Time = TimeSpan.FromMinutes(22),
                    UserID = 1
                }
            };

            var activityType2 = new Activity
            {
                ActivityID = 1,
                ActivityTypeID = 2,
                DistanceInKilometers = 22,
                CreatedDate = DateTime.Today,
                Time = TimeSpan.FromMinutes(22),
                UserID = 1
            };

            var mockListType2 = new List<Activity>
            {
                activityType2,
                new Activity
                {
                    ActivityID = 2,
                    ActivityTypeID = 2,
                    DistanceInKilometers = 22,
                    CreatedDate = DateTime.Today,
                    Time = TimeSpan.FromMinutes(22),
                    UserID = 1
                }
            };


            activitiesRepository.Setup(x => x.GetActivityByActivityTypeId(1, 1))
                .ReturnsAsync(mockListType1);
            activitiesRepository.Setup(x => x.GetActivityByActivityTypeId(1, 2))
                .ReturnsAsync(mockListType2);

            var system = new Controllers.ActivitiesController(activitiesRepository.Object);
            IHttpActionResult actionResult = await system.GetActivityByActivityType(1, 1);
            var contentResult = ((OkNegotiatedContentResult<IEnumerable>) actionResult).Content;

            var enumerable = contentResult as IList<Activity> ?? contentResult.Cast<Activity>().ToList();
            Assert.AreEqual(2, enumerable.ToArray().Length);
            Assert.IsTrue(enumerable.ToArray().Contains(activityType1));
            Assert.IsFalse(enumerable.ToArray().Contains(activityType2));

            IHttpActionResult actionResult2 = await system.GetActivityByActivityType(1, 2);
            var contentResult2 = ((OkNegotiatedContentResult<IEnumerable>) actionResult2).Content;
            var enumerable2 = contentResult2 as IList<Activity> ?? contentResult2.Cast<Activity>().ToList();
            Assert.AreEqual(2, enumerable2.ToArray().Length);
            Assert.IsTrue(enumerable2.ToArray().Contains(activityType2));
            Assert.IsFalse(enumerable2.ToArray().Contains(activityType1));
        }

        [TestMethod]
        public async Task Test_User_Creates_Activity()
        {
            var mockSet = new Mock<DbSet<Activity>>();
            var db = new Mock<IEntityModel>();
            db.Setup(x => x.Activities).Returns(mockSet.Object);

            var activitiesRepository = new Mock<ActivityRepository>(db.Object);

            var model = new Activity()
            {
                ActivityID = 1,
                ActivityTypeID = 1,
                DistanceInKilometers = 22,
                CreatedDate = DateTime.Today,
                Time = TimeSpan.FromMinutes(22),
                UserID = 1
            };

            var system = new Controllers.ActivitiesController(activitiesRepository.Object);
            await system.CreateActivity(model);

            mockSet.Verify(m => m.Add(It.IsAny<Activity>()), Times.Once());
            db.Verify(m => m.SaveChangesAsync(), Times.Once());
        }

       
        public List<Activity> GetActivities()
        {
            return new List<Activity>()
            {
                new Activity
                {
                    ActivityID = 1,
                    ActivityTypeID = 1,
                    DistanceInKilometers = 22,
                    CreatedDate = DateTime.Today,
                    Time = TimeSpan.FromMinutes(22),
                    UserID = 1
                },
                new Activity
                {
                    ActivityID = 2,
                    ActivityTypeID = 1,
                    DistanceInKilometers = 22,
                    CreatedDate = DateTime.Today,
                    Time = TimeSpan.FromMinutes(22),
                    UserID = 1
                }
            };
        }
    }
}