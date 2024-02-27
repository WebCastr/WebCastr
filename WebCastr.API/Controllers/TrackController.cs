using Microsoft.AspNetCore.Mvc;
using WebCastr.API.DTO;
using WebCastr.Core.Models;

namespace WebCastr.API.Controllers
{
    [ApiController]
    [Route("/station/{stationId}/track")]
    [Tags("Tracks")]
    public class TrackController : ControllerBase
    {
        /// <summary>
        /// [NIY] Create a new track
        /// </summary>
        // POST /station/{stationId}/track
        [HttpPost]
        public async Task<ActionResult> CreateAsync(int stationId, [FromBody] TrackCreateDTO track)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns a list of tracks
        /// </summary>
        // GET /station/{stationId}/tracks
        [HttpGet]
        [Route("/station/{stationId}/tracks")]
        public async Task<ActionResult<List<Track>>> GetAllAsync(int stationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns informations about a track
        /// </summary>
        // GET /station/{stationId}/track/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Track>> GetByIdAsync(int stationId, int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Update informations about a track
        /// </summary>
        // PUT /station/{stationId}/track/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Track>> UpdateById(int stationId, int id, [FromBody] TrackUpdateDTO mount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Permanently delete a track
        /// </summary>
        // DELETE /station/{stationId}/track/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Track>> DeleteByIdAsync(int stationId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
