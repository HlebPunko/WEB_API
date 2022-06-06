using AutoMapper;
using Modsen_Pr1.DTO.Requests;
using Modsen_Pr1.DTO.Responses;
using Modsen_Pr1.Models;

namespace Modsen_Pr1.Mapping
{
    public class EventInfoProfile : Profile
    {
        public EventInfoProfile()
        {
            CreateMap<EventInfoCreateRequest, EventInformation>();
            CreateMap<EventInformation, EventInfoResponse>();
        }
    }
}
