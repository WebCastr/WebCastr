using Microsoft.AspNetCore.Mvc;
using WebCastr.API.DTO;
using WebCastr.Core.Models;

namespace WebCastr.API.Controllers
{
    [ApiController]
    [Route("/station/{stationId}/playlist")]
    [Tags("Playlists")]
    public class PlaylistController : ControllerBase
    {
        /// <summary>
        /// [NIY] Create a new playlist
        /// </summary>
        // POST /station/{stationId}/playlist
        [HttpPost]
        public async Task<ActionResult> CreateAsync(int stationId, [FromBody] PlaylistCreateDTO station)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns a list of playlists
        /// </summary>
        // GET /station/{stationId}/playlists
        [HttpGet]
        [Route("/station/{stationId}/playlists")]
        public async Task<ActionResult<List<Playlist>>> GetAllAsync(int stationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns informations about a playlist
        /// </summary>
        // GET /station/{stationId}/playlist/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Playlist>> GetByIdAsync(int stationId, int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns a list of tracks
        /// </summary>
        // GET /station/{stationId}/playlist/{id}/tracks
        [HttpGet]
        [Route("{id}/tracks")]
        public async Task<ActionResult<List<Track>>> GetTracksAsync(int stationId, int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Update informations about a playlist
        /// </summary>
        // PUT /station/{stationId}/playlist/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Station>> UpdateById(int stationId, int id, [FromBody] StationUpdateDTO station)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Permanently delete a playlist
        /// </summary>
        // DELETE /station/{stationId}/playlist/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Station>> DeleteByIdAsync(int stationId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
