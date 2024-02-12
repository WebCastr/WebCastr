using AutoMapper;
using WebCastr.API.Models;

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
