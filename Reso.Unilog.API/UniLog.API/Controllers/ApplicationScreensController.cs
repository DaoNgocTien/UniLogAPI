using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Models.Filters;
using DataService.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniLog.API.Controllers
{
    [Authorize]
    [Route("api/application_screens")]
    [ApiController]
    public class ApplicationScreensController : ControllerBase
    {
        private ApplicationScreenService _service;
        private LogService _logService;
        public ApplicationScreensController(ApplicationScreenService service, LogService logService)
        {
            _service = service;
            _logService  = logService;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] ApplicationScreenFilter filter)
        {
            try
            {
                var result = _service.Get(filter);
                if (result == null) return NotFound();
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