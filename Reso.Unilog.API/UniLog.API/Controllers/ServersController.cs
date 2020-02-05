using DataService.Models.Filters;
using DataService.Models.Repositories;
using DataService.Models.Services;
using DataService.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace UniLog.API.Controllers
{
    [Authorize]
    [Authorize][Route("api/servers")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly ServerService _service;
        private readonly LogService _logService;
        private readonly IServerRepository _repo;
        private readonly ServerDetailService _serverDetailService;
        public ServersController(IServerRepository repo,ServerService service, LogService logService, ServerDetailService serverDetailService)
        {
            _service = service;
            _logService = logService;
            _serverDetailService = serverDetailService;
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] ServerFilter filter)
        {
            try
            {
                var ServerList = _service.Get(filter);
                if (ServerList == null || ServerList.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(ServerList);
            }
            catch (System.Exception e)
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
                ServerFilter filter = new ServerFilter()
                {
                    ids = id + "",
                    fields = fields,
                    ref_fields = ref_fields
                };
                var ServerList = _service.Get(filter);
                if (ServerList == null || ServerList.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(ServerList);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }


        [HttpPost]
        public IActionResult Create(ServerCreateRequestModel model)
        {
            try
            {
                //  Check Server Master
                if (model.ServerMaster != null && model.ServerMaster != 0)
                {
                    ServerFilter filter = new ServerFilter()
                    {
                        ids = (int)model.ServerMaster + ""
                    };
                    if (_service.Get(filter).FirstOrDefault() == null)
                        return BadRequest(new { error = "Server Master is not existed!" });
                }
                else
                {
                    model.ServerMaster = null;
                }
                if ((model.Type == 1 || model.Type == 2) && model.Os > 2)
                {
                    return BadRequest(new { error = "Web Server only be Windows or Linux" });
                }
                if (model.Type == 3 && (model.Os < 3 || model.Os > 6))
                {
                    return BadRequest(new { error = "Repo Server - Server Os should be between 3 and 6" });
                }
                if (model.Type == 4 && (model.Os < 7 || model.Os > 10))
                {
                    return BadRequest(new { error = "Database Server - Server Os should be between 7 and 10" });
                }
                if (model.IpAddress != null && !IPAddress.TryParse(model.IpAddress, out IPAddress address))
                {
                    return BadRequest(new { error = "IpAdress is wrong format!" });
                }
                var result = _service.Create(model);
                if (result == null)
                {
                    return BadRequest("Invalid company_id or server name");
                }

                //  Create Server Detail
                //if(model.ServerDetail != null)
                //{
                //    var createServerDetail = _serverDetailService.Create(model.ServerDetail);
                //    if (createServerDetail == null)
                //    {
                //        return BadRequest("Server created but server detail is invalid");
                //    }
                //}
                
                return Ok(result);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
                 
            
             //   
                return StatusCode(503, e);
            }
        }

        [HttpPut]
        public IActionResult Update(ServerUpdateRequestModel model)
        {
            try
            {
                // Check existed server name
                var existServer = _repo.GetActive(p => p.Name == model.Name && p.Id != model.Id).FirstOrDefault();
                if (existServer != null)
                {
                    return BadRequest(new { error = "Server Name is existed!" });
                }
                //  Check Server Master
                if (model.ServerMaster != null)
                {
                    ServerFilter filter = new ServerFilter()
                    {
                        ids = (int)model.ServerMaster + ""
                    };
                    if (_service.Get(filter).FirstOrDefault() == null)
                        return BadRequest(new { error = "Server Master is not existed!" });
                }

                if ((model.Type == 1 || model.Type == 2) && model.Os > 2)
                {
                    return BadRequest(new { error = "Web Server only be Windows or Linux" });
                }
                if (model.Type == 3 && (model.Os < 3 || model.Os > 6))
                {
                    return BadRequest(new { error = "Repo Server - Server Os should be between 3 and 6" });
                }
                if (model.Type == 4 && (model.Os < 7 || model.Os > 10))
                {
                    return BadRequest(new { error = "Database Server - Server Os should be between 7 and 10" });
                }
                if (model.IpAddress != null && !IPAddress.TryParse(model.IpAddress, out IPAddress address))
                {
                    return BadRequest(new { error = "IpAdress is wrong format!" });
                }
                var result = _service.Update(model);
                if (model == null)
                {
                    BadRequest(new { error = "Invalid Server" });
                }

                //  Update ServerDetail
                if(model.ServerDetail != null)
                {
                    var updateServerDetail = _serverDetailService.Update(model.ServerDetail);
                    if(updateServerDetail == null)
                    {
                        return BadRequest("Server updated but server detail is invalid");
                    }
                }
                
                return Ok(result);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }

        [HttpPatch]
        public IActionResult PartialUpdate(ServerPartialUpdateRequestModel model)
        {
            try
            {
                var result = _service.PartialUpdate(model);
                if (result == null)
                {
                    return BadRequest(new { error = "Server not existed" });
                }
                return Ok(result);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }
    }
}