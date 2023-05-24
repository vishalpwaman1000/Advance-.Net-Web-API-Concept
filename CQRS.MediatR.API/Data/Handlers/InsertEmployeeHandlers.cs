using CQRS.Mediator.Model;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Data.Command;
using MediatR;

namespace CQRS.MediatR.API.Data.Handlers
{
    public class InsertEmployeeHandlers : IRequestHandler<InsertEmployeeQuery, BasicResponse>
    {
        private readonly ICrudSL _crudSL;
        public InsertEmployeeHandlers(ICrudSL crudSL) 
        {
            _crudSL = crudSL;
        }
        public async Task<BasicResponse> Handle(InsertEmployeeQuery request, CancellationToken cancellationToken)
        {

            return await _crudSL.InsertOperation(new InsertRequest()
            {
                Name = request.Name,
                Age = request.Age
            });
        }
    }
}
