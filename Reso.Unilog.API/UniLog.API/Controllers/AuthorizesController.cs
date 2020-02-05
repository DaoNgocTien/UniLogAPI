//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using DataService.Models.Services;
//using DataService.RequestModels;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//using Reso.AuthorizationBase.DbManager.Identity;


//namespace UniLog.API.Controllers
//{
//    [ApiExplorerSettings(IgnoreApi = true)]
//    [Authorize][Route("api/authorizes")]
//    [ApiController]
//    public class AuthorizesController : ControllerBase
//    {
//        private readonly AuthorizeService _authorizeService;
//        private readonly LogService _logService;
//        public AuthorizesController(AuthorizeService authorizeService, LogService logService)
//        {
//            _authorizeService = authorizeService;
//            _logService = logService;
//        }

//        [ApiExplorerSettings(IgnoreApi = true)]
//        [HttpPost("login")]
//        [AllowAnonymous]
//        public async Task<ActionResult> Login(AuthorizeLoginModel loginModel)
//        {
//            try
//            {
//                var result = await _authorizeService.AuthorizeLogin(loginModel);
//                if (result == null)
//                {
//                    return Unauthorized();
//                }
//                return Ok(result);
//            }
//            try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
//            {
//                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
//                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
//            }            
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="registerModel"></param>
//        /// <returns></returns>
//        [HttpPost("authorized_administrator_register")]
//        //[Authorize(Roles = "Administrator")]
//        public async Task<ActionResult<bool>> RegisterAsync(AuthorizeRegisterModel registerModel)
//        {

//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }
//                var result = await _authorizeService.RegisterAsync(registerModel);
//                return Ok(result);
//            }
//            try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
//            {
//                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
//                return NotFound(new { exception = e.Message });
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="registerModel"></param>
//        /// <returns></returns>
//        [HttpPost("authorized_brandmanager_register")]
//        //[Authorize(Roles = "Administrator, Manager")]
//        public async Task<ActionResult<bool>> SystemRegisterAsync(AuthorizeRegisterModel registerModel)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }
//                var result = await _authorizeService.SystemRegisterAsync(registerModel);
//                return Ok(result);
//            }
//            try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
//            {
//                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex); }
//                return NotFound(new { exception = e.Message });
//            }
//        }
//    }
//}
