using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Models.Filters;
using DataService.Models.Services;
using DataService.RequestModels;
using DataService.RequestModels.CreateRequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniLog.API.Controllers
{
    [Authorize][Route("api/repos")]
    [ApiController]
    public class ReposController : ControllerBase
    {
        private RepoService _service;
        private LogService _logService; 

        public ReposController(LogService logservice, RepoService service)
        {
            _service = service;_logService = logservice;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] RepoFilter filter)
        {
            try
            {
                var result = _service.Get(filter);
                if (result == null) return null;
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }



        [HttpPost]
        public IActionResult Post(RepoCreateRequestModel model)
        {
            try
            {
                var result = _service.Create(model);
                if (result == null) return null;
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }



        [HttpPut]
        public IActionResult Put(RepoUpdateRequestModel model)
        {
            try
            {
                var result = _service.UpdateRepo(model);
                if (result == null) return null;
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