using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class RoomImage
    {
        public int RoomImageId { get; set; }
        public byte[] Image { get; set; }

        public bool Deleted { get; set; }
    }
}
