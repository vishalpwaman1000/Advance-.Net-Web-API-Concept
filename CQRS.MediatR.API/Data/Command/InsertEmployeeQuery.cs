using CQRS.Mediator.Model;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CQRS.MediatR.API.Data.Command
{
    public class InsertEmployeeQuery : IRequest<BasicResponse>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public InsertEmployeeQuery(string _Name, int _Age) 
        {
            Name = _Name;
            Age = _Age;
        }
    }
}
