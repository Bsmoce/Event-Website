namespace Event.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int Booking_ID { get; set; }

        public int? Ticket_ID { get; set; }

        public int? Event_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Start_dates { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_dates { get; set; }

        public virtual Event_Rez Event_Rez { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
