using CQRS.Mediator.Model;
using CQRS.Mediator.RepositoryLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediator.RepositoryLayer
{
    public class CrudRL : ICrudRL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CrudRL(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<LoginResponse> Login(RegisterRequest request)
        {
            LoginResponse response = new LoginResponse();
            response.IsSuccess = true;
            response.Message = "Login Successfully";
            try
            {
                var Result = _applicationDbContext
                    .fact_user_master
                    .Where(X => X.EmailID.ToLower() == request.EmailID.ToLower() &&
                              X.Password == request.Password).FirstOrDefault();
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Login In Failed";
                    return response;
                }


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> Register(RegisterRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Registration Successfully";
            try
            {
                bool Found = _applicationDbContext.fact_user_master.Any(X=>X.EmailID.ToLower()==request.EmailID.ToLower());
                if (Found)
                {
                    response.IsSuccess = false;
                    response.Message = "Email Already Exist.";
                    return response;
                }

                await _applicationDbContext.AddAsync(new fact_user_master()
                {
                    InsertionDate = DateTime.Now,
                    EmailID = request.EmailID,
                    Password = request.Password,
                });

                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<BasicResponse> DeleteOperation(int Id)
        {
            BasicResponse response = new BasicResponse()
            {
                IsSuccess = true,
                Message = "Successful"
            };
            try
            {
                var ResultSet = _applicationDbContext.Employees.Where(X => X.Id == Id).FirstOrDefault();
                if (ResultSet == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Data Not Found";
                    return response;
                }

                _applicationDbContext.Remove(ResultSet);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<GetOperationResponse> GetOperation()
        {
            GetOperationResponse response = new GetOperationResponse()
            {
                IsSuccess = true,
                Message = "Successful"
            };
            try
            {
                response.data = new List<Employee>();
                response.data = _applicationDbContext.Employees.ToList();
                if (response.data.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Data Not Found";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<GetOperationResponse> GetOperationById(int Id)
        {
            GetOperationResponse response = new GetOperationResponse()
            {
                IsSuccess = true,
                Message = "Successful"
            };
            try
            {
                response.data = new List<Employee>();
                response.data = _applicationDbContext.Employees.Where(X => X.Id == Id).ToList();
                if (response.data.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Data Not Found";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> InsertOperation(InsertRequest request)
        {
            BasicResponse response = new BasicResponse()
            {
                IsSuccess = true,
                Message = "Successful"
            };
            try
            {
                await _applicationDbContext.AddAsync(new Employee()
                {
                    InsertionDate = DateTime.Now,
                    Name = request.Name,
                    Age = request.Age
                });
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> UpdateOperation(UpdateRequest request)
        {
            BasicResponse response = new BasicResponse()
            {
                IsSuccess = true,
                Message = "Successful"
            };
            try
            {
                var ResultSet = _applicationDbContext.Employees.Where(X => X.Id == request.Id).FirstOrDefault();
                if (ResultSet == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Data Not Found";
                    return response;
                }

                ResultSet.Name = request.Name;
                ResultSet.Age = request.Age;
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
