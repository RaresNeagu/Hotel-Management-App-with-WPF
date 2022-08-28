using Hotel.Models;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    class UserRepository
    {
        private readonly Context users;

        public UserRepository()
        {
            users = new Context();
        }

        public User GetUser(string email,string password)
        {
           return users.Users.Where(user => user.Email == email && user.Password == password).FirstOrDefault();
        }

        public void AddUser(string FirstName,string LastName,string email,string password,string phone,bool deleted,UserRole role)
        {
            User user = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = email,
                Password = password,
                PhoneNumber = phone,
                Deleted = deleted,
                Role = role
            };
            users.Users.Add(user);
            users.SaveChanges();
        }
    }
}
