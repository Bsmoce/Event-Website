namespace Event.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        public int ID { get; set; }

        public int? Login_ID { get; set; }

        public int? Event_ID { get; set; }

        public int? Rate { get; set; }

        public virtual Event_Rez Event_Rez { get; set; }

        public virtual Login Login { get; set; }
    }
}