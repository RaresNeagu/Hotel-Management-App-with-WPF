using Hotel.Utils;
using System.Collections.Generic;

namespace Hotel.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public int PricePerNight { get; set; }

        public int MaxOccupancy { get; set; }

        public List<Facility> Facilities { get; set; }

        public List<RoomImage> Images { get; set; }

        public bool Deleted { get; set; }

        public List<Offer> Offers { get; set; }
    }
}