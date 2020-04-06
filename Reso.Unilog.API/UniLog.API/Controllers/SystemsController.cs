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
    [Route("api/systems")]
    [ApiController]
    public class SystemsController : ControllerBase
    {
        private SystemService _service;
        private LogService _logService;
        public SystemsController(SystemService service, LogService logService)
        {
            _service = service;
            _logService  =logService;
        }

        
        [HttpGet]
        public IActionResult Get([FromQuery] SystemFilter filter)
        {
            try
            {
                var systemList = _service.Get(filter);
                if (systemList == null || systemList.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(systemList);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id, string fields, string ref_fields)
        {
            try
            {
                SystemFilter filter = new SystemFilter()
                {
                    ids = id + "",
                    fields = fields,
                    ref_fields = ref_fields
                };
                var systemList = _service.Get(filter);
                if (systemList == null || systemList.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(systemList);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(SystemCreateRequestModel model)
        {
            try
            {
                var result = _service.Create(model);
                if(result == null)
                {
                    return BadRequest(model);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }




        [HttpPatch]
        [Route("activation")]
        public IActionResult Patch(SystemPartialUpdateRequestModel model)
        {
            try
            {
                var result = _service.UpdateActive(model);
                if(result == null)
                {
                    return BadRequest("Something is wrong !! you can check it again, please !!");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }




       // [HttpPatch]
       //[Route("deactivation")]
       // public IActionResult Deactivation(SystemDeleteRequestModel model)
       // {
       //     try
       //     {
       //         var result = _service.RemoveSystem(model);
       //         if(result == null)
       //         {
       //             return BadRequest("Something is wrong !! you can check it again, please !!");
       //         }
       //         return Ok(result);
       //     }
       //     catch (Exception e)
       //     {
       //         try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
       //         return StatusCode(503, e);
       //     }
       // }

       // [HttpPatch]
       // [Route("employee_assignment")]
       // public IActionResult AddEmployeeToSystem(int employee_id, int system_id)
       // {
       //     try
       //     {
       //         var result = _service.AddEmployee(employee_id, system_id);
       //         if (result.Contains("Successfully"))
       //         {
       //             return Ok(result);
       //         }
       //         return BadRequest(result);
       //     }
       //     catch (System.Exception e)
       //     {
       //         try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
       //         return StatusCode(503, e);
       //     }
       // }
    }
}