using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatService.Server.Models
{
    public interface IUserRepository
    {
        public User Register(User user);
        public User Login(LoginInputModel loginInputModel);

    }
}
