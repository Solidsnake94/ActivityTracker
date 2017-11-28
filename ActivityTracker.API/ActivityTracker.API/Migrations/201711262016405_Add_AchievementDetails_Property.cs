namespace ActivityTracker.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AchievementDetails_Property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achievement", "AchievementDetails", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Achievement", "AchievementDetails");
        }
    }
}
