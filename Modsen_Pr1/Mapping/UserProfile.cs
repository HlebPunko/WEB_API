using AutoMapper;
using Modsen_Pr1.DTO.Requests;
using Modsen_Pr1.DTO.Responses;
using Modsen_Pr1.Models;

namespace Modsen_Pr1.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateRequest, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
