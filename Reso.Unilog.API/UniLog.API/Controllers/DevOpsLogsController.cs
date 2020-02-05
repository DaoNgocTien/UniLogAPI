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
    [Route("api/devops_logs")]
    [ApiController]
    public class DevOpsLogsController : ControllerBase
    {
        private readonly DevOpsLogService _service;
        private readonly LogService _logService;
        public DevOpsLogsController(LogService logService, DevOpsLogService service)
        {
            _service = service;
            _logService = logService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]DevOpsLogFilter filter)
        {
            try
            {
                var result = _service.Get(filter);
                if (result == null || result.Count() == 0)
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
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, string fields, string ref_fields)
        {
            try
            {
                DevOpsLogFilter filter = new DevOpsLogFilter()
                {
                    ids = id + "",
                    fields = fields,
                    ref_fields = ref_fields
                };
                var result = _service.Get(filter);
                if (result == null || result.Count() == 0)
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