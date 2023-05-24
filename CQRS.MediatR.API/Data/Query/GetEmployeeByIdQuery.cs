using CQRS.Mediator.Model;
using MediatR;

namespace CQRS.MediatR.API.Data.Query
{
    public class GetEmployeeByIdQuery : IRequest<GetOperationResponse>
    {
        public int Id { get; set; }
    }
}
