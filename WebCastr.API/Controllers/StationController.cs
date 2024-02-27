using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WebCastr.API.DTO;
using WebCastr.Core.Models;

namespace WebCastr.API.Controllers
{
    [ApiController]
    [Route("/station")]
    [Tags("Stations")]
    public class StationController : ControllerBase
    {
        /// <summary>
        /// [NIY] Create a new radio station
        /// </summary>
        // POST /station
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] StationCreateDTO station)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns a list of stations
        /// </summary>
        // GET /stations
        [HttpGet]
        [Route("/stations")]
        public async Task<ActionResult<List<Station>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Returns informations about a station
        /// </summary>
        // GET /station/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Station>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Update informations about a station
        /// </summary>
        // PUT /station/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Station>> UpdateById(int id, [FromBody] StationUpdateDTO station)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [NIY] Permanently delete a station
        /// </summary>
        // DELETE /station/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Station>> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
