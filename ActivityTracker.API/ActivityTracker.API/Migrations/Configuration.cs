using System;
using System.Data.Entity.Migrations;
using ActivityTracker.API.Entities;
using ActivityTracker.API.Utillities;

namespace ActivityTracker.API.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EntityModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
           
            var r = new Random(1);

            var firstNames = DummyDbDataGenerator.UserFirstNames;
            var surnames = DummyDbDataGenerator.UserSurnames;

            // Seed Location Table =============================================================
            context.Locations.AddOrUpdate(u => u.LocationID, new Location
            {
                LocationID = 1,
                Country = "Denmark",
                City = "Copenhagen",
                PostCode = "2900"
            });


            // Seed Users Table =============================================================
            for (var i = 1; i < 20; i++)
                context.Users.AddOrUpdate(u => u.UserID, new User
                {
                    UserID = i,
                    FirstName = firstNames[i],
                    LastName = surnames[r.Next(0, 6)],
                    BirthDate = new DateTime(r.Next(1970, 1995), r.Next(1, 12), r.Next(1, 26)),
                    LocationID = 1,
                    Email = $"{firstNames[i]}{r.Next(1, 50)}@gmail.com",
                    PasswordHash = "@dadaSAkllds#ahhSAD",
                    PasswordSalt = "23e@!!32",
                    PowerUser = false
                });


            // Seed ActivityType Table ======================================================
            context.ActivityTypes.AddOrUpdate(a => a.ActivityTypeID,
                new ActivityType {ActivityTypeID = 1, Name = "Running"},
                new ActivityType {ActivityTypeID = 2, Name = "Swimming"}
            );


            // Seed Activity Table ======================================================
            for (int i = 1; i < 20; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    context.Activities.AddOrUpdate(a => a.ActivityID, new Activity()
                    {
                        ActivityID = i*j,
                        CreatedDate = new DateTime(r.Next(2016, 2017), r.Next(1, 12), r.Next(1, 26)),
                        Time = new TimeSpan(r.Next(1,5),r.Next(1,59),r.Next(1,59)),
                        DistanceInKilometers = new decimal(),
                        GoalID = null,
                        ActivityTypeID = 1,
                        UserID = i
                    });
                }

            }


            // Seed Activity Table ======================================================
            context.Goals.AddOrUpdate(g => g.GoalID, new Goal()
            {
                GoalID = 1,
                UserID = 1,
                Completed = false,
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                GoalName = "Test Goal",
                IsPublic = false,
                TargetDistance = (decimal)50.0,
                TargetTime = new TimeSpan(1,0,0)
            });


            context.SaveChanges();
        }
    }
}