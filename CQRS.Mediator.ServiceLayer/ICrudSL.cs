using CQRS.Mediator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.ServiceLayer
{
    public interface ICrudSL
    {
        public Task<BasicResponse> Register(RegisterRequest request);
        public Task<LoginResponse> Login(RegisterRequest request);
        public Task<BasicResponse> InsertOperation(InsertRequest request);
        public Task<BasicResponse> UpdateOperation(UpdateRequest request);
        public Task<BasicResponse> DeleteOperation(int Id);
        public Task<GetOperationResponse> GetOperation();
        public Task<GetOperationResponse> GetOperationById(int Id);
    }
}
