using Newtonsoft.Json;

namespace ActivityTracker.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Goal")]
    public partial class Goal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goal()
        {
            Activities = new HashSet<Activity>();
        }

        public int GoalID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string GoalName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? TargetDistance { get; set; }

        public TimeSpan? TargetTime { get; set; }

        public bool Completed { get; set; }

        public bool? IsPublic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Activity> Activities { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
