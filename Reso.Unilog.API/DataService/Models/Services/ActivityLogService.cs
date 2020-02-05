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
    public interface IActivityLogService : IBaseService<ActivityLogRepository, ActivityLog, ActivityLogFilter, int, ActivityLogServiceModel, ActivityLogCreateRequestModel, ActivityLogPartialUpdateRequestModel, ActivityLogUpdateRequestModel>
    {
    }
        public class ActivityLogService : BaseService<ActivityLogRepository, ActivityLog, ActivityLogFilter, int, ActivityLogServiceModel, ActivityLogCreateRequestModel, ActivityLogPartialUpdateRequestModel, ActivityLogUpdateRequestModel>, IActivityLogService
    {
        public ActivityLogService(ActivityLogRepository repo, ActivityLogServiceModel model) : base(repo,model)
        {
        }


        public override IQueryable<ActivityLog> GetReferenceFields(string ref_fields, IQueryable<ActivityLog> list)
        {
            try
            {
                if(ref_fields != null)
                {
                    if (ref_fields.Contains("app_code_navigation"))
                    {
                        list = list.Include( p => p.AppCodeNavigation);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }


        public override IQueryable<ActivityLog> GetSpecificRequests(ActivityLogFilter filter, IQueryable<ActivityLog> list)
        {
            try
            {
                if(filter != null)
                {                  

                    if(filter.start_time != null)
                    {
                        list = list.Where(p => p.Time >= filter.start_time);
                    }

                    if (filter.end_time != null)
                    {
                        list = list.Where(p => p.Time <= filter.end_time);
                    }

                    if(filter.app_code != null)
                    {
                        list = list.Where(p => p.AppCode.Equals(filter.app_code));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }


    }
}
