using CQRS.Mediator.Model;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Data.Command;
using MediatR;

namespace CQRS.MediatR.API.Data.Handlers
{
    public class DeleteEmployeeHandlers : IRequestHandler<DeleteEmployeeQuery, BasicResponse>
    {
        private readonly ICrudSL _crudSL;
        public DeleteEmployeeHandlers(ICrudSL crudSL) 
        {
            _crudSL = crudSL;
        }
        public async Task<BasicResponse> Handle(DeleteEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _crudSL.DeleteOperation(request.Id);
        }
    }
}
