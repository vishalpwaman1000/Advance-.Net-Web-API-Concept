using CQRS.Mediator.Model;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Data.Query;
using MediatR;

namespace CQRS.MediatR.API.Data.Handlers
{
    public class GetEmployeeListHandlers : IRequestHandler<GetEmployeeListQuery, GetOperationResponse>
    {
        private readonly ICrudSL _crudSL;
        public GetEmployeeListHandlers(ICrudSL crudSL)
        {
            _crudSL = crudSL;
        }
        public async Task<GetOperationResponse> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await _crudSL.GetOperation();
        }
    }
}
