using AutoMapper;
using DataService.Models.Filters;
using DataService.Models.Repositories;
using DataService.RequestModels;
using DataService.ServiceModels;
using DataService.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace DataService.Models.Services
{
    public interface IAccountService : IBaseService<IAccountRepository, Account, AccountFilter, int, AccountServiceModel, AuthorizeRegisterModel, AccountUpdateRequestModel, AccountServiceModel>
    {
        //Task<AuthorizeLoginModel> Login(AuthorizeLoginModel loginModel);
        LoginResponseModel Login(AuthorizeLoginModel loginModel);
        string GetResetToken(string email);
        bool CheckValidEmail(string email);
        string AddEmployee(ProjectAssignment model);
        string ChangePassword(PasswordModel passwordModel);
    }
    public class AccountService : BaseService<AccountRepository, Account, AccountFilter, int, AccountServiceModel, AuthorizeRegisterModel, AccountUpdateRequestModel, AccountServiceModel>, IAccountService
    {
        //private readonly ResoUserIntManager _userManager;
        private readonly LogService log;
        private readonly AspNetUsersService _aspNetUsersService;
        private readonly AspNetUsersRepository _aspNetUsersRepository;
        private readonly AspNetUserTokensRepository _aspNetUserTokensRepo;
        private readonly AspNetUserRolesRepository _aspNetUserRolesRepository;
        private readonly IAuthorizeService _IAuthorizeService;
        private readonly IManageProjectRepository _manageProjectRepository;
        private readonly IApplicationInstanceRepository _applicationInstanceRepository;
        private readonly IApplicationRepository _applicationRepository;
        public AccountService(
            IManageProjectRepository manageProjectRepository,
            IApplicationInstanceRepository applicationInstanceRepository,
            IApplicationRepository applicationRepository,
            AspNetUsersRepository aspNetUsersRepository,
            AspNetUserRolesRepository aspNetUserRolesRepository,
            AspNetUserTokensRepository aspNetUserTokensRepo, /*ResoUserIntManager userManager*/
            LogService logService,
            AspNetUsersService aspNetUsersService,
            AccountRepository repo,
            AccountServiceModel model,
            IAuthorizeService IAuthorizeService) : base(repo, model)
        {
            _aspNetUserRolesRepository = aspNetUserRolesRepository;
            _applicationRepository = applicationRepository;
            _applicationInstanceRepository = applicationInstanceRepository;
            _manageProjectRepository = manageProjectRepository;
            _aspNetUsersRepository = aspNetUsersRepository;
            _aspNetUserTokensRepo = aspNetUserTokensRepo;
            //_userManager = userManager;
            log = logService;
            _aspNetUsersService = aspNetUsersService;
            _IAuthorizeService = IAuthorizeService;
        }

        public override IQueryable<Account> GetSpecificRequests(AccountFilter filter, IQueryable<Account> list)
        {
            try
            {
                if (filter != null)
                {
                    if (filter.email != null)
                    {
                        list = list.Where(p => p.Email.Equals(filter.email));
                    }

                    if (filter.role > 0)
                    {
                        list = list.Where(p => p.Role == filter.role);
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override IQueryable<Account> GetReferenceFields(string ref_fields, IQueryable<Account> list)
        {
            try
            {
                if (!string.IsNullOrEmpty(ref_fields))
                {
                    if (ref_fields.Contains("asp_net_user"))
                    {
                        list = list.Include(p => p.AspNetUser);
                    }
                    if (ref_fields.Contains("manage_project"))
                    {
                        list = list.Include(p => p.ManageProject);
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool CheckValidEmail(string email)
        {
            var list = _repo.GetActive();
            return list.Where(p => p.Email == email).FirstOrDefault() == null;
        }

        #region Login
        public LoginResponseModel Login(AuthorizeLoginModel loginModel)
        {
            try
            {
                var account = _repo.GetActive().Where(p => p.Email == loginModel.Email).FirstOrDefault();
                if (account == null)
                {
                    return null;
                }

                if (!_IAuthorizeService.Authenticate(loginModel.Email, loginModel.Password))
                {
                    return null;
                }
                UniLogUtil utils = new UniLogUtil();
                var aspUser = _aspNetUsersRepository.GetActive().Where(p => p.Email == loginModel.Email && p.PasswordHash == utils.GetMd5HashData(loginModel.Password)).FirstOrDefault();
                if (aspUser == null)
                {
                    return null;
                }
                var result = new LoginResponseModel();
                result.Id = account.Id;
                //  get JWT from AspNetUserLogins.LoginProvider
                result.Token = (aspUser.AspNetUserLogins.FirstOrDefault()).LoginProvider;
                result.Role = account.Role;
                result.Email = account.Email;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion        

        #region Register
        public override AccountServiceModel Create(AuthorizeRegisterModel requestModel)
        {
            try
            {


                //  Check existed email
                var existAccount = _repo.GetActive().Where(p => p.Email == requestModel.Email).FirstOrDefault();
                if (existAccount != null)
                {
                    return null;
                }

                //  Check Administrator / BrandManager / Employee Register
                if (requestModel.ManagerRegistrationToken == "token_v2_7/2019")
                {
                    if (requestModel.IsAdmin)
                    {
                        requestModel.Role = 1;
                    }
                    else
                        requestModel.Role = 2;
                }
                else
                {
                    requestModel.Role = requestModel.Role == 3 ? requestModel.Role : requestModel.Role == 4 ? requestModel.Role : 5;
                }


                //  Create AspNetUser
                UniLogUtil utils = new UniLogUtil();
                var accountNetUser = Mapper.Map<AuthorizeRegisterModel, AspNetUsersCreateRequestModel>(requestModel);
                accountNetUser.PasswordHash = utils.GetMd5HashData(requestModel.Password);
                accountNetUser.PhoneNumber = requestModel.Phone;

                var aspNetUser = _aspNetUsersService.Create(accountNetUser);

                //  Create AspNetUserTokens => token for reset password
                //AspNetUserTokens aspToken = new AspNetUserTokens()
                //{
                //    UserId = aspNetUser.Id,
                //    Name = aspNetUser.Name == null ? aspNetUser.Email: aspNetUser.Name,
                //    LoginProvider = _aspNetUsersService.CreateToken(aspNetUser.Email)
                //};
                //_aspNetUserTokensRepo.Create(aspToken);
                //_aspNetUserTokensRepo.SaveChanges();

                //  Create AspNetUsersRoles
                AspNetUserRoles aspUserRoles = new AspNetUserRoles()
                {
                    UserId = aspNetUser.Id,
                    RoleId = requestModel.Role,
                    
                };
                _aspNetUserRolesRepository.Create(aspUserRoles);
                _aspNetUserRolesRepository.SaveChanges();

                //  Create Account
                var account = Mapper.Map<AuthorizeRegisterModel, Account>(requestModel);
                account.AspNetUserId = aspNetUser.Id;
                _repo.Create(account);
                _repo.SaveChanges();
                return Mapper.Map<Account, AccountServiceModel>(account);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Change Password

        //  Get reset password token
        public string GetResetToken(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return "";
                }
                if (CheckValidEmail(email))
                {
                    String a = "aa";
                    int aa = int.Parse(a);
                 }
                //  Modify list email send
                List<EmailAddress> fromEmail = new List<EmailAddress>();
                fromEmail.Add(new EmailAddress()
                {
                    Address = "tiendnse63513@fpt.edu.vn",
                    Name = "Tien Dao"
                });
                List<EmailAddress> toEmail = new List<EmailAddress>();
                toEmail.Add(new EmailAddress()
                {
                    Address = email,
                    Name = _repo.GetActive().Where(p => p.Email == email).FirstOrDefault().Name
                });

                EmailMessageServiceModel message = new EmailMessageServiceModel()
                {
                    Subject = "Reset token for unilog",
                    Content = "Please use this token to change password: " + _aspNetUsersService.AuthorizeResetPassword(email),
                    ToAddresses = toEmail,
                    FromAddresses = fromEmail
                };

                //  Send Email 
                EmailService emailService = new EmailService(new EmailConfiguration());
                emailService.Send(message);

                //#region Another way to send email without building EmailConfiguration
                //List<EmailAddress> listTo = new List<EmailAddress>();
                //List<EmailAddress> listCC = new List<EmailAddress>();
                //List<EmailAddress> listBcc = new List<EmailAddress>();
                //using (var messageRegion = new MailMessage())
                //{
                //    messageRegion.From = new MailAddress("tien.dao@wisky.vn", "Tien Dao");
                //    //  Send to List
                //    // foreach (var item in listTo)
                //    // {
                //    //     message.To.Add(new MailAddress("to@email.com", "To Name"));
                //    // }
                //    //foreach (var item in listCC)
                //    // {
                //    //     message.CC.Add(new MailAddress("cc@email.com", "To Name"));
                //    // }
                //    //foreach (var item in listBcc)
                //    // {
                //    //     message.Bcc.Add(new MailAddress("bcc@email.com", "To Name"));
                //    // }
                //    messageRegion.To.Add(new MailAddress(email, _repo.GetActive().Where(p => p.Email == email).FirstOrDefault().Name));
                //    messageRegion.CC.Add(new MailAddress(email, "CC Name"));
                //    messageRegion.Bcc.Add(new MailAddress(email, "BCC Name"));
                //    messageRegion.Subject = "Reset Token";
                //    messageRegion.Body = "Please use this token to change password: " + _aspNetUsersService.AuthorizeResetPassword(email);
                //    messageRegion.IsBodyHtml = true;

                //    using (var client = new SmtpClient("smtp.gmail.com"))
                //    {
                //        client.Port = 587;
                //        client.Credentials = new NetworkCredential("tien.dao@wisky.vn", "Tienthang123");
                //        client.EnableSsl = true;
                //        client.Send(messageRegion);
                //    }
                //}
                //#endregion
                return "Token sent, please check your email";
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Change or Reset Password
        /// </summary>
        /// <param name="passwordModel"></param>
        /// <returns></returns>
        public string ChangePassword(PasswordModel passwordModel)
        {
            try
            {
                var user = _repo.GetActive().Where(p => p.Email == passwordModel.Email).FirstOrDefault();
                if (user == null)
                {
                    return null;
                }

                bool? result;
                //  Request has token => Reset password 
                //  User forgot password
                if (!string.IsNullOrEmpty(passwordModel.Token))
                {
                    result = _aspNetUsersService.ResetPassword(passwordModel);
                    if (result == null)
                    {
                        return null;
                    }
                    if (!(bool)result)
                    {
                        return "Invalid token / confirm password not match";
                    }
                }
                //  Request has no token => Change Password
                //  User change to new password from old password
                else
                {
                    //if (string.IsNullOrEmpty(passwordModel.CurrentPassword))
                    //{
                    //    return null;
                    //}
                    if (passwordModel.NewPassword != passwordModel.ConfirmPassword)
                    {
                        return "Confirm password not match";
                    }
                    result = _aspNetUsersService.ChangePassword(new AspNetUsersPartialUpdateRequestModel()
                    {
                        Email = passwordModel.Email,
                        NewPassword = passwordModel.NewPassword,
                        CurrentPassword = passwordModel.CurrentPassword
                    });
                    if (result == null)
                    {
                        return "Invalid email or current password";
                    }
                }
                return "Change password successfully";
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update account info
        public override AccountServiceModel Update(AccountUpdateRequestModel requestModel)
        {
            try
            {
                var account = _repo.GetActive().Where(p => p.Email == requestModel.Email && p.Id == requestModel.Id).FirstOrDefault();
                if (account == null)
                {
                    return null;
                }

                account.Address = requestModel.Address;
                account.Name = requestModel.Name;
                account.Phone = requestModel.Phone;
                _repo.Update(account);
                _repo.SaveChanges();

                return Mapper.Map<Account, AccountServiceModel>(account);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Add Employee to System
        public string AddEmployee(ProjectAssignment model)
        {
            try
            {
                var employee = _repo.GetActive().Include(p => p.ManageProject).Where(p => p.Id == model.Id).FirstOrDefault();
                if (employee == null)
                {
                    return "Employee not exist";
                }
                if (model.ApplicationId > 0)
                {
                    var application = _applicationRepository.GetActive().Where(p => p.Id == model.ApplicationId).FirstOrDefault();
                    if (application == null)
                    {
                        return "Application not exist";
                    }
                    foreach (var p in employee.ManageProject)
                    {
                        if (p.ApplicationId == model.ApplicationId &&
                         p.AccountId == model.Id &&
                         p.ApplicationInstanceId == 22)
                        {
                            _manageProjectRepository.Remove(p.Id);
                            _manageProjectRepository.SaveChanges();
                            return "Remove Manager from project successfully";
                        }
                    }
                    _manageProjectRepository.Create(new ManageProject
                    {
                        AccountId = model.Id,
                        ApplicationId = model.ApplicationId,
                        ApplicationInstanceId = 22
                    });
                    _manageProjectRepository.SaveChanges();
                    return "Add Manager into project successfully";
                }
                else if (model.ApplicationInstanceId > 0)
                {
                    var applicationInstance = _applicationInstanceRepository.GetActive().Where(p => p.Id == model.ApplicationInstanceId).FirstOrDefault();
                    if (applicationInstance == null)
                    {
                        return "Application Instance not exist";
                    }
                    foreach (var p in employee.ManageProject)
                    {
                        if (p.ApplicationId == 22 &&
                         p.AccountId == model.Id &&
                         p.ApplicationInstanceId == model.ApplicationInstanceId)
                        {
                            _manageProjectRepository.Remove(p.Id);
                            _manageProjectRepository.SaveChanges();
                            return "Remove employee from project successfully";
                        }
                    }
                    _manageProjectRepository.Create(new ManageProject
                    {
                        AccountId = model.Id,
                        ApplicationId = 22,
                        ApplicationInstanceId = model.ApplicationInstanceId
                    });
                    _manageProjectRepository.SaveChanges();
                    return "Add employee into project successfully";
                }
                return "Please recorrect application / application instance";

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
