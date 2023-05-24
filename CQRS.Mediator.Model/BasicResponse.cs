using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.Model
{
    public class BasicResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        //public List<Employee> data { get; set; }
    }

    public class GetOperationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<Employee> data { get; set; }
    }

   /* public class Employee
    {
        public int Id { get; set; }
        public DateTime InsertionDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public int Age { get; set; }
    }*/
}
