using DataService.Models.Filters;
using DataService.Models.Services;
using DataService.RequestModels;
using DataService.RequestModels.CreateRequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace UniLog.API.Controllers
{
    [Authorize][Route("api/logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogService _service;


        public LogsController(LogService service)
        {
            _service = service;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] LogFilter filter)
        {
            try
            {
                var logList = _service.Get(filter);
                if (logList == null || logList.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(logList);
            }
            catch (Exception e)
            {
                _service.SendLogError(e);
                return StatusCode(503, e);
            }
        }



        [HttpPost]
        [AllowAnonymous]
        [Route("error")]
        public IActionResult Post(LogErrorCreateRequestModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                LogCreateRequestModel createErrorModel = _service.ParseExceptionToExceptionModel(model);
                if (createErrorModel == null)
                {
                    return BadRequest(model);
                }
                var result = _service.Create(createErrorModel);
                return Ok(result);
            }
            
            catch (Exception e)
            {
                try { _service.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                
                return StatusCode(503, e);
            }
        }  
        [HttpPatch]
        public IActionResult UpdateStatus(LogPartialUpdateRequestModel requestModel)
        {
            try
            {
                if (requestModel == null || requestModel.Id == 0)
                {
                    return BadRequest();
                }

                var result = _service.PartialUpdate (requestModel);
                if (result == null)
                {
                    return BadRequest(requestModel);
                }
                return Ok(result);
            }
            
            catch (Exception e)
            {
                try { _service.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                
                return StatusCode(503, e);
            }
        }
    }
}