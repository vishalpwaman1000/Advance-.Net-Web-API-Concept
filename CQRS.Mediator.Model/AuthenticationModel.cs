using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.Model
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
