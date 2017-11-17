namespace ActivityTracker.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Achievement")]
    public partial class Achievement
    {
        public int AchievementID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string AchievementTitle { get; set; }

        public virtual User User { get; set; }
    }
}
