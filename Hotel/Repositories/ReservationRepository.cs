using Hotel.Models;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    class ReservationRepository
    {
        private readonly Context reservations;

        public ReservationRepository()
        {
            reservations = new Context();
        }

        public List<Reservation> GetReservations()
        {

            return reservations.Reservations.Include("Room").Where(reservation => reservation.Deleted == false).ToList();
        }

        public void AddReservation(List<Service> services, int price, bool deleted,Room room,ReservationStatus status,DateTime checkIn,DateTime checkOut,User user)
        {
            Reservation reservation = new Reservation
            {
               Services=services,
               Price=price,
               Deleted=deleted,
               Room=room,
               Status=status,
               CheckIn=checkIn,
               CheckOut=checkOut,
               User=user
            };
            reservations.Reservations.Add(reservation);
            reservations.SaveChanges();
        }

        public void UpdateReservation(int id, List<Service> services, int price, bool deleted, Room room, ReservationStatus status, DateTime checkIn, DateTime checkOut, User user)
        {

            var oldReservation = reservations.Reservations.Where(reservation => reservation.ReservationId == id).FirstOrDefault();
            if (oldReservation != null)
            {
                oldReservation.Services = services;
               oldReservation.Price = price;
               oldReservation.Deleted = deleted;
               oldReservation.Room = room;
               oldReservation.Status = status;
               oldReservation.CheckIn = checkIn;
               oldReservation.CheckOut = checkOut;
               oldReservation.User = user;

                reservations.SaveChanges();
            }
        }
    }
}
