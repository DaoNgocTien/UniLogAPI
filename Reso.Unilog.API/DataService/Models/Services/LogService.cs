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
    public interface ILogService : IBaseService<ILogRepository, Log, LogFilter, int, LogServiceModel, LogCreateRequestModel, LogUpdateRequestModel, LogPartialUpdateRequestModel>
    {
        void SendLogError(Exception e);
        void SendLogError(Exception e, string appCode);
        LogCreateRequestModel ParseExceptionToExceptionModel(Exception e);
    }
    public class LogService : BaseService<LogRepository, Log, LogFilter, int, LogServiceModel, LogCreateRequestModel, LogUpdateRequestModel, LogPartialUpdateRequestModel>
    {
        public LogService(LogRepository repo, LogServiceModel model) : base(repo, model)
        {
        }

        public override IQueryable<Log> GetSpecificRequests(LogFilter filter, IQueryable<Log> list)
        {
            try
            {
                if (filter != null)
                {
                    if (filter.start_time != null)
                    {
                        list = list.Where(p => p.LogDate.Date >= filter.start_time);
                    }
                    if (filter.end_time != null)
                    {
                        list = list.Where(p => p.LogDate.Date <= filter.end_time);
                    }
                    if (!string.IsNullOrEmpty(filter.app_code))
                    {
                        list = list.Where(p => p.AppCode == filter.app_code);
                    }
                    if (filter.serverity > 0)
                    {
                        list = list.Where(p => p.LogType == filter.serverity);
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override IQueryable<Log> GetReferenceFields(string ref_fields, IQueryable<Log> list)
        {
            try
            {
                if (!string.IsNullOrEmpty(ref_fields))
                {
                    if (ref_fields.Contains("application_instance"))
                    {
                        list = list.Include(p => p.AppCodeNavigation);
                    }
                  if (ref_fields.Contains("error_code"))
                    {
                        list = list.Include(p => p.ErrorCode);
                    }
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        #region Parse Exception
        public LogCreateRequestModel ParseExceptionToExceptionModel(LogErrorCreateRequestModel model)
        {
            try
            {
                var ex = new LogCreateRequestModel();
                int index = model.Exception.StackTrace.IndexOf("line");
                int index2 = model.Exception.StackTrace.LastIndexOf("\\");
                int index3 = model.Exception.StackTrace.IndexOf("in ");
                ex.Message = model.Exception.Message;
                if (model.Exception.InnerException != null)
                {
                    ex.Message += "\n" + model.Exception.InnerException.Message;
                    if (model.Exception.InnerException.InnerException != null)
                    {
                        ex.Message += "\n" + model.Exception.InnerException.InnerException.Message;
                    }
                }
                var link = model.Exception.StackTrace.Substring(index3 + 3).Replace(model.Exception.StackTrace.Substring(index2), "");
                int index4 = (link).LastIndexOf("\\");
                ex.ProjectName = (link).Substring(index4 + 1);
                ex.FileName = model.Exception.StackTrace.Substring(index2 + 1).Replace(":" + model.Exception.StackTrace.Substring(index), "");
                var line = model.Exception.StackTrace.Substring(index + 5);
                var nextSpace = line.IndexOf(' ');
                if (nextSpace > 0)
                    line = line.Remove(nextSpace);
                ex.LineCode = Int32.Parse(line);
                ex.AppCode = model.AppCode;
                //ex.LogType = (model.LogType < 1 || model.LogType > 3) ? 3 : model.LogType;
                ex.LogType = 3;
                ex.Serverity = model.Serverity;
                return ex;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public override LogServiceModel PartialUpdate(LogPartialUpdateRequestModel requestModel)
        {
            try
            {
                var result = _repo.Get().Where(p => p.Id == requestModel.Id).FirstOrDefault();
                if (result == null)
                {
                    return null;
                }
                result.Active = requestModel.Active;
                _repo.SaveChanges();
                return Mapper.Map<Log, LogServiceModel>(result);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void SendLogError(Exception e)
        {
            try
            {
                LogErrorCreateRequestModel error = new LogErrorCreateRequestModel()
                {
                    Exception = e,
                    AppCode = "Kachy",
                    Serverity = 5
                };
                LogCreateRequestModel createError = ParseExceptionToExceptionModel(error);
                Create(createError);
            }
            catch (Exception)
            {
                throw;
            }            
        }
        public void SendLogError(Exception e, string appCode)
        {
            try
            {
                LogErrorCreateRequestModel error = new LogErrorCreateRequestModel()
                {
                    Exception = e,
                    AppCode = appCode,
                    Serverity = 5
                };
                LogCreateRequestModel createError = ParseExceptionToExceptionModel(error);
                Create(createError);
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
