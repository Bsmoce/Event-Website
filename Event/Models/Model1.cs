namespace Event.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Event_Rez> Event_Rez { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Cat_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Client_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Event_Rez>()
                .Property(e => e.Event_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.User_names)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.User_Role)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Users_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Venue>()
                .Property(e => e.Venue_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Venue>()
                .Property(e => e.Venue_Location)
                .IsUnicode(false);

            modelBuilder.Entity<Venue>()
                .Property(e => e.Venue_City)
                .IsUnicode(false);
        }
    }
}
