namespace ActivityTracker.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AchievementAddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achievement", "Description", c => c.String());
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Achievement", "Description");
        }
    }
}
