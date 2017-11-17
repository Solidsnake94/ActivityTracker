namespace ActivityTracker.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        public int ActivityID { get; set; }

        public DateTime CreatedDate { get; set; }

        public TimeSpan Time { get; set; }

        public decimal DistanceInKilometers { get; set; }

        public int UserID { get; set; }

        public int ActivityTypeID { get; set; }

        public int? GoalID { get; set; }

        public virtual ActivityType ActivityType { get; set; }

        public virtual Goal Goal { get; set; }
    }
}
