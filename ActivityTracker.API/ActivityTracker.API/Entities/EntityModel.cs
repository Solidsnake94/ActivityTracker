namespace ActivityTracker.API.Entities
{
    using System.Data.Entity;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBodyDetail> UserBodyDetails { get; set; }

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
    }
}
