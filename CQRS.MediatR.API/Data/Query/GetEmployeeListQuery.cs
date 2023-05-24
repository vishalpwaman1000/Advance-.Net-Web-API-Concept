using CQRS.Mediator.Model;
using MediatR;

namespace CQRS.MediatR.API.Data.Query
{
    public class GetEmployeeListQuery : IRequest<GetOperationResponse>
    {
    }
}
