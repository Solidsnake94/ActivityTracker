using Newtonsoft.Json;

namespace ActivityTracker.API.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

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

        [JsonIgnore]
        public virtual ActivityType ActivityType { get; set; }

        [JsonIgnore]
        public virtual Goal Goal { get; set; }
    }
}
