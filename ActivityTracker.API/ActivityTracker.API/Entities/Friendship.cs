namespace ActivityTracker.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Friendship")]
    public partial class Friendship
    {
        public int FriendshipID { get; set; }

        public int UserID { get; set; }

        public int FriendID { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
