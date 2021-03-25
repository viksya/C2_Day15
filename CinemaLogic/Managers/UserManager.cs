using CinemaLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaLogic.Managers
{
    public class UserManager
    {
        public void Register(string username, string email, string password)
        {
            using (var db = new CinemaDb())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
                if (existingUser != null)
                {
                    throw new LogicException("That username is already in use!");
                }

                existingUser = db.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
                if (existingUser != null)
                {
                    throw new LogicException("That e-mail is already in use!");
                }

                if (!password.IsPasswordOk())
                {
                    throw new LogicException("Password should be at least 6 symbols!");
                }

                db.Users.Add(new Users()
                {
                    Email = email,
                    Password = password,
                    Username = username,
                });
                db.SaveChanges();
            }
        }

        public Users GetUser(string username, string password)
        {
            using (var db = new CinemaDb())
            {
                return db.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower() && u.Password == password);
            }
        }

        public void Update(int curUserId, int bookingId)
        {
            using (var db = new CinemaDb())
            {
                var bookingData = db.Bookings.FirstOrDefault(b => b.Id == bookingId);

                bookingData.UserId = curUserId;

                db.SaveChanges();
            }
        }
    }
}
