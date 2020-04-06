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
    public interface IApplicationInstanceService : IBaseService<ApplicationInstanceRepository, ApplicationInstance, ApplicationInstanceFilter, int, ApplicationInstanceServiceModel, ApplicationInstanceCreateRequestModel, ApplicationInstanceUpdateRequestModel, ApplicationInstancePartialUpdateRequestModel>
    {
    }
    public class ApplicationInstanceService : BaseService<ApplicationInstanceRepository, ApplicationInstance, ApplicationInstanceFilter, int, ApplicationInstanceServiceModel, ApplicationInstanceCreateRequestModel, ApplicationInstanceUpdateRequestModel, ApplicationInstancePartialUpdateRequestModel>, IApplicationInstanceService
    {
        public ApplicationInstanceService(ApplicationInstanceRepository repo, ApplicationInstanceServiceModel model) : base(repo, model)
        {

        }


        public override IQueryable<ApplicationInstance> GetReferenceFields(string ref_fields, IQueryable<ApplicationInstance> list)
        {
            try
            {
                if (ref_fields != null)
                {
                    if (ref_fields.Contains("app"))
                    {
                        list = list.Include(p => p.App);
                    }
                    
                    //if (ref_fields.Contains("activity_log"))
                    //{
                    //    list = list.Include(p => p.ActivityLog);
                    //}

                    if (ref_fields.Contains("log"))
                    {
                        list = list.Include(p => p.Log);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }

        public override IQueryable<ApplicationInstance> GetSpecificRequests(ApplicationInstanceFilter filter, IQueryable<ApplicationInstance> list)
        {
            try
            {
                if (filter != null)
                {

                    if (filter.application_id > 0)
                    {
                        list = list.Where(p => p.AppId == filter.application_id);
                    }
                 
                    if (filter.app_code != null)
                    {
                        list = list.Where(p => p.AppCode.Equals(filter.app_code));
                    }


                    if (filter.account_id > 0)
                    {
                        list = list.Where(p => p.ManageProject.Any(q => q.AccountId == filter.account_id));
                    }
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }

        public override ApplicationInstanceServiceModel Update(ApplicationInstanceUpdateRequestModel model)
        {
            try
            {
                var currentAppIns = _repo.GetActive().Where(appIns => appIns.Id == model.Id).FirstOrDefault();
                if (currentAppIns != null)
                {
                    currentAppIns.ApplicationVersion = model.ApplicationVersion;
                    currentAppIns.ConfigUrl = model.ConfigUrl;
                    currentAppIns.Description = model.Description;
                    currentAppIns.Name = model.Name;
                    currentAppIns.ReleaseUrl = model.ReleaseUrl;
                    currentAppIns.UpdateTime = model.UpdateTime;

                    _repo.Update(currentAppIns);
                    _repo.SaveChanges();

                    return Mapper.Map<ApplicationInstance, ApplicationInstanceServiceModel>(currentAppIns);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public override ApplicationInstanceServiceModel PartialUpdate(ApplicationInstancePartialUpdateRequestModel model)
        {
            try
            {
                var currentAppIns = _repo.GetActive().Where(appIns => appIns.Id == model.Id).FirstOrDefault();
                if (currentAppIns != null)
                {
                    currentAppIns.AppCode = model.AppCode;
                    currentAppIns.UpdateTime = model.UpdateTime;

                    _repo.Update(currentAppIns);
                    _repo.SaveChanges();

                    return Mapper.Map<ApplicationInstance, ApplicationInstanceServiceModel>(currentAppIns);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public string ChangeStatus (int id)
        {
            try
            {
                var currentAppIns = _repo.GetActive().Where(appIns => appIns.Id == id).FirstOrDefault();
                if (currentAppIns != null)
                {
                    currentAppIns.Active = !currentAppIns.Active;

                    _repo.Update(currentAppIns);
                    _repo.SaveChanges();
                    return "Change Status successfully";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        //#region Generate AppCode
        // public string GenerateAppCode()
        //{
        //    string appCode = "";
        //    UniLogUtil uniLogUtil = new UniLogUtil();
        //    ApplicationInstance result = new ApplicationInstance();
        //    do
        //    {
        //        appCode = uniLogUtil.GetRandomString();
        //        result = _repo.FirstOrDefault(p => p.AppCode.Equals(appCode));
        //    } while (result != null);

        //    return appCode;
        //}
        //#endregion

    }
}
