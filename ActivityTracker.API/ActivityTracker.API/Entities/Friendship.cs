using Newtonsoft.Json;

namespace ActivityTracker.API.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Friendship")]
    public partial class Friendship
    {
        public int FriendshipID { get; set; }

        public int UserID { get; set; }

        public int FriendID { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual User User1 { get; set; }
    }
}
