using CQRS.Mediator.Model;
using MediatR;

namespace CQRS.MediatR.API.Data.Command
{
    public class RegisterEmployeeQuery : IRequest<BasicResponse>
    {
        public string EmailID { get; set; }
        public string Password { get; set; }
        public RegisterEmployeeQuery(string _EmailID, string _Password) 
        {
            EmailID = _EmailID;
            Password = _Password;
        }
    }
}
