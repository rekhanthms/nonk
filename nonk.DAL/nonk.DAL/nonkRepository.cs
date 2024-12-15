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
        public List<User> GetAllUsers()
        {
            var users = (from user in context.Users
                         orderby user.Age
                         select user).ToList();
            return users;
        }

    }
}