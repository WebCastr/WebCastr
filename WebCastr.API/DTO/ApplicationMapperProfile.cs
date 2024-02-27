using AutoMapper;
using WebCastr.Core.Models;

namespace WebCastr.API.DTO
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Station, StationCreateDTO>().ReverseMap();
            CreateMap<Station, StationGetDTO>().ReverseMap();
        }
    }
}
