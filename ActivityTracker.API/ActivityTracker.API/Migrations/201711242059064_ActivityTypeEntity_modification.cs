namespace ActivityTracker.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityTypeEntity_modification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activity", "ActivityTypeID", "dbo.ActivityType");
            AddForeignKey("dbo.Activity", "ActivityTypeID", "dbo.ActivityType", "ActivityTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activity", "ActivityTypeID", "dbo.ActivityType");
            AddForeignKey("dbo.Activity", "ActivityTypeID", "dbo.ActivityType", "ActivityTypeID");
        }
    }
}
