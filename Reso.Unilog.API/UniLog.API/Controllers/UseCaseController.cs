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
    [Authorize]
    [Route("api/usecase")]
    [ApiController]
    public class UseCaseController : ControllerBase
    {
        private UseCaseService _service;

        public UseCaseController(UseCaseService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseFilter filter)
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

                throw;
            }
        }


        [HttpPut]
        public IActionResult Put(UseCaseUpdateRequestModel model)
        {
            try
            {
                var result = _service.UpdateUseCase(model);
                if (result == null)
                {
                    return BadRequest(model);
                }
                return Ok(result);
            }
            catch (Exception e)
            { 
                throw;
            }
        }


        [HttpPost]
        public IActionResult Post(UseCaseCreateRequestModel model)
        {
            try
            {
                var result = _service.CreateUseCase(model);
                if (result == null)
                {
                    return BadRequest(model);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                var result = _service.RemoveUseCase(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}