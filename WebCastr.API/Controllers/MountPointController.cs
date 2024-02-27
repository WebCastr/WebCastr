using Microsoft.AspNetCore.Mvc;
using WebCastr.API.DTO;
using WebCastr.Core.Models;

namespace WebCastr.API.Controllers
{
    [ApiController]
    [Route("/station/{stationId}/mount")]
    [Tags("Mount Points")]
    public class MountPointController : ControllerBase
    {
        /// <summary>
        /// [NIY] Create a new mount point
        /// </summary>
        // POST /station/{stationId}/mount
        [HttpPost]
        public async Task<ActionResult> CreateAsync(int stationId, [FromBody] MountPointCreateDTO mount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns a list of mount points
        /// </summary>
        // GET /station/{stationId}/mounts
        [HttpGet]
        [Route("/station/{stationId}/mounts")]
        public async Task<ActionResult<List<MountPoint>>> GetAllAsync(int stationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns informations about a mount point
        /// </summary>
        // GET /station/{stationId}/mount/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<MountPoint>> GetByIdAsync(int stationId, int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Update informations about a mount point
        /// </summary>
        // PUT /station/{stationId}/mount/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<MountPoint>> UpdateById(int stationId, int id, [FromBody] MountPointUpdateDTO mount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Permanently delete a mount point
        /// </summary>
        // DELETE /station/{stationId}/mount/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<MountPoint>> DeleteByIdAsync(int stationId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
