using AutoMapper;
using Slugify;
using WebCastr.API.Models;
using WebCastr.API.Repositories;

namespace WebCastr.API.Services
{
    public class StationService
    {
        private readonly IRepository<Station> _repository;
        private readonly IMapper _mapper;

        public StationService(IRepository<Station> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<Station> GetAll()
        {
            return _repository.GetAll();
        }

        public StationGetDTO? Create(StationCreateDTO stationDTO)
        {
            Station station = _mapper.Map<Station>(stationDTO);

            if (string.IsNullOrWhiteSpace(station.ShortName))
                station.ShortName = Slugify(station.Name);

            station = _repository.Add(station);

            return _mapper.Map<StationGetDTO>(station);
        }

        private string Slugify(string name)
        {
            SlugHelper helper = new SlugHelper();
            return helper.GenerateSlug(name);
        }
    }
}
