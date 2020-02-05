using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Models.Filters;
using DataService.Models.Services;
using DataService.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniLog.API.Controllers
{
    [Authorize]
    [Authorize][Route("api/activity_logs")]
    [ApiController]
    public class ActivityLogsController : ControllerBase
    {
        private ActivityLogService _service;
        private LogService _logService;
        public ActivityLogsController(ActivityLogService service, LogService logService)
        {
            _service = service;
            _logService = logService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ActivityLogFilter filter)
        {
            try
            {
                var result = _service.Get(filter);
                if(result == null || result.Count() == 0)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }


        [HttpPost]
        public IActionResult Post(ActivityLogCreateRequestModel model)
        {
            try
            {
                var result = _service.Create(model);
                if(result == null)
                {
                    return NotFound(model);
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