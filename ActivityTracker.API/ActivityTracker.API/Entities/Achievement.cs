using Newtonsoft.Json;

namespace ActivityTracker.API.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Achievement")]
    public partial class Achievement
    {
        public int AchievementID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string AchievementTitle { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
