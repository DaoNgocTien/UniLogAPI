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
    public interface ISystemService : IBaseService<ISystemsRepository, Systems, SystemFilter, int, SystemsServiceModel, SystemCreateRequestModel, SystemPartialUpdateRequestModel, SystemUpdateRequestModel>
    {
        SystemsServiceModel UpdateActive(SystemPartialUpdateRequestModel model);
        SystemsServiceModel RemoveSystem(SystemUpdateRequestModel model);
        string AddEmployee(int accountID, int serverID);
    }
    public class SystemService : BaseService<SystemsRepository, Systems, SystemFilter, int, SystemsServiceModel, SystemCreateRequestModel, SystemPartialUpdateRequestModel, SystemUpdateRequestModel>
    {
        private ISystemsRepository _systems;
        private readonly IManageProjectRepository _manageProjectRepository;
        private readonly IAccountRepository _accountRepository;
        public SystemService(IManageProjectRepository manageProjectRepository, IAccountRepository accountRepository, SystemsRepository repo, SystemsServiceModel model, ISystemsRepository systems) : base(repo, model)
        {
            _systems = systems;
            _manageProjectRepository = manageProjectRepository;
            _accountRepository = accountRepository;
        }

        public override IQueryable<Systems> GetReferenceFields(string ref_fields, IQueryable<Systems> list)
        {
            try
            {
                #region Handle ReferencesFields
                if (ref_fields != null)
                {
                    //if (ref_fields.Contains("company"))
                    //{
                    //    list = list.Include(q => q.Company);
                    //}


                    if (ref_fields.Contains("application"))
                    {
                        list = list.Include(q => q.Application);
                    }


                    //if (ref_fields.Contains("manage_project"))
                    //{
                    //    list = list.Include(q => q.ManageProject);
                    //}


                    //if (ref_fields.Contains("system_instance"))
                    //{
                    //    list = list.Include(q => q.SystemInstance);
                    //}
                }
                #endregion
                return list;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public override IQueryable<Systems> GetSpecificRequests(SystemFilter filter, IQueryable<Systems> list)
        {
            try
            {
                if (filter != null)
                {
                    //if (filter.company_id > 0)
                    //{
                    //    list = list.Where(p => p.CompanyId == filter.company_id);
                    //}
                    if (!string.IsNullOrEmpty(filter.name))
                    {
                        list = list.Where(p => p.Name == filter.name);
                    }

                    if (filter.active == true)
                    {
                        list = list.Where(p => p.Active == filter.active);
                    }
                }
                return list;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public SystemsServiceModel UpdateActive(SystemPartialUpdateRequestModel model)
        {
            try
            {
                var system = _repo.GetActive().Where(p => p.Id == model.Id).FirstOrDefault();
                if (system == null)
                {
                    return null;
                }
                else
                {
                    system.Active = model.Active;
                    _repo.Update(system);
                    _repo.SaveChanges();
                }
                return Mapper.Map<Systems, SystemsServiceModel>(system);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string AddEmployee(int accountID, int systemID)
        {
            try
            {
                var systems = _repo.GetActive().Where(p => p.Id == systemID).FirstOrDefault();
                if (systems == null)
                {
                    return "System not exist";
                }
                var employee = _accountRepository.GetActive().Where(p => p.Id == accountID).FirstOrDefault();
                if (employee == null)
                {
                    return "Employee not exist";
                }
                var manageServer = _manageProjectRepository.Get().Where(p => p.AccountId == accountID ).FirstOrDefault();
                if (manageServer == null)
                {
                    _manageProjectRepository.Create(new ManageProject
                    {
                        AccountId = accountID,
                    });
                    _manageProjectRepository.SaveChanges();
                }
                return "Add employee into system successfully";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SystemsServiceModel RemoveSystem(SystemDeleteRequestModel model)
        {
            try
            {
                var system = _repo.GetActive().Where(p => p.Id == model.Id).FirstOrDefault();
                if (system == null)
                {
                    return null;
                }
                else
                {
                    system.Active = false;
                    _repo.Update(system);
                    _repo.SaveChanges();
                }
                return Mapper.Map<Systems, SystemsServiceModel>(system);
            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
