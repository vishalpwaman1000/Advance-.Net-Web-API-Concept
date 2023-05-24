using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.Model
{
    public class CommonResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
