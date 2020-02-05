using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DataService.Model.ViewModel.Enums;

namespace Reso.Infrastructure.Access.Controllers
{
    [Route("api/enums")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        
        [HttpGet("characteristic_definition")]
        public IActionResult GetCharacteristicDefinition()
        {
            return Ok(Enums.Get<CharacteristicDefinition>());
        }

        [HttpGet("application_origin")]
        public IActionResult GetApplicationOriginEnum()
        {
            return Ok(Enums.Get<ApplicationOriginEnum>());
        }

        [HttpGet("application_type")]
        public IActionResult GetApplicationTypeEnum()
        {
            return Ok(Enums.Get<ApplicationTypeEnum>());
        }

        [HttpGet("application_status")]
        public IActionResult GetApplicationStatusEnum()
        {
            return Ok(Enums.Get<ApplicationStatusEnum>());
        }

        [HttpGet("application_stage")]
        public IActionResult GetApplicationStageEnum()
        {
            return Ok(Enums.Get<ApplicationStageEnum>());
        }

        [HttpGet("application_category")]
        public IActionResult GetApplicationCategoryEnum()
        {
            return Ok(Enums.Get<ApplicationCategoryEnum>());
        }

        [HttpGet("server_type")]
        public IActionResult GetServerTypeEnum()
        {
            return Ok(Enums.Get<ServerTypeEnum>());
        }

        [HttpGet("server_os")]
        public IActionResult GetServerOSEnum()
        {
            return Ok(Enums.Get<ServerOSEnum>());
        }

        [HttpGet("system_instance_status")]
        public IActionResult GetSystemInstanceStatusEnum()
        {
            return Ok(Enums.Get<SystemInstanceStatusEnum>());
        }
        [HttpGet("log_type")]
        public IActionResult GetLogTypeEnum()
        {
            return Ok(Enums.Get<LogTypeEnum>());
        }
    }
}