using AutoMapper;
using CQRS.Mediator.Model;

namespace CQRS.MediatR.API.Mappers
{
    public class AccountProfile : Profile
    {
        public AccountProfile() 
        {
            CreateMap<BasicResponse, CommonResponse>();

        }
    }
}
