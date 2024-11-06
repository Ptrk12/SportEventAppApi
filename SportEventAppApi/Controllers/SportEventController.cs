using ApplicationCore.Models.req;
using Managers.managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportEventAppApi.Controllers
{
    [Route("/sportevents")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        private readonly ISportEventManager _sportEventManager;

        public SportEventController(ISportEventManager sportEventManager)
        {
            _sportEventManager = sportEventManager;
        }

        ///<summary>
        ///  Get all sport events which user is assigned to
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Authorize]
        [Route("current-user-events")]
        public async Task<IActionResult> GetCurrentLoggedUserEventsAssignedTo()
        {
            var result = await _sportEventManager.GetCurrentLoggedUserEventsAssignedTo();
            return Ok(result);
        }

        ///<summary>
        ///  Get all sport events available in the system
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllSportEvents()
        {
            var result = await _sportEventManager.GetAllSportEvents();
            return Ok(result);
        }

        /// <summary>
        /// Create sport event in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/sportevents
        ///     {
        ///         "eventName": "My event",
        ///         "discipline": "Football",
        ///         "skillLevel": "Amateur",
        ///         "price":12,
        ///         "objectId":4,
        ///         "amountOfPlayers":12,
        ///         "time":60,
        ///         "dateWhen":"2024-01-01T12:00:000",
        ///         "isMultisportCard":false
        ///     }
        ///
        /// </remarks>
        /// <param name="req">Sport event post request</param>
        /// <returns>Returns 201 if the sport event is created, or a conflict response if it fails.</returns>
        /// <response code="204">Successfully created the sport event</response>
        /// <response code="409">A conflict occurred, sport event was not created</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateSportEvent(CreateSportEventReq req)
        {
            var result = await _sportEventManager.CreateSportEvent(req);
            return result == true ? StatusCode(201) : Conflict();
        }

        /// <summary>
        /// Update sport event in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/sportevents/12
        ///     {
        ///         "eventName": "My event",
        ///         "discipline": "Football",
        ///         "skillLevel": "Amateur",
        ///         "price":12,
        ///         "objectId":4,
        ///         "amountOfPlayers":12,
        ///         "time":60,
        ///         "dateWhen":"2024-01-01T12:00:000",
        ///         "isMultisportCard":false
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Id of the sport event</param>
        /// <param name="req">Sport event update request</param>
        /// <response code="204">Successfully updated the sport event</response>
        /// <response code="409">A conflict occurred, sport event was not updated</response>
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateSportEvent(CreateSportEventReq req, int id)
        {
            var result = await _sportEventManager.UpdateSportEvent(req,id);
            return result == true ? StatusCode(201) : Conflict();
        }

        /// <summary>
        /// Remove sport event from the system (only those events that do not have any assigned people to them)
        /// </summary>
        /// <param name="id">Id of the sport event</param>
        /// <response code="204">Successfully removed the sport event</response>
        /// <response code="409">A conflict occurred, spot event was not removed</response>
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> DeleteSportEvent(int id)
        {
            var result = await _sportEventManager.DeleteSportEvent(id);
            return result == true ? StatusCode(204) : Conflict();
        }

        /// <summary>
        /// Assign or remove yourself from sport event
        /// </summary>
        /// <param name="id">Id of the sport event</param>
        /// <param name="operationType">operation type: "add" or "remove" </param>
        /// <response code="204">Successfully updated the sport event</response>
        /// <response code="409">A conflict occurred, sport event was not updated</response>
        [HttpPut]
        //[Authorize]
        [Route("assign-or-remove-from-event/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AssignOrRemoveFromEvent(int id, string operationType)
        {
            var result = await _sportEventManager.AssignOrRemoveFromEvent(id,operationType);
            return result == true ? NoContent() : Conflict();
        }

        /// <summary>
        /// Get sportsevent by id
        /// </summary>
        /// <param name="id">Id of the sports event</param>
        /// <response code="202">Success</response>
        /// <returns>Sports event</returns>
        [HttpGet]
        [Route("{id}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSportEventById(int id)
        {
            var result = await _sportEventManager.GetSportEventById(id);
            return Ok(result);
        }
    }
}
