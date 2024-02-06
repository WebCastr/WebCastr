using AutoMapper;

namespace WebCaster.API.Models
{
    public class WebCasterProfile : Profile
    {
        public WebCasterProfile()
        {
            CreateMap<Station, StationCreateDTO>();
            CreateMap<StationCreateDTO, Station>();
            CreateMap<Station, StationGetDTO>();
        }
    }
}
