using nonk.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace nonkDBFirst.DAL
{
    public class nonkRepository
    {
        private NonkDbContext context;
        public nonkRepository(NonkDbContext context)
        {
            this.context = context;
        }
        //READ
        public List<User> GetAllUsers()
        {
            var users = (from user in context.Users
                         select user).ToList();
            return users;
        }

        //CREATE
        public bool AddUsers(params User[] users)
        {
            bool status = false;

            try
            {
                context.Users.AddRange(users);
                context.SaveChanges(); // Save changes to the database
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding users: {ex.Message}"); // Log the error
                status = false;
            }

            return status;
        }

        //UPDATE
        public bool UpdateUsers(int userId, string password)
        {
            bool status = false;
            User users = context.Users.Find(userId);
            try
            {
                if (users != null)
                {
                    users.Password = password;
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //DELETE
        public bool DeleteUsers(int UserId)
        {
            User user = new User();
            bool status = false;
            try
            {
                user = context.Users.Find(UserId);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

    }
}