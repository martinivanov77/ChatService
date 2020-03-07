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

            if (userCredentials != null)
            {
                return userCredentials;
            }

            return userCredentials;
        }

        public User Register(RegisterInputModel registerInputModel)
        {
            User user = null;
            var userExists = this.context.Users.Any(u => u.Username == registerInputModel.Username);

            if (!userExists && registerInputModel.Password == registerInputModel.ConfirmPassword)
            {
                user = new User
                {
                    Username = registerInputModel.Username,
                    Password = registerInputModel.Password
                };
                this.context.Users.Add(user);
                this.context.SaveChanges();
            }

            return user;
        }
    }
}
