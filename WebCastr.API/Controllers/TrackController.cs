using Microsoft.AspNetCore.Mvc;
using WebCastr.Core.Requests;
using WebCastr.Core.Models;
using WebCastr.Core.Responses;

namespace WebCastr.API.Controllers
{
    [ApiController]
    [Tags("Tracks")]
    public class TrackController : ControllerBase
    {
        /// <summary>
        /// [NIY] Create a new track
        /// </summary>
        [HttpPost("/station/{stationId:guid}/track")]
        public async Task<ActionResult<TrackResponse>> CreateAsync(Guid stationId, [FromBody] TrackCreateRequest track)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns a list of tracks
        /// </summary>
        [HttpGet("/station/{stationId:guid}/tracks")]
        public async Task<ActionResult<List<TrackResponse>>> GetAllAsync(Guid stationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns informations about a track
        /// </summary>
        [HttpGet("/station/{stationId:guid}/track/{id:guid}")]
        public async Task<ActionResult<TrackResponse>> GetByIdAsync(Guid stationId, Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Update informations about a track
        /// </summary>
        [HttpPut("/station/{stationId:guid}/track/{id:guid}")]
        public async Task<ActionResult<TrackResponse>> UpdateById(Guid stationId, Guid id, [FromBody] TrackUpdateRequest mount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Permanently delete a track
        /// </summary>
        [HttpDelete("/station/{stationId:guid}/track/{id:guid}")]
        public async Task<ActionResult> DeleteByIdAsync(Guid stationId, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
