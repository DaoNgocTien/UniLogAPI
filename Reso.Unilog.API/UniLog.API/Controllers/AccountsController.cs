using DataService.Models.Filters;
using DataService.Models.Services;
using DataService.RequestModels;
using DataService.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UniLog.API.Controllers
{
    [Authorize]
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private AccountService _service;
        private LogService _logService;
        private EmailConfiguration _emailConfiguration;
        public AccountsController(AccountService service, LogService logService, EmailConfiguration emailConfiguration)
        {
            _service = service;
            _logService = logService;
            _emailConfiguration = emailConfiguration;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] AccountFilter filter)
        {
            try
            {
                var accountList = _service.Get(filter);
                if (accountList == null || accountList.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(accountList);
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
                AccountFilter filter = new AccountFilter()
                {
                    ids = id + "",
                    fields = fields,
                    ref_fields = ref_fields
                };
                var accountList = _service.Get(filter);
                if (accountList == null || accountList.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(accountList);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }



        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public IActionResult Create(AuthorizeRegisterModel model)
        {
            try
            {
                if (!_service.CheckValidEmail(model.Email))
                {
                    return BadRequest(new { error = "Email existed" });
                }
                if (model.Password != model.ConfirmPassword)
                {
                    return BadRequest(new { error = "Password not match" });
                }
                var result = _service.Create(model);
                if (result == null)
                {
                    return BadRequest(model);
                }
                return Ok(result);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(AuthorizeLoginModel loginModel)
        {
            try
            {
                var result = _service.Login(loginModel);
                if (result == null)
                {
                    return NotFound(loginModel);
                }
                return Ok(result);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }

        [HttpPost]
        [Route("reset")]
        [AllowAnonymous]
        public IActionResult Reset(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest(new { error = "Invalid email" });
                }
                var result = _service.GetResetToken(email);
                if (string.IsNullOrEmpty(result))
                {
                    return BadRequest(new { error = "Email not existed" });
                }
                return Ok(result);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }



        [HttpPut]
        public IActionResult Update(AccountUpdateRequestModel model)
        {
            try
            {
                if (model == null)
                {
                    BadRequest(new { error = "Invalid account" });
                }
                var result = _service.Update(model);
                if (model == null)
                {
                    BadRequest(new { error = "Invalid account" });
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

        [AllowAnonymous]
        [Route("password_changing")]
        public IActionResult ChangePassword(PasswordModel passwordModel)
        {
            try
            {
                var result = _service.ChangePassword(passwordModel);
                if (string.IsNullOrEmpty(result))
                {
                    return BadRequest(new { error = "Email not existed" });
                }
                if (result != "Change password successfully")
                {
                    return BadRequest(result);
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
        [Route("employee_assignment")]
        public IActionResult AddEmployeeToSystem(ProjectAssignment model)
        {
            try
            {
                var result = _service.AddEmployee(model);
                if (result.Contains("successfully"))
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }

        [HttpGet]
        [Route("project_management")]
        public IActionResult GetProjectManagement(string email)
        {
            try
            {
                var result = _service.GetProjectManagement(email);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(email);
            }
            catch (System.Exception e)
            {
                try { _logService.SendLogError(e); } catch (System.Exception ex) { return StatusCode(503, ex.Message); }
                return StatusCode(503, e);
            }
        }
    }
}