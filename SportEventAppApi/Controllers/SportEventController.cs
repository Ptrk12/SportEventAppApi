using ApplicationCore.Models;
using Managers.managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportEventAppApi.Controllers
{
    [Route("sportevents")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        private readonly ISportEventManager _sportEventManager;

        public SportEventController(ISportEventManager sportEventManager)
        {
            _sportEventManager = sportEventManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllSportEvents()
        {
            var result = await _sportEventManager.GetAllSportEvents();
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSportEvent(SportEvent req)
        {
            var result = await _sportEventManager.CreateSportEvent(req);
            return result == true ? StatusCode(201) : Conflict();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateSportEvent(SportEvent req, int id)
        {
            var result = await _sportEventManager.UpdateSportEvent(req,id);
            return result == true ? StatusCode(201) : Conflict();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteSportEvent(int id)
        {
            var result = await _sportEventManager.DeleteSportEvent(id);
            return result == true ? StatusCode(201) : Conflict();
        }
    }
}
