using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using ActivityTracker.API.IRepositories;
using ActivityTracker.API.Utillities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ActivityTracker.API.Entities
{
    using System.Data.Entity;

//    public partial class EntityModel : IdentityDbContext<IdentityUser>, IEntityModel
    public partial class EntityModel : IdentityDbContext<IdentityUser>, IEntityModel 
    {
        public EntityModel()
            : base("name=EntityModel")
        {
            Database.SetInitializer<EntityModel>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

        }
        //        public EntityModel()
        //            : base("name=EntityModel")
        //        {
        //        }

        //Identity and Authorization

        public DbSet<IdentityUserLogin> UserLogins { get; set; }
        public DbSet<IdentityUserClaim> UserClaims { get; set; }
        public DbSet<IdentityUserRole> UserRoles { get; set; }

        // ... your custom DbSets
        public virtual IDbSet<Achievement> Achievements { get; set; }
        public virtual IDbSet<Activity> Activities { get; set; }
        public virtual IDbSet<ActivityType> ActivityTypes { get; set; }
        public virtual IDbSet<Friendship> Friendships { get; set; }
        public virtual IDbSet<Goal> Goals { get; set; }
        public virtual IDbSet<Location> Locations { get; set; }
        public virtual IDbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual IDbSet<User> ActivityUsers { get; set; }
        //public virtual IDbSet<User> Users { get; set; }
        //public virtual IDbSet<User> Users { get; set; 
        public virtual IDbSet<UserBodyDetail> UserBodyDetails { get; set; }
        //public System.IO.TextWriter Log { get; set; }

        public static EntityModel Create()
        {
            return new EntityModel();
        }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Configure Asp Net Identity Tables
            modelBuilder.Entity<IdentityUser>().ToTable("IdentityUser");
            modelBuilder.Entity<IdentityUser>().Property(u => u.PasswordHash).HasMaxLength(500);
            modelBuilder.Entity<IdentityUser>().Property(u => u.SecurityStamp).HasMaxLength(500);
            modelBuilder.Entity<IdentityUser>().Property(u => u.PhoneNumber).HasMaxLength(50);

            modelBuilder.Entity<IdentityRole>().ToTable("IdentityRole");
            modelBuilder.Entity<IdentityUserRole>().ToTable("IdentityUserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("IdentityUserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("IdentityUserClaim");
            modelBuilder.Entity<IdentityUserClaim>().Property(u => u.ClaimType).HasMaxLength(150);
            modelBuilder.Entity<IdentityUserClaim>().Property(u => u.ClaimValue).HasMaxLength(500);


            // Custom tables 
            modelBuilder.Entity<Activity>()
                .Property(e => e.Time)
                .HasPrecision(3);

            modelBuilder.Entity<Activity>()
                .Property(e => e.DistanceInKilometers)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Goal>()
                .Property(e => e.TargetDistance)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Goal>()
                .Property(e => e.TargetTime)
                .HasPrecision(3);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Achievements)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friendships)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FriendID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friendships1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Goals)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserBodyDetails)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserBodyDetail>()
                .Property(e => e.Weight)
                .HasPrecision(8, 2);

            modelBuilder.Entity<UserBodyDetail>()
                .Property(e => e.BodyFat)
                .HasPrecision(4, 3);
        }


        // Overrided for printing errors while trying to update the database
//        public override int SaveChanges()
//        {
//            try
//            {
//                return base.SaveChanges();
//            }
//            catch (DbEntityValidationException e)
//            {
//                var newException = new FormattedDbEntityValidationException(e);
//                throw newException;
//            }
//        }
    }
}
