using CQRS.Mediator.Model;
using CQRS.Mediator.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.ServiceLayer
{
    public class CrudSL : ICrudSL
    {
        private readonly ICrudRL _crudRL;
        public CrudSL(ICrudRL crudRL) 
        { 
            _crudRL = crudRL;
        }

        public async Task<LoginResponse> Login(RegisterRequest request)
        {
            return await _crudRL.Login(request);
        }

        public async Task<BasicResponse> Register(RegisterRequest request)
        {
            return await _crudRL.Register(request);
        }

        public async Task<BasicResponse> DeleteOperation(int Id)
        {
            return await _crudRL.DeleteOperation(Id);
        }

        public async Task<GetOperationResponse> GetOperation()
        {
            return await _crudRL.GetOperation();
        }

        public async Task<GetOperationResponse> GetOperationById(int Id)
        {
            return await _crudRL.GetOperationById(Id);
        }

        public async Task<BasicResponse> InsertOperation(InsertRequest request)
        {
            return await _crudRL.InsertOperation(request);
        }

        public async Task<BasicResponse> UpdateOperation(UpdateRequest request)
        {
            return await _crudRL.UpdateOperation(request);
        }
    }
}
