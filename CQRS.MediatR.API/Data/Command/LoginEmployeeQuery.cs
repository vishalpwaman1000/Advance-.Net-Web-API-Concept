using CQRS.Mediator.Model;
using MediatR;

namespace CQRS.MediatR.API.Data.Command
{
    public class LoginEmployeeQuery : IRequest<LoginResponse>
    {
        public string EmailID { get; set; }
        public string Password { get; set; }
        public LoginEmployeeQuery(string _EmailID, string _Password) 
        {
            EmailID = _EmailID;
            Password = _Password;
        }
    }
}
