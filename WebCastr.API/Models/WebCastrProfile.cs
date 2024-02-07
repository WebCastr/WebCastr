using AutoMapper;

namespace WebCastr.API.Models
{
    public class WebCastrProfile : Profile
    {
        public WebCastrProfile()
        {
            CreateMap<Station, StationCreateDTO>();
            CreateMap<StationCreateDTO, Station>();
            CreateMap<Station, StationGetDTO>();
        }
    }
}
