using DataService.Models.Filters;
using DataService.Models.Services;
using DataService.RequestModels;
using DataService.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UniLog.API.Controllers
{
    [Authorize]
    [Route("api/application_instances")]
    [ApiController]
    public class ApplicationInstancesController : ControllerBase
    {
        private ApplicationInstanceService _service;
        private LogService _logService;
        public ApplicationInstancesController(ApplicationInstanceService service, LogService logService)
        {
            _service = service;
            _logService = logService;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] ApplicationInstanceFilter filter)
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



        [HttpPost]
        public IActionResult Post(ApplicationInstanceCreateRequestModel model)
        {
            try
            {
                var listApplicationInstance = _service.Get(new ApplicationInstanceFilter()
                {
                    app_code = model.AppCode
                });
                foreach (ApplicationInstanceServiceModel appIns in listApplicationInstance)
                {
                    if (appIns.AppCode == model.AppCode)
                    {
                        return BadRequest(new { error = "App Code existed" });
                    }
                }
                var result = _service.Create(model);
                if (result == null)
                {
                    return BadRequest(model);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }
        [HttpPut]
        public IActionResult Put(ApplicationInstanceUpdateRequestModel model)
        {
            try
            {
                var listApplicationInstance = _service.Get(new ApplicationInstanceFilter()
                {
                    app_code = model.AppCode

                });
                foreach (ApplicationInstanceServiceModel appIns in listApplicationInstance)
                {
                    if (appIns.AppCode == model.AppCode && appIns.Id != model.Id)
                    {
                        return BadRequest(new { error = "App Code existed" });
                    }
                }
                var result = _service.Update(model);
                if (result == null)
                {
                    return BadRequest(model);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }

        [HttpPatch]
        [Route("status_changing")]
        public IActionResult ChangeStatus([FromQuery] int id)
        {
            try
            {
              
                var result = _service.ChangeStatus(id);
                if (result == null)
                {
                    return BadRequest("Application Instance is not existed");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }
        //[HttpPatch]
        //[Route("unique_code_chaging")]
        //public IActionResult ChangeApplicationInstanceCode(ApplicationInstancePartialUpdateRequestModel model)
        //{
        //    try
        //    {
        //        var listApplicationInstance = _service.Get(new ApplicationInstanceFilter() {
        //            fields = "app_code"
        //        });
        //        foreach (ApplicationInstanceServiceModel appIns in listApplicationInstance)
        //        {
        //            if(appIns.AppCode == model.AppCode)
        //            {
        //                return BadRequest(new { error = "App Code existed" });
        //            }
        //        }
        //        var result = _service.PartialUpdate(model);
        //        if (result == null)
        //        {
        //            return BadRequest(model);
        //        }
        //        return Ok(result);
        //    }
        //    catch (Exception e)
        //    {
        //        try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
        //        return StatusCode(503, e);
        //    }
        //}
    }
}