namespace Event.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Venue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venue()
        {
            Event_Rez = new HashSet<Event_Rez>();
        }

        [Key]
        public int Venue_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Venue_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Venue_Location { get; set; }

        [Required]
        [StringLength(50)]
        public string Venue_City { get; set; }

        public int? Venue_Capacity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event_Rez> Event_Rez { get; set; }
    }
}
