using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatService.Server.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public User Login(LoginInputModel loginInputModel)
        {
            var userCredentials = this.context.Users.Where(u => u.Username == loginInputModel.Username && u.Password == loginInputModel.Password).FirstOrDefault();
           
            if(userCredentials != null)
            {
                return userCredentials;
            }

            return userCredentials;
        }

        public User Register(User user)
        {
            if (user != null)
            {
                this.context.Users.Add(user);
                this.context.SaveChanges();
            }

            return user;
        }
    }
}
