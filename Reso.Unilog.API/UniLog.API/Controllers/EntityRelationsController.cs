using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Models.Filters;
using DataService.Models.Services;
using DataService.RequestModels.CreateRequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniLog.API.Controllers
{
    [Authorize][Route("api/entity_relations")]
    [ApiController]
    public class EntityRelationsController : ControllerBase
    {
        private EntityRelationService _service;
        private LogService _logService; 

        public EntityRelationsController(LogService logservice, EntityRelationService service)
        {
            _service = service;
            _logService = logservice;
        }



        [HttpGet]
        public IActionResult Get([FromQuery] EntityRelationFilter filter)
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
        public IActionResult Post(EntityRelationCreateRequestModel model)
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
        public IActionResult Put(EntityRelationUpdateRequestModel model)
        {
            try
            {
                var result = _service.UpdateEntity(model);
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