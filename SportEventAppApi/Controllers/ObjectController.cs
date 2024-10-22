using ApplicationCore.Models.req;
using Managers.managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportEventAppApi.Controllers
{
    [Route("sport-objects")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly IObjectManager _objectManager;

        public ObjectController(IObjectManager objectManager)
        {
            _objectManager = objectManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllObjects() 
        { 
            var result = await _objectManager.GetAllObjects();
            return Ok(result);
        }
        [HttpGet]
        [Route("/object-base-info")]
        public async Task<IActionResult> GetObjectsBaseInfo()
        {
            var result = await _objectManager.GetObjectsBaseInfo();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetObjectById(int id)
        {
            var result = await _objectManager.GetObjectById(id);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteObject(int id)
        {
            var result = await _objectManager.DeleteObject(id);
            return result == true ? NoContent() : Conflict();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateObject(CreateObjectReq req, int id)
        {
            var result = await _objectManager.UpdateObject(req,id);
            return result == true ? NoContent() : Conflict();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSportObject(CreateObjectReq req)
        {
            var result = await _objectManager.CreateObject(req);
            return result == true ? StatusCode(201) : Conflict();
        }
        [HttpGet]
        public async Task<IActionResult> GetObjectsCreatedByUser()
        {
            var result = await _objectManager.GetObjectsCreatedByUser();
            return Ok(result);
        }
    }
}
