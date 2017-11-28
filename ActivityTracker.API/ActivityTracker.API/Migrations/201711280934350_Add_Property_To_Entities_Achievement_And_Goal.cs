namespace ActivityTracker.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Property_To_Entities_Achievement_And_Goal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achievement", "Name", c => c.String());
            AddColumn("dbo.Goal", "IsPublic", c => c.Boolean());
            DropColumn("dbo.Achievement", "AchievementDetails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Achievement", "AchievementDetails", c => c.String());
            DropColumn("dbo.Goal", "IsPublic");
            DropColumn("dbo.Achievement", "Name");
        }
    }
}
