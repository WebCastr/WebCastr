using Microsoft.AspNetCore.Mvc;
using WebCastr.Core.Requests;
using WebCastr.Core.Models;
using WebCastr.Core.Responses;

namespace WebCastr.API.Controllers
{
    [ApiController]
    [Tags("Playlists")]
    public class PlaylistController : ControllerBase
    {
        /// <summary>
        /// [NIY] Create a new playlist
        /// </summary>
        [HttpPost("/station/{stationId:guid}/playlist")]
        public async Task<ActionResult<PlaylistResponse>> CreateAsync(Guid stationId, [FromBody] PlaylistCreateRequest station)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns a list of playlists
        /// </summary>
        [HttpGet("/station/{stationId:guid}/playlists")]
        public async Task<ActionResult<List<PlaylistResponse>>> GetAllAsync(Guid stationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns informations about a playlist
        /// </summary>
        [HttpGet("/station/{stationId}/playlist/{id}")]
        public async Task<ActionResult<PlaylistResponse>> GetByIdAsync(Guid stationId, Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns a list of tracks
        /// </summary>
        [HttpGet("/station/{stationId:guid}/playlist/{id:guid}/tracks")]
        public async Task<ActionResult<List<TrackResponse>>> GetTracksAsync(Guid stationId, Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Update informations about a playlist
        /// </summary>
        [HttpPut("/station/{stationId:guid}/playlist/{id:guid}")]
        public async Task<ActionResult<PlaylistResponse>> UpdateById(Guid stationId, Guid id, [FromBody] StationUpdateRequest station)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Permanently delete a playlist
        /// </summary>
        [HttpDelete("/station/{stationId:guid}/playlist/{id:guid}")]
        public async Task<ActionResult> DeleteByIdAsync(Guid stationId, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
