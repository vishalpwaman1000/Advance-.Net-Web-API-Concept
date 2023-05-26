using AutoMapper;
using CQRS.Mediator.Model;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Data.Command;
using CQRS.MediatR.API.Data.Query;
using CQRS.MediatR.API.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CQRS.MediatR.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [ActionFilterAttribute("CrudController")]
    [ResourceFilterAttribute]
    public class CrudController : ControllerBase
    {
        private readonly ICrudSL _crudSL;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CrudController(ICrudSL crudSL, IMediator mediator, IMapper mapper, IConfiguration configuration)
        {
            _crudSL = crudSL;
            _mediator = mediator;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            //BasicResponse response = new BasicResponse();
            try
            {
                //response = await _crudSL.Register(request);
                var response = await _mediator.Send(new RegisterEmployeeQuery(request.EmailID, request.Password));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new BasicResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
 
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(RegisterRequest request)
        {
            LoginResponse response = new LoginResponse();
            try
            {
                response = await _mediator.Send(new LoginEmployeeQuery(request.EmailID, request.Password));
                if (response.IsSuccess)
                {
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, request.EmailID),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    response.Token = GetToken(authClaims);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOperation(InsertRequest request)
        {

            //BasicResponse response = new BasicResponse();
            //CommonResponse response1 = new CommonResponse();
            try
            {
                var response = await _mediator.Send(new InsertEmployeeQuery(request.Name, request.Age));
                var response1 = _mapper.Map<CommonResponse>(response);
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

        private string GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token).ToString();
        }
    }
}
