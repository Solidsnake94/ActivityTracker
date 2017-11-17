namespace ActivityTracker.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserBodyDetail")]
    public partial class UserBodyDetail
    {
        public int UserBodyDetailID { get; set; }

        public short? Height { get; set; }

        public decimal? Weight { get; set; }

        public decimal? BodyFat { get; set; }

        public int UserID { get; set; }

        [StringLength(50)]
        public string AmountOfExercise { get; set; }

        public virtual User User { get; set; }
    }
}
