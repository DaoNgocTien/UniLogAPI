using DataService.Models.Filters;
using DataService.Models.Repositories;
using DataService.RequestModels;
using DataService.ServiceModels;
using DataService.Utils;
using System;
using System.Linq;

namespace DataService.Models.Services
{
    public interface IAspNetUsersService : IBaseService<IAspNetUsersRepository, AspNetUsers, AspNetUsersFilter, int, AspNetUsersServiceModel, AspNetUsersCreateRequestModel, AspNetUsersServiceModel, AspNetUsersPartialUpdateRequestModel>
    {
        bool? ResetPassword(PasswordModel model);
        string AuthorizeResetPassword(string email);
        string CreateToken(string str);
        bool? ChangePassword(AspNetUsersPartialUpdateRequestModel requestModel);
    }
    public class AspNetUsersService : BaseService<AspNetUsersRepository, AspNetUsers, AspNetUsersFilter, int, AspNetUsersServiceModel, AspNetUsersCreateRequestModel, AspNetUsersServiceModel, AspNetUsersPartialUpdateRequestModel>
    {
        private readonly IAspNetUserTokensRepository _aspNetUserTokensRepo;
        public AspNetUsersService(IAspNetUserTokensRepository aspNetUserTokenRepo, AspNetUsersRepository repo, AspNetUsersServiceModel model) : base(repo, model)
        {
            _aspNetUserTokensRepo = aspNetUserTokenRepo;
        }

        public bool? ChangePassword(AspNetUsersPartialUpdateRequestModel requestModel)
        {
            try
            {
                var user = _repo.GetActive().Where(p => p.Email == requestModel.Email ).FirstOrDefault();
                if (user == null)
                {
                    return null;
                }
                UniLogUtil utils = new UniLogUtil();
                user.PasswordHash = utils.GetMd5HashData(requestModel.NewPassword);
                _repo.Update(user);
                _repo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool? ResetPassword(PasswordModel model)
        {
            try
            {
                var user = _repo.GetActive().Where(p => p.Email == model.Email).FirstOrDefault();
                if (user == null)
                {
                    return null;
                }
                var token = _aspNetUserTokensRepo.Get().Where(p => p.UserId == user.Id && p.Name == user.Name && p.Value == model.Token).FirstOrDefault();
                if (token == null)
                {
                    return false;
                }

                UniLogUtil utils = new UniLogUtil();
                user.PasswordHash = utils.GetMd5HashData(model.NewPassword);
                _repo.Update(user);
                _repo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string CreateToken(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }

            UniLogUtil utils = new UniLogUtil();
            string token = "";
            int length = new Random().Next(1, str.Length);
            for (int i = 0; i < length; i++)
            {
                var dateString = DateTime.Now.Millisecond.ToString();
                token += str.Replace(str[new Random().Next(1, str.Length - 1)], dateString[new Random().Next(1, dateString.Length - 1)]);
            }
            token = utils.GetMd5HashData(token);
            return token;
        }


        public string AuthorizeResetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "";
            }
            var user = _repo.GetActive().Where(p => p.Email == email).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            var token = CreateToken(email);

            var userToken = _aspNetUserTokensRepo.Get().Where(p => p.UserId == user.Id && p.Name == user.Name).FirstOrDefault();
            if (userToken == null)
            {
                userToken = new AspNetUserTokens()
                {
                    UserId = user.Id,
                    Value = token,
                    Name = user.Name,
                    LoginProvider = CreateToken(token)
                };
                _aspNetUserTokensRepo.Create(userToken);
            }
            else
            {
                userToken.Value = token;
                _aspNetUserTokensRepo.Update(userToken);
            }

            _aspNetUserTokensRepo.SaveChanges();
            return token;
        }
    }
}
