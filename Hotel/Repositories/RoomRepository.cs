using Hotel.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Hotel.Repositories
{
    class RoomRepository
    {
        private readonly Context rooms;

        public RoomRepository()
        {
            rooms = new Context();
        }

        public List<Room> GetRooms()
        {
            //return rooms.Rooms.FromSqlRaw("GetRooms", new object[1]).Select(p => p.Images).ToList();
            return rooms.Rooms.Where(room => room.Deleted==false).Include(room=>room.Images).Include(room=>room.Facilities).ToList();
        }

        public List<Room> GetRoomsBetweenDates(DateTime checkIn,DateTime checkOut)
        {
            var id= rooms.Reservations.Where(reservation => (reservation.CheckOut > checkIn && reservation.CheckIn <= checkIn) || (reservation.CheckOut >= checkOut && reservation.CheckIn < checkOut)).Select(reservation => reservation.Room.RoomId).ToList();
            return rooms.Rooms.Where(room=>room.Deleted==false && !id.Contains(room.RoomId)).Include(room => room.Images).Include(room => room.Facilities).ToList();
        }

        public void AddRoom(string roomName,int pricePerNight,int maxOccupancy,List<Facility> facilities,List<RoomImage> images,bool deleted)
        {
            Room room = new Room()
            {
                RoomName = roomName,
                PricePerNight = pricePerNight,
                MaxOccupancy = maxOccupancy,
                Facilities = facilities,
                Images = images,
                Deleted = deleted
            };
            rooms.Rooms.Add(room);
            rooms.SaveChanges();
        }

        public void UpdateRoom(int id,string roomName, int pricePerNight, int maxOccupancy, List<Facility> facilities, List<RoomImage> images, bool deleted)
        {
            
            var oldRoom=rooms.Rooms.Where(room => room.RoomId == id).FirstOrDefault();
            if(oldRoom!=null)
            {
                oldRoom.RoomName = roomName;
                oldRoom.PricePerNight = pricePerNight;
                oldRoom.MaxOccupancy = maxOccupancy;
                oldRoom.Facilities = facilities;
                oldRoom.Images = images;
                oldRoom.Deleted = deleted;

                rooms.SaveChanges();
            }
        }

        public void DeleteRoom(int id, bool deleted)
        {
            var oldRoom = rooms.Rooms.Where(room => room.RoomId == id).FirstOrDefault();
            if (oldRoom != null)
            {
                oldRoom.Deleted = deleted;
                rooms.SaveChanges();
            }
        }
    }
}
