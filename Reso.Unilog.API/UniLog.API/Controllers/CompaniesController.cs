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
    [Authorize][Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private CompanyService _service;
        private LogService _logService; 
        public CompaniesController(LogService logservice, CompanyService service)
        {
            _service = service;
            _logService = logservice;
        }



        [HttpGet]
        public IActionResult Get([FromQuery] CompanyFilter filter)
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
        public IActionResult Post(CompanyCreateRequestModel model)
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
        public IActionResult Put(CompanyUpdateRequestModel model)
        {
            try
            {
                var result = _service.UpdateCompany(model);
                if (result == null) return BadRequest(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }



        [HttpPatch]
        public IActionResult Patch(CompanyPartialUpdateRequestModel model)
        {
            try
            {
                var result = _service.UpdatePartialCompany(model);
                if (result == null) return BadRequest(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                return StatusCode(503, e);
            }
        }


        [HttpDelete]
        public IActionResult Delete([FromQuery] int companyId, [FromQuery] bool active)
        {
            try
            {
                var result = _service.RemoveCompany(companyId, false);
                if (result == null) return NotFound();
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