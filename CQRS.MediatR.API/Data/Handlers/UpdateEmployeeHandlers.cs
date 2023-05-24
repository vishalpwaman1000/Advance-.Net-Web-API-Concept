using CQRS.Mediator.Model;
using CQRS.Mediator.RepositoryLayer;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Data.Command;
using MediatR;

namespace CQRS.MediatR.API.Data.Handlers
{
    public class UpdateEmployeeHandlers : IRequestHandler<UpdateEmployeeQuery, BasicResponse>
    {
        private readonly ICrudSL _crudSL;
        public UpdateEmployeeHandlers(ICrudSL crudSL)
        {
            _crudSL = crudSL;
        }
        public async Task<BasicResponse> Handle(UpdateEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _crudSL.UpdateOperation(new UpdateRequest() { Id = request.Id, Name = request.Name, Age = request.Age });
        }
    }
}
