using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WebCastr.API.Models;
using WebCastr.API.Services;

namespace WebCastr.API.Controllers
{
    [ApiController]
    [Route("api/station")]
    [Tags("Stations")]
    public class StationController : ControllerBase
    {
        private readonly StationService _service;

        public StationController(StationService service)
        {
            _service = service;
        }

        // POST /api/station
        [HttpPost]
        public IActionResult Create(StationCreateDTO stationDTO)
        {
            StationGetDTO stationGetDTO = _service.Create(stationDTO);

            return Ok(stationGetDTO);

            //return CreatedAtAction
        }

        // GET /api/stations
        [HttpGet]
        [Route("/api/stations")]
        public ActionResult<List<Station>> GetAll()
        {
            return _service.GetAll();
        }
    }
}
