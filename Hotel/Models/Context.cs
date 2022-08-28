using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
       public  DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Facility> Facilities { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["connectionString"]);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7CFPQ4J;Initial Catalog=Hotel;Integrated Security=True");
        }
    }
}
