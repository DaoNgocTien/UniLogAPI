using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Models.Filters;
using DataService.Models.Services;
using DataService.RequestModels.CreateRequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniLog.API.Controllers
{
    [Authorize][Route("api/system_instances")]
    [ApiController]
    public class SystemInstancesController : ControllerBase
    {
        private SystemInstanceService _service;
        private LogService _logService; 
        public SystemInstancesController(LogService logservice, SystemInstanceService service)
        {
            _service = service;_logService = logservice;
        }



        [HttpGet]
        public IActionResult Get([FromQuery] SystemInstanceFilter filter)
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


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(SystemInstanceCreateRequestModel model)
        {
            try
            {
                var result = _service.Create(model);
                if (result == null) return BadRequest(model);
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