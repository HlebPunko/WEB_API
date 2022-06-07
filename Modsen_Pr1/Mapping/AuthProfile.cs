using AutoMapper;
using Modsen_Pr1.DTO.Requests;
using Modsen_Pr1.DTO.Responses;
using Modsen_Pr1.Models;

namespace Modsen_Pr1.Mapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<AuthRequest, User>();
        }
    }
}
