namespace ActivityTracker.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Achievements_Change_NameProperty_To_Description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achievement", "Description", c => c.String());
            DropColumn("dbo.Achievement", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Achievement", "Name", c => c.String());
            DropColumn("dbo.Achievement", "Description");
        }
    }
}
