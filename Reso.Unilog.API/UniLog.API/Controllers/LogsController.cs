using DataService.Models.Filters;
using DataService.Models.Services;
using DataService.RequestModels;
using DataService.RequestModels.CreateRequestModels;
using DataService.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UniLog.API.Controllers
{
    [Authorize]
    [Route("api/logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogService _service;

        ApplicationInstanceService _appInsSer = null;
        public LogsController(LogService service, ApplicationInstanceService appInsSer)
        {
            _service = service;
            _appInsSer = appInsSer;
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


        [HttpGet]
        [AllowAnonymous]
        [Route("application_id")]
        public IActionResult GetByApplicationID(int application_id)
        {
            try
            {
                int result = _service.GetByApplicationID(application_id);
                if(result == 0)
                {
                    return NotFound(application_id);
                }
                return Ok(result);

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

                var result = _service.PartialUpdate(requestModel);
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