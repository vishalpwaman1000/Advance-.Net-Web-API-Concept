using AutoMapper;
using CQRS.Mediator.Model;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Data.Command;
using CQRS.MediatR.API.Data.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.MediatR.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ICrudSL _crudSL;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CrudController(ICrudSL crudSL, IMediator mediator, IMapper mapper)
        {
            _crudSL = crudSL;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> InsertOperation(InsertRequest request)
        {

            //BasicResponse response = new BasicResponse();
            //CommonResponse response1 = new CommonResponse();
            try
            {
                var response = await _mediator.Send(new InsertEmployeeQuery(request.Name, request.Age));
                var response1 =  _mapper.Map<CommonResponse>(response);
                return Ok(response1);
                //response = await _crudSL.InsertOperation(request);
            }
            catch (Exception ex)
            {
                /*response1.IsSuccess = true;
                response1.Message = ex.Message;*/
                return Ok(new BasicResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                });
            }

            
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateOperation(UpdateRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _mediator.Send(new UpdateEmployeeQuery(request.Id, request.Name, request.Age));
                //response = await _crudSL.UpdateOperation(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOperation([FromQuery] int Id)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _mediator.Send(new DeleteEmployeeQuery() { Id = Id });
                //response = await _crudSL.DeleteOperation(Id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetOperation()
        {
            //throw new UnauthorizedAccessException();
            GetOperationResponse response = new GetOperationResponse();
            try
            {
                response = await _mediator.Send(new GetEmployeeListQuery());
                //response = await _crudSL.GetOperation();
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetOperationById([FromQuery] int Id)
        {
            GetOperationResponse response = new GetOperationResponse();
            try
            {
                response = await _mediator.Send(new GetEmployeeByIdQuery() { Id = Id });
                //response = await _crudSL.GetOperationById(Id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

    }
}
