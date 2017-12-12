namespace ActivityTracker.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsPublicToGoalInDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goal", "IsPublic", p => p.Boolean(nullable:true));
        }

        public override void Down()
        {
            DropColumn("dbo.Goal", "IsPublic");
        }
    }
}
