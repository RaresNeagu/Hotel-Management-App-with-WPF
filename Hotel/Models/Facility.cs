using System.Collections.Generic;

namespace Hotel.Models
{
    public class Facility
    {
        public int FacilityId { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }

        public List<Room> RoomWithFacility { get; set; }
    }
}