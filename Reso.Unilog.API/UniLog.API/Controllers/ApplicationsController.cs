using AutoMapper;
using DataService.Models;
using DataService.Models.Filters;
using DataService.Models.Services;
using DataService.RequestModels;
using DataService.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UniLog.API.Controllers
{
    [Authorize]
    [Route("api/applications")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private ApplicationService _service;
        private LogService _logService;

        public ApplicationsController(ApplicationService service, LogService logService)
        {
            _service = service;
            _logService = logService;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] ApplicationFilter filter)
        {
            try
            {
                var result = _service.Get(filter);
                if (result == null)
                {
                    return NotFound();
                }
                List<ApplicationResponseModel> responseList = new List<ApplicationResponseModel>();
                foreach (var app in result.ToList())
                {
                    ApplicationResponseModel response = Mapper.Map<ApplicationServiceModel, ApplicationResponseModel>((ApplicationServiceModel)app); ;
                    response.LogCount = _logService.GetByApplicationID(((ApplicationServiceModel)app).Id);
                    responseList.Add(response);
                }
                return Ok(responseList);

            }
            catch (System.Exception e)
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
                ApplicationFilter filter = new ApplicationFilter()
                {
                    ids = id + "",
                    fields = fields,
                    ref_fields = ref_fields
                };
                var applicationtList = _service.Get(filter);
                if (applicationtList == null || applicationtList.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(applicationtList);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }

        [HttpPost]
        public IActionResult Post(ApplicationCreateRequestModel model)
        {
            try
            {
                //if (model.SourceCodeUrl != null && !Uri.TryCreate(model.SourceCodeUrl, UriKind.Relative, out Uri source_code_url))
                //{
                //    return BadRequest(new { error = "SourceCodeUrl is wrong format!" });
                //}
                //if (model.Link != null && !Uri.TryCreate(model.Link, UriKind.Relative, out Uri link))
                //{
                //    return BadRequest(new { error = "Link is wrong format!" });
                //}
                var application = _service.CreateApp(model);
                if (application == null)
                {
                    return BadRequest(model);
                }
                return Ok(application);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }


        [HttpPut]
        public IActionResult Put(ApplicationUpdateRequestModel model)
        {
            try
            {
                if (model.SourceCodeUrl != null && !Uri.TryCreate(model.SourceCodeUrl, UriKind.Relative, out Uri source_code_url))
                {
                    return BadRequest(new { error = "Source Code Url is wrong format!" });
                }
                //if (model.Link != null && !Uri.TryCreate(model.Link, UriKind.Relative, out Uri link))
                //{
                //    return BadRequest(new { error = "Link is wrong format!" });
                //}
                ApplicationFilter filter = new ApplicationFilter()
                {
                    ids = model.Id + ""
                };
                var applicationtList = _service.Get(filter);
                if (applicationtList == null || applicationtList.Count() == 0)
                {
                    return NotFound(model);
                }
                var result = _service.UpdateApp(model);
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


        [HttpPatch]
        [Route("status_changing")]
        public IActionResult ChangeStatus([FromQuery] int id, [FromQuery] bool active)
        {
            try
            {
                ApplicationFilter filter = new ApplicationFilter()
                {
                    ids = id + ""
                };
                var applicationtList = _service.Get(filter);
                if (applicationtList == null || applicationtList.Count() == 0)
                {
                    return NotFound();
                }
                var result = _service.ChangeStatus(id, active);
                if (result == null)
                {
                    return BadRequest("This application is still in service mode of other applications, please contact GM");
                }
                return Ok(result);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }
        //[HttpPatch]
        //[Route("service_registration")]
        //public IActionResult Register(ApplicationPartialUpdateRequestModel model)
        //{
        //    try
        //    {
        //        var result = _service.RegisterService(model.ServiceId, model.ClientId);
        //        if (result == null)
        //        {
        //            return BadRequest("Client / service application not exist");
        //        }
        //        if (!((bool)result))
        //        {
        //            return BadRequest("This application is not service");
        //        }
        //        return Ok(result);
        //    }
        //    catch (System.Exception e)
        //    {
        //        try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
        //        return StatusCode(503, e);
        //    }
        //}
        //[HttpPatch]
        //[Route("service_deactivation")]
        //public IActionResult DeactiveService(ApplicationPartialUpdateRequestModel model)
        //{
        //    try
        //    {
        //        var result = _service.DeactiveService(model.ServiceId, model.ClientId);
        //        if (result == null)
        //        {
        //            return BadRequest("Client / service application not exist \n Or \n This service not exist");
        //        }
        //        if (!((bool)result))
        //        {
        //            return BadRequest("This application is not service");
        //        }
        //        return Ok("Service remove successfully");
        //    }
        //    catch (System.Exception e)
        //    {
        //        try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
        //        return StatusCode(503, e);
        //    }

        //}

    }
}