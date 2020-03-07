using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatService.Server.Models
{
    public class RegisterInputModel
    {
        [Required(ErrorMessage = "Please enter a username for your account!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password!")]
        public string ConfirmPassword { get; set; }
    }
}
