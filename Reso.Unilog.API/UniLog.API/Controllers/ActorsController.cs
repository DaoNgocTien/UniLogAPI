using DataService.Models.Filters;
using DataService.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UniLog.API.Controllers
{
  //  [Authorize]
    [Authorize][Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private LogService _logService;
        private ActorService _service;
        public ActorsController(ActorService service, LogService logService)
        {
            _service = service;
            _logService = logService;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] ActorFilter filter)
        {
            try
            {
                var result = _service.Get(filter);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }
    }
}