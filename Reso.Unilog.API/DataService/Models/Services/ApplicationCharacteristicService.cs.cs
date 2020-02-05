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
using TNT.Core.Helpers.Data;

namespace DataService.Models.Services
{
    public interface IApplicationCharacteristicService : IBaseService<ApplicationCharacteristicRepository, ApplicationCharacteristic, ApplicationCharacteristicFilter, int, ApplicationCharacteristicServiceModel, ApplicationCharacteristicCreateRequestModel, ApplicationCharacteristicPartialUpdateRequestModel, ApplicationCharacteristicUpdateRequestModel>
    {
        ApplicationCharacteristicServiceModel UpdateApplicationCharacteristic(ApplicationCharacteristicUpdateRequestModel model);
    }
    public class ApplicationCharacteristicService : BaseService<ApplicationCharacteristicRepository, ApplicationCharacteristic, ApplicationCharacteristicFilter, int, ApplicationCharacteristicServiceModel, ApplicationCharacteristicCreateRequestModel, ApplicationCharacteristicPartialUpdateRequestModel, ApplicationCharacteristicUpdateRequestModel>
    {
        public ApplicationCharacteristicService(ApplicationCharacteristicRepository repo, ApplicationCharacteristicServiceModel model) : base(repo, model)
        {            
        }


        public override IQueryable<ApplicationCharacteristic> GetReferenceFields(string ref_fields, IQueryable<ApplicationCharacteristic> list)
        {
            try
            {
                if(ref_fields != null)
                {
                    if (ref_fields.Contains("application"))
                    {
                        list = list.Include(p => p.Application);
                    }                  
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }

        public override IQueryable<ApplicationCharacteristic> GetSpecificRequests(ApplicationCharacteristicFilter filter, IQueryable<ApplicationCharacteristic> list)
        {
            try
            {
                if(filter != null)
                {
                    if(filter.application_id > 0)
                    {
                        list = list.Where(p => p.ApplicationId == filter.application_id);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }

        public ApplicationCharacteristicServiceModel UpdateApplicationCharacteristic(ApplicationCharacteristicUpdateRequestModel model)
        {
            var appCharacteristic = _repo.GetActive().Where(p => p.ApplicationId == model.ApplicationId).FirstOrDefault();
             if (appCharacteristic == null)
            {
                return null;
            }
            else
            {
                appCharacteristic.ActualEfford = null;
               // appCharacteristic.Active = true;

                _repo.Update(appCharacteristic);
                _repo.SaveChanges();

                
            }
            return Mapper.Map<ApplicationCharacteristic, ApplicationCharacteristicServiceModel>(appCharacteristic);
        }
    }
}
