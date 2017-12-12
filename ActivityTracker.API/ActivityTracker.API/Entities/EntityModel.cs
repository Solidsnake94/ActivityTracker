using System.Data.Entity.Validation;
using ActivityTracker.API.IRepositories;
using ActivityTracker.API.Utillities;

namespace ActivityTracker.API.Entities
{
    using System.Data.Entity;

    public partial class EntityModel : DbContext, IEntityModel
    {
        public EntityModel()
            : base("name=EntityModel")
        { 
        }

        public virtual IDbSet<Achievement> Achievements { get; set; }
        public virtual IDbSet<Activity> Activities { get; set; }
        public virtual IDbSet<ActivityType> ActivityTypes { get; set; }
        public virtual IDbSet<Friendship> Friendships { get; set; }
        public virtual IDbSet<Goal> Goals { get; set; }
        public virtual IDbSet<Location> Locations { get; set; }
        public virtual IDbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<UserBodyDetail> UserBodyDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
