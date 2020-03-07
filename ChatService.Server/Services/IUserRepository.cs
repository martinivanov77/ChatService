using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatService.Server.Models
{
    public interface IUserRepository
    {
        public User Register(RegisterInputModel registerInputModel);
        public User Login(LoginInputModel loginInputModel);

    }
}
