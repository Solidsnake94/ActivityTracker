namespace ActivityTracker.API.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ActivityType")]
    public partial class ActivityType
    {
        public int ActivityTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
