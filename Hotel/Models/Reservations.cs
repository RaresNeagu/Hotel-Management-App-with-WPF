using Hotel.Utils;
using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public User User { get; set; }

        public Room Room { get; set; }

        public bool Deleted { get; set; }

        public ReservationStatus Status { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int Price { get; set; }

        public List<Service> Services { get; set; }
    }
}