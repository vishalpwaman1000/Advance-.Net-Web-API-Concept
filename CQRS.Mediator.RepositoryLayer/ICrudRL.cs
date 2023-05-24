﻿using CQRS.Mediator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.RepositoryLayer
{
    public interface ICrudRL
    {
        public Task<BasicResponse> InsertOperation(InsertRequest request);
        public Task<BasicResponse> UpdateOperation(UpdateRequest request);
        public Task<BasicResponse> DeleteOperation(int Id);
        public Task<GetOperationResponse> GetOperation();
        public Task<GetOperationResponse> GetOperationById(int Id);
    }
}