using CQRS.Mediator.Model;
using MediatR;

namespace CQRS.MediatR.API.Data.Command
{
    public class DeleteEmployeeQuery : IRequest<BasicResponse>
    {
        public int Id { get; set; }
    }
}
