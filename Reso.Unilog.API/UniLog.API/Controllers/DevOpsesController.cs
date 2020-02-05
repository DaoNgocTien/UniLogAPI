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
    [Route("api/devopses")]
    [ApiController]
    public class DevOpsesController : ControllerBase
    {
        private readonly DevOpsService _service;
        private readonly LogService _logService;
        public DevOpsesController(LogService logService, DevOpsService service)
        {
            _service = service;
            _logService = logService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]DevOpsFilter filter)
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
                DevOpsFilter filter = new DevOpsFilter()
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

        [HttpPost]
        public IActionResult Create(DevOpsCreateRequestModel model)
        {
            try
            {
                var result = _service.Create(model);
                if (result == null)
                {
                    return BadRequest(model);
                }
                return Ok(result);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }
    }
}