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
    [Route("api/application_characteristics")]
    [ApiController]
    public class ApplicationCharacteristicsController : ControllerBase
    {
        private ApplicationCharacteristicService _service;
        private LogService _logService;

        public ApplicationCharacteristicsController(ApplicationCharacteristicService service, LogService logService)
        {
            _service = service;
            _logService = logService;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] ApplicationCharacteristicFilter filter)
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
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }

        }


        [HttpPut]
        public IActionResult Put(ApplicationCharacteristicUpdateRequestModel model)
        {
            try
            {
                var result = _service.UpdateApplicationCharacteristic(model);
                if (result == null)
                {
                    return BadRequest(new { error = "Application is not Existed" });
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }

        }
    }
}