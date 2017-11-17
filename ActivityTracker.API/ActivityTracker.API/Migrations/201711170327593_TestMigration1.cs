namespace ActivityTracker.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievement",
                c => new
                    {
                        AchievementID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        AchievementTitle = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AchievementID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        LocationID = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(nullable: false, maxLength: 50),
                        PasswordSalt = c.String(nullable: false, maxLength: 10),
                        PowerUser = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Friendship",
                c => new
                    {
                        FriendshipID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FriendID = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.FriendshipID)
                .ForeignKey("dbo.User", t => t.FriendID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.FriendID);
            
            CreateTable(
                "dbo.Goal",
                c => new
                    {
                        GoalID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        GoalName = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        TargetDistance = c.Decimal(precision: 18, scale: 3),
                        TargetTime = c.Time(precision: 3),
                        Completed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GoalID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 3),
                        DistanceInKilometers = c.Decimal(nullable: false, precision: 18, scale: 3),
                        UserID = c.Int(nullable: false),
                        ActivityTypeID = c.Int(nullable: false),
                        GoalID = c.Int(),
                    })
                .PrimaryKey(t => t.ActivityID)
                .ForeignKey("dbo.ActivityType", t => t.ActivityTypeID)
                .ForeignKey("dbo.Goal", t => t.GoalID)
                .Index(t => t.ActivityTypeID)
                .Index(t => t.GoalID);
            
            CreateTable(
                "dbo.ActivityType",
                c => new
                    {
                        ActivityTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ActivityTypeID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Country = c.String(maxLength: 50),
                        City = c.String(maxLength: 100),
                        PostCode = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.UserBodyDetail",
                c => new
                    {
                        UserBodyDetailID = c.Int(nullable: false, identity: true),
                        Height = c.Short(),
                        Weight = c.Decimal(precision: 8, scale: 2),
                        BodyFat = c.Decimal(precision: 4, scale: 3),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserBodyDetailID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBodyDetail", "UserID", "dbo.User");
            DropForeignKey("dbo.User", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Goal", "UserID", "dbo.User");
            DropForeignKey("dbo.Activity", "GoalID", "dbo.Goal");
            DropForeignKey("dbo.Activity", "ActivityTypeID", "dbo.ActivityType");
            DropForeignKey("dbo.Friendship", "UserID", "dbo.User");
            DropForeignKey("dbo.Friendship", "FriendID", "dbo.User");
            DropForeignKey("dbo.Achievement", "UserID", "dbo.User");
            DropIndex("dbo.UserBodyDetail", new[] { "UserID" });
            DropIndex("dbo.Activity", new[] { "GoalID" });
            DropIndex("dbo.Activity", new[] { "ActivityTypeID" });
            DropIndex("dbo.Goal", new[] { "UserID" });
            DropIndex("dbo.Friendship", new[] { "FriendID" });
            DropIndex("dbo.Friendship", new[] { "UserID" });
            DropIndex("dbo.User", new[] { "LocationID" });
            DropIndex("dbo.Achievement", new[] { "UserID" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.UserBodyDetail");
            DropTable("dbo.Location");
            DropTable("dbo.ActivityType");
            DropTable("dbo.Activity");
            DropTable("dbo.Goal");
            DropTable("dbo.Friendship");
            DropTable("dbo.User");
            DropTable("dbo.Achievement");
        }
    }
}
