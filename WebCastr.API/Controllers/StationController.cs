using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WebCastr.Core.Requests;
using WebCastr.Core.Models;
using WebCastr.Core.Responses;

namespace WebCastr.API.Controllers
{
    [ApiController]
    [Tags("Stations")]
    public class StationController : ControllerBase
    {
        /// <summary>
        /// [NIY] Create a new radio station
        /// </summary>
        [HttpPost("/station")]
        public async Task<ActionResult<StationResponse>> CreateAsync([FromBody] StationCreateRequest station)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns a list of stations
        /// </summary>
        [HttpGet("/stations")]
        public async Task<ActionResult<List<StationResponse>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns informations about a station
        /// </summary>
        [HttpGet("/station/{id:guid}")]
        public async Task<ActionResult<StationResponse>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Update informations about a station
        /// </summary>
        [HttpPut("/station/{id:guid}")]
        public async Task<ActionResult<StationResponse>> UpdateById(Guid id, [FromBody] StationUpdateRequest station)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Permanently delete a station
        /// </summary>
        [HttpDelete("/station/{id:guid}")]
        public async Task<ActionResult> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Start a station
        /// </summary>
        [HttpPost("/station/{id:guid}/start")]
        public async Task<ActionResult> StartAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Stop a station
        /// </summary>
        [HttpPost("/station/{id:guid}/stop")]
        public async Task<ActionResult> StopAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Restart a station
        /// </summary>
        [HttpPost("/station/{id:guid}/restart")]
        public async Task<ActionResult> RestartAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
