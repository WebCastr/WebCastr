using Microsoft.AspNetCore.Mvc;
using WebCastr.Core.Requests;
using WebCastr.Core.Models;
using WebCastr.Core.Responses;

namespace WebCastr.API.Controllers
{
    [ApiController]
    [Tags("Mount Points")]
    public class MountPointController : ControllerBase
    {
        /// <summary>
        /// [NIY] Create a new mount point
        /// </summary>
        [HttpPost("/station/{stationId:guid}/mount")]
        public async Task<ActionResult<MountPointResponse>> CreateAsync(Guid stationId, [FromBody] MountPointCreateRequest mount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns a list of mount points
        /// </summary>
        [HttpGet("/station/{stationId:guid}/mounts")]
        public async Task<ActionResult<List<MountPointResponse>>> GetAllAsync(Guid stationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns informations about a mount point
        /// </summary>
        [HttpGet("/station/{stationId:guid}/mount/{id:guid}")]
        public async Task<ActionResult<MountPointResponse>> GetByIdAsync(Guid stationId, Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Update informations about a mount point
        /// </summary>
        [HttpPut("/station/{stationId}/mount/{id}")]
        public async Task<ActionResult<MountPointResponse>> UpdateById(Guid stationId, Guid id, [FromBody] MountPointUpdateRequest mount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Permanently delete a mount point
        /// </summary>
        [HttpDelete("/station/{stationId:guid}/mount/{id:guid}")]
        public async Task<ActionResult> DeleteByIdAsync(Guid stationId, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
