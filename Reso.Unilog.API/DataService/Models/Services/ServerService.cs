using AutoMapper;
using DataService.Models.Filters;
using DataService.Models.Repositories;
using DataService.RequestModels;
using DataService.ServiceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataService.Models.Services
{
    public interface IServerService : IBaseService<IServerRepository, Server, ServerFilter, int, ServerServiceModel, ServerCreateRequestModel, ServerUpdateRequestModel, ServerPartialUpdateRequestModel>
    {

    }
    public class ServerService : BaseService<ServerRepository, Server, ServerFilter, int, ServerServiceModel, ServerCreateRequestModel, ServerUpdateRequestModel, ServerPartialUpdateRequestModel>, IServerService
    {
        //private readonly ICompanyRepository _companyRepository;
        public ServerService(
            //ICompanyRepository companyRepository, 
            ServerRepository repo,
            ServerServiceModel model) : base(repo, model)
        {
            //_companyRepository = companyRepository;
        }
        public override IQueryable<Server> GetSpecificRequests(ServerFilter filter, IQueryable<Server> list)
        {
            try
            {
                if (filter != null)
                {
                    //if (filter.company_id > 0)
                    //{
                    //    list = list.Where(p => p.CompanyId == filter.company_id);
                    //}
                    if (!string.IsNullOrEmpty(filter.server_code))
                    {
                        list = list.Where(p => p.ServerCode == filter.server_code);
                    }
                    if (filter.server_master > 0)
                    {
                        list = list.Where(p => p.ServerMaster == filter.server_master);
                    }
                    if (filter.type > 0)
                    {
                        list = list.Where(p => p.Type == filter.type);
                    }
                    if (filter.os > 0)
                    {
                        list = list.Where(p => p.Os == filter.os);
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override IQueryable<Server> GetReferenceFields(string ref_fields, IQueryable<Server> list)
        {
            try
            {

                if (!string.IsNullOrEmpty(ref_fields))
                {
                    //if (ref_fields.Contains("company"))
                    //{
                    //    list = list.Include(p => p.Company);
                    //}
                    if (ref_fields.Contains("server_master_navigation"))
                    {
                        list = list.Include(p => p.ServerMasterNavigation);
                    }
                    if (ref_fields.Contains("server_detail"))
                    {
                        list = list.Include(p => p.ServerDetail);
                    }
                    if (ref_fields.Contains("server_master_navigation"))
                    {
                        list = list.Include(p => p.ServerMasterNavigation);
                    }
                    if (ref_fields.Contains("inverse_server_master_navigation"))
                    {
                        list = list.Include(p => p.InverseServerMasterNavigation);
                    }
                    if (ref_fields.Contains("repo"))
                    {
                        list = list.Include(p => p.Repo);
                    }
                    if (ref_fields.Contains("server_account"))
                    {
                        list = list.Include(p => p.ServerAccount);
                    }
                    //if (ref_fields.Contains("system_instance"))
                    //{
                    //    list = list.Include(p => p.SystemInstance);
                    //}
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override ServerServiceModel PartialUpdate(ServerPartialUpdateRequestModel requestModel)
        {
            try
            {
                var server = _repo.Get().Where(p => p.Id == requestModel.Id).FirstOrDefault();
                if (server == null)
                {
                    return null;
                }
                server.Active = requestModel.Active;
                _repo.Update(server);
                _repo.SaveChanges();

                
                return AutoMapper.Mapper.Map<Server, ServerServiceModel>(server);
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        public override ServerServiceModel Create(ServerCreateRequestModel requestModel)
        {
            try
            {
                //var company = _companyRepository.GetActive().Where(p => p.Id == requestModel.CompanyId).FirstOrDefault();
                //if (company == null)
                //{
                //    return null;
                //}
                var existServer = _repo.Get().Where(p => p.Name == requestModel.Name).FirstOrDefault();
                if (existServer != null)
                {
                    return null;
                }
                var server = AutoMapper.Mapper.Map<ServerCreateRequestModel, Server>(requestModel);
                _repo.Create(server);
                _repo.SaveChanges();
                return AutoMapper.Mapper.Map<Server, ServerServiceModel>(server);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override ServerServiceModel Update(ServerUpdateRequestModel requestModel)
        {
            try
            {
                var server = _repo.Get().Where(p => p.Id == requestModel.Id).FirstOrDefault();
                if (server == null)
                {
                    return null;
                }
                server.ServerMaster = requestModel.ServerMaster != 0 ? requestModel.ServerMaster : null;
                server.Name = requestModel.Name;
                server.IpAddress = requestModel.IpAddress;
                server.Type = requestModel.Type;
                server.Os = requestModel.Os;
                server.ServerUrl = requestModel.ServerUrl;
                server.Description = requestModel.Description;
                server.ExpiredDate = requestModel.ExpiredDate;
                server.ServerCode = requestModel.ServerCode;
                server.UpdateTime = requestModel.UpdateTime;
                _repo.Update(server);
                _repo.SaveChanges();

                return Mapper.Map<Server, ServerServiceModel>(server);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
