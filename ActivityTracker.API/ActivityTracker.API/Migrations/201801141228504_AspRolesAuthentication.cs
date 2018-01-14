namespace ActivityTracker.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspRolesAuthentication : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.sysdiagrams", newName: "sysdiagram");
            DropForeignKey("dbo.Activity", "ActivityTypeID", "dbo.ActivityType");
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityRole", t => t.RoleId)
                .ForeignKey("dbo.IdentityUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(maxLength: 150),
                        ClaimValue = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.IdentityUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 500),
                        SecurityStamp = c.String(maxLength: 500),
                        PhoneNumber = c.String(maxLength: 50),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            AddColumn("dbo.User", "IdentityID", c => c.String());
            AddColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 50));
            AddForeignKey("dbo.Activity", "ActivityTypeID", "dbo.ActivityType", "ActivityTypeID");
            DropColumn("dbo.User", "PasswordHash");
            DropColumn("dbo.User", "PasswordSalt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "PasswordSalt", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.User", "PasswordHash", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Activity", "ActivityTypeID", "dbo.ActivityType");
            DropForeignKey("dbo.IdentityUserRole", "UserId", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserLogin", "UserId", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserClaim", "UserId", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserRole", "RoleId", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUser", "UserNameIndex");
            DropIndex("dbo.IdentityUserLogin", new[] { "UserId" });
            DropIndex("dbo.IdentityUserClaim", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRole", new[] { "RoleId" });
            DropIndex("dbo.IdentityUserRole", new[] { "UserId" });
            DropIndex("dbo.IdentityRole", "RoleNameIndex");
            DropColumn("dbo.User", "Password");
            DropColumn("dbo.User", "IdentityID");
            DropTable("dbo.IdentityUser");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            AddForeignKey("dbo.Activity", "ActivityTypeID", "dbo.ActivityType", "ActivityTypeID", cascadeDelete: true);
            RenameTable(name: "dbo.sysdiagram", newName: "sysdiagrams");
        }
    }
}
