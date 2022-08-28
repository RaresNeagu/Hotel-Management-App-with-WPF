using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Service
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public int PricePerDay { get; set; }

        public bool Deleted { get; set; }
    }
}
