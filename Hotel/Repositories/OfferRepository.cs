using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    class OfferRepository
    {
        private readonly Context offers;

        public OfferRepository()
        {
            offers = new Context();
        }

        public List<Offer> GetOffers()
        {
            return offers.Offers.Where(offer => offer.Deleted == false).ToList();
        }

        public void AddOffer(string offerName, int price, DateTime checkIn, DateTime checkOut, Room room, bool deleted)
        {
            Offer offer = new Offer()
            {
                OfferName = offerName,
                Price = price,
                CheckIn = checkIn,
                CheckOut = checkOut,
                Deleted = deleted,
                
            };
            var newRoom=offers.Rooms.Where(rooom => room.RoomId == rooom.RoomId).FirstOrDefault();
            if(newRoom!=null)
            {
                if (newRoom.Offers == null)
                {
                    newRoom.Offers = new List<Offer>();
                }
                newRoom.Offers.Add(offer);
            }

            offers.SaveChanges();
        }

        public void UpdateOffer(int id, string offerName, int price, DateTime checkIn, DateTime checkOut, Room room, bool deleted)
        {

            var oldOffer = offers.Offers.Where(offer => offer.OfferId == id).FirstOrDefault();
            if (oldOffer != null)
            {
                oldOffer.OfferName = offerName;
                oldOffer.Price = price;
                oldOffer.CheckIn = checkIn;
                oldOffer.CheckOut = checkOut;
                oldOffer.Deleted = deleted;


                offers.SaveChanges();
            }
        }

        public void DeleteOffer(int id, bool deleted)
        {
            var oldOffer = offers.Offers.Where(offer => offer.OfferId == id).FirstOrDefault();
            if (oldOffer != null)
            {
                oldOffer.Deleted = deleted;
                offers.SaveChanges();
            }
        }
    }
}
