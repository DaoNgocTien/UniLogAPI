using DataService.Models.Repositories;
using DataService.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DataService.Models.Services
{
    public interface IAuthorizeService
    {
        bool Authenticate(string email, string password);
        string GetLoginProvider(string email, string password);
    }
    public class AuthorizeService: IAuthorizeService
    {        
        private readonly AppSettings _appSettings;
        private IAspNetUsersRepository _aspNetUsersRepository;
        private IAspNetUserTokensRepository _aspNetUserTokensRepository;
        public AuthorizeService(IOptions<AppSettings> appSettings, IAspNetUsersRepository aspNetUsersRepository, IAspNetUserTokensRepository aspNetUserTokensRepository)
        {
            _appSettings = appSettings.Value;
            _aspNetUsersRepository = aspNetUsersRepository;
            _aspNetUserTokensRepository = aspNetUserTokensRepository;
        }

        public string GetLoginProvider(string email, string password)
        {
            try
            {
                UniLogUtil utils = new UniLogUtil();
                password = utils.GetMd5HashData(password);
                var user = _aspNetUsersRepository.GetActive().Where(x => x.Email == email && x.PasswordHash == password).FirstOrDefault();

                // return null if user not found
                if (user == null)
                    return null;
                var token = _aspNetUserTokensRepository.Get().Where(x => x.Name == user.Name && x.UserId == user.Id).FirstOrDefault().LoginProvider;
                return token;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Authenticate(string email, string password)
        {
            try
            {
                UniLogUtil utils = new UniLogUtil();
                password = utils.GetMd5HashData(password);
                var user = _aspNetUsersRepository.GetActive().Where(x => x.Email == email && x.PasswordHash == password).FirstOrDefault();

                // return null if user not found
                if (user == null)
                    return false;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.SecurityStamp = tokenHandler.WriteToken(token);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
//using DataService.RequestModels;
//using Reso.AuthorizationBase.DbManager.Identity;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataService.Models.Services
//{
//   public class AuthorizeService
//    {
//        public readonly ResoUserIntManager _userManager;
//        public AuthorizeService(ResoUserIntManager userManager)
//        {
//            _userManager = userManager;
//        }

//        public async Task<object> AuthorizeLogin(AuthorizeLoginModel loginModel)
//        {
//            var user = await _userManager.FindByEmailAsync(loginModel.Email);
//            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
//            {
//                try
//                {
//                    var result = await user.AuthorizeAsync(_userManager, user);
//                    return result;
//                }
//                catch (Exception)
//                {
//                    throw;
//                }
//            }
//            return null;
//        }

//        public async Task<string> RegisterAsync(AuthorizeRegisterModel registerModel)
//        {
//            try
//            {
//                //if (!ModelState.IsValid)
//                //{
//                //    return BadRequest(ModelState);
//                //}
//                var email = registerModel.Email;
//                var password = registerModel.Password;
//                var confirmPassword = registerModel.ConfirmPassword;
//                ResoUserInt newUser = new ResoUserInt()
//                {
//                    Email = email,
//                    UserName = email,
//                    SecurityStamp = Guid.NewGuid().ToString(),
//                };
//                var result = await _userManager.CreateAsync(newUser, password);
//                if (result.Succeeded)
//                {
//                    result = await _userManager.AddToRoleAsync(newUser, "ActiveUser");
//                }
//                //Default is: Tok3n!2019
//                if (registerModel.AdminRegistrationToken.Equals("token_v2_7/2019"))
//                {
//                    result = await _userManager.AddToRoleAsync(newUser, "Administrator");
//                }

//                return email;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task<string> SystemRegisterAsync(AuthorizeRegisterModel registerModel)
//        {
//            try
//            {
//                var email = registerModel.Email;
//                var password = registerModel.Password;
//                var confirmPassword = registerModel.ConfirmPassword;
//                ResoUserInt newUser = new ResoUserInt()
//                {
//                    Email = email,
//                    UserName = email,
//                    SecurityStamp = Guid.NewGuid().ToString(),
//                };

//                await _userManager.CreateAsync(newUser, password);
//                await _userManager.AddToRoleAsync(newUser, "ActiveUser");
//                await _userManager.AddToRolesAsync(newUser, registerModel.RoleNames);
//                return email;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}
