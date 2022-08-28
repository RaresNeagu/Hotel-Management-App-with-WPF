using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }

        public string OfferName { get; set; }

        public int Price { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool Deleted { get; set; }

        public Room Room { get; set; }
    }
}
