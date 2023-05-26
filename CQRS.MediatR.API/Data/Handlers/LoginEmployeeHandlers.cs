using CQRS.Mediator.Model;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Data.Command;
using MediatR;

namespace CQRS.MediatR.API.Data.Handlers
{
    public class LoginEmployeeHandlers : IRequestHandler<LoginEmployeeQuery, LoginResponse>
    {
        private readonly ICrudSL _crudSL;
        public LoginEmployeeHandlers(ICrudSL crudSL) 
        {
            _crudSL = crudSL;
        }
        public async Task<LoginResponse> Handle(LoginEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _crudSL.Login(new RegisterRequest()
            {
                EmailID= request.EmailID,
                Password= request.Password,
            });
        }
    }
}
