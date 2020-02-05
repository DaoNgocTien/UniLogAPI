using AutoMapper;
using DataService.Models.Filters;
using DataService.Models.Repositories;
using DataService.RequestModels;
using DataService.RequestModels.CreateRequestModels;
using DataService.ServiceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Models.Services
{
    public interface IServerAccountService : IBaseService<ServerAccountRepository, ServerAccount, ServerAccountFilter, int, ServerAccountServiceModel, ServerAccountCreateRequestModel, ServerAccountPartialUpdateRequestModel, ServerAccountUpdateRequestModel>
    {
        ServerAccountServiceModel UpdateServerAccount(ServerAccountUpdateRequestModel model);
    }
        public class ServerAccountService  : BaseService<ServerAccountRepository, ServerAccount, ServerAccountFilter, int, ServerAccountServiceModel, ServerAccountCreateRequestModel, ServerAccountPartialUpdateRequestModel, ServerAccountUpdateRequestModel>, IServerAccountService
    {
        public ServerAccountService(ServerAccountRepository repo, ServerAccountServiceModel model) : base(repo, model)
        {
        }


        public override IQueryable<ServerAccount> GetReferenceFields(string ref_fields, IQueryable<ServerAccount> list)
        {
            try
            {
                if(ref_fields != null)
                {
                    if (ref_fields.Contains("server"))
                    {
                        list = list.Include(p => p.Server);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }



        public override IQueryable<ServerAccount> GetSpecificRequests(ServerAccountFilter filter, IQueryable<ServerAccount> list)
        {
            try
            {
                if(filter != null)
                {
                    if(filter.username != null)
                    {
                        list = list.Where(p => p.Username == filter.username);
                    }

                    if(filter.server_id > 0)
                    {
                        list = list.Where(p => p.ServerId == filter.server_id);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }



        public ServerAccountServiceModel UpdateServerAccount(ServerAccountUpdateRequestModel model)
        {
            try
            {
                var result = _repo.GetActive().Where(p => p.Id == model.Id).FirstOrDefault();
                if (result == null) return null;
                else
                {
                    result.Username = model.Username;
                    result.Password = model.Password;
                    result.Owner = model.Owner;
                    result.Note = model.Note;
                    result.Active = model.Active;

                    _repo.Update(result);
                    _repo.SaveChanges();
                }
                return Mapper.Map<ServerAccount, ServerAccountServiceModel>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
