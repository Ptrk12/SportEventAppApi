using ApplicationCore.Models;
using Managers.managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportEventAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        private readonly ISportEventManager _sportEventManager;

        public SportEventController(ISportEventManager sportEventManager)
        {
            _sportEventManager = sportEventManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSportEvents()
        {
            var result = await _sportEventManager.GetAllSportEvents();
            return Ok(result);
        }

        [HttpPost]
        [Route("/sportevents/create-sport-event")]
        public async Task<IActionResult> CreateSportEvent(SportEvent req)
        {
            var result = await _sportEventManager.CreateSportEvent(req);
            return Ok(result);
        }
    }
}
