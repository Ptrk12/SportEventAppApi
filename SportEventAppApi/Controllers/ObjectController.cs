using ApplicationCore.Models.req;
using Managers.managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportEventAppApi.Controllers
{
    [Route("/sport-objects")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly IObjectManager _objectManager;

        public ObjectController(IObjectManager objectManager)
        {
            _objectManager = objectManager;
        }


        ///<summary>
        ///  Get all sport objects available in the system
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        public async Task<IActionResult> GetAllObjects() 
        { 
            var result = await _objectManager.GetAllObjects();
            return Ok(result);
        }


        ///<summary>
        ///  Get sport objects base info as Id and Name 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("object-base-info")]
        public async Task<IActionResult> GetObjectsBaseInfo()
        {
            var result = await _objectManager.GetObjectsBaseInfo();
            return Ok(result);
        }

        ///<summary>
        ///  Get sport object by id
        /// </summary>
        /// <param name="id">id of the sport object</param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetObjectById(int id)
        {
            var result = await _objectManager.GetObjectById(id);
            return Ok(result);
        }

        /// <summary>
        /// Remove sport object from the system (only those objects that do not have any event assigned to them)
        /// </summary>
        /// <param name="id">Id of the sport object</param>
        /// <returns>Returns 201 if the object is created, or a conflict response if it fails.</returns>
        /// <response code="204">Successfully removed the sport object</response>
        /// <response code="409">A conflict occurred, object was not removed</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> DeleteObject(int id)
        {
            var result = await _objectManager.DeleteObject(id);
            return result == true ? NoContent() : Conflict();
        }

        /// <summary>
        /// Update sport object in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/sportobject/12
        ///     {
        ///         "name": "City Hall",
        ///         "description": "Updated description",
        ///         "adress": "Street 223, Warszawa",
        ///         "city":"Warszawa",
        ///         "objectType":"Hall"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">Id of the sport object</param>
        /// <param name="req">Sport object update request</param>
        /// <returns>Returns 201 if the object is created, or a conflict response if it fails.</returns>
        /// <response code="204">Successfully created the sport object</response>
        /// <response code="409">A conflict occurred, object was not created</response>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateObject(CreateObjectReq req, int id)
        {
            var result = await _objectManager.UpdateObject(req,id);
            return result == true ? NoContent() : Conflict();
        }

        /// <summary>
        /// Create sport object in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/sportobject
        ///     {
        ///         "name": "City Stadium",
        ///         "description": "Sample description",
        ///         "adress": "Main Street 123, Krakow",
        ///         "city":"Krakow",
        ///         "objectType":"Hall"
        ///     }
        ///
        /// </remarks>
        /// <param name="req">Sport object creation request</param>
        /// <returns>Returns 201 if the object is created, or a conflict response if it fails.</returns>
        /// <response code="201">Successfully created the sport object</response>
        /// <response code="409">A conflict occurred, object was not created</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)] 
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateSportObject(CreateObjectReq req)
        {
            var result = await _objectManager.CreateObject(req);
            return result == true ? StatusCode(201) : Conflict();
        }

        ///<summary>
        ///  Get sport objects which was created by current logged user
        /// </summary>
        /// <returns>Returns 201 if the object is created, or a conflict response if it fails.</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("objects-created-by-user")]
        public async Task<IActionResult> GetObjectsCreatedByUser()
        {
            var result = await _objectManager.GetObjectsCreatedByUser();
            return Ok(result);
        }
    }
}
