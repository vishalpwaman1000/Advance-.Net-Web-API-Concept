using CQRS.Mediator.Model;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Data.Command;
using MediatR;

namespace CQRS.MediatR.API.Data.Handlers
{
    public class RegisterEmployeehandlers : IRequestHandler<RegisterEmployeeQuery, BasicResponse>
    {
        private readonly ICrudSL _crudSL;
        public RegisterEmployeehandlers(ICrudSL crudSL)
        {
            _crudSL = crudSL;
        }

        public async Task<BasicResponse> Handle(RegisterEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _crudSL.Register(new RegisterRequest()
            {
                EmailID = request.EmailID,
                Password = request.Password
            });
        }
    }
}
