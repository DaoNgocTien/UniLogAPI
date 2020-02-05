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
    [Authorize][Route("api/server_accounts")]
    [ApiController]
    public class ServerAccountsController : ControllerBase
    {
        private ServerAccountService _service;
        private LogService _logService; 
        public ServerAccountsController(LogService logservice, ServerAccountService service)
        {
            _service = service;_logService = logservice;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] ServerAccountFilter filter)
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


        [HttpPost]
        public IActionResult Post(ServerAccountCreateRequestModel model)
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


        [HttpPut]
        public IActionResult Put(ServerAccountUpdateRequestModel model)
        {
            try
            {
                var result = _service.UpdateServerAccount(model);
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