using CQRS.Mediator.Model;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CQRS.MediatR.API.Data.Command
{
    public class UpdateEmployeeQuery : IRequest<BasicResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public UpdateEmployeeQuery(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
