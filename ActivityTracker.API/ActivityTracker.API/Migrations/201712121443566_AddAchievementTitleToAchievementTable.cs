namespace ActivityTracker.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAchievementTitleToAchievementTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achievement", "AchievementTitle", a => a.String(maxLength:50));
        }

        public override void Down()
        {
            DropColumn("dbo.Achievement", "Description");

        }
    }
}
