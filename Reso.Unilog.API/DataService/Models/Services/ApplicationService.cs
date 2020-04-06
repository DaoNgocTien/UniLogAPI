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
    public interface IApplicationService : IBaseService<ApplicationRepository, Application, ApplicationFilter, int, ApplicationServiceModel, ApplicationCreateRequestModel, ApplicationPartialUpdateRequestModel, ApplicationUpdateRequestModel>
    {
        ApplicationServiceModel CreateApp(ApplicationCreateRequestModel model);
        ApplicationServiceModel UpdateApp(ApplicationUpdateRequestModel model);
        ApplicationServiceModel ChangeStatus(int applicationId, bool active);
        //bool? RegisterService(int applicationServiceId, int applicationClientId);
        //bool? DeactiveService(int applicationServiceId, int applicationClientId);
    }
    public class ApplicationService : BaseService<ApplicationRepository, Application, ApplicationFilter, int, ApplicationServiceModel, ApplicationCreateRequestModel, ApplicationPartialUpdateRequestModel, ApplicationUpdateRequestModel>, IApplicationService
    {
        private readonly SystemsRepository _systemsRepository;
        public ApplicationService(
            ApplicationRepository repo,
            SystemsRepository systemsRepository,
            ApplicationServiceModel model
            ) : base(repo, model)
        {
            _systemsRepository = systemsRepository;
        }


        public override IQueryable<Application> GetReferenceFields(string ref_fields, IQueryable<Application> list)
        {
            try
            {
                if (ref_fields != null)
                {

                    //if (ref_fields.Contains("application_characteristic"))
                    //{
                    //    list = list.Include(p => p.ApplicationCharacteristic);
                    //}

                    if (ref_fields.Contains("systems"))
                    {
                        list = list.Include(p => p.Systems);
                    }

                    if (ref_fields.Contains("application_instance"))
                    {
                        list = list.Include(p => p.ApplicationInstance);
                    }

                    if (ref_fields.Contains("repo"))
                    {
                        list = list.Include(p => p.Repo);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }


        public override IQueryable<Application> GetSpecificRequests(ApplicationFilter filter, IQueryable<Application> list)
        {
            try
            {
                if (filter != null)
                {
                    if (filter.system_id > 0)
                    {
                        list = list.Where(p => p.SystemsId == filter.system_id);
                    }

                    if (filter.application_name != null)
                    {
                        list = list.Where(p => p.Name.Equals(filter.application_name));
                    }

                    if (filter.category > 0)
                    {
                        list = list.Where(p => p.Category == filter.category);
                    }

                    if (filter.origin != null)
                    {
                        list = list.Where(p => p.Origin.Equals(filter.origin));
                    }

                    if (filter.type != null)
                    {
                        list = list.Where(p => p.Type.Equals(filter.type));
                    }

                    if (filter.stage > 0)
                    {
                        list = list.Where(p => p.Stage == filter.stage);
                    }

                    if (filter.is_done == true)
                    {
                        list = list.Where(p => p.IsDone.Equals(filter.is_done));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }


        public ApplicationServiceModel CreateApp(ApplicationCreateRequestModel model)
        {
            try
            {
                var application = this.Create(model);

                //if (application != null)
                //{
                //    var appCharacteristic = new ApplicationCharacteristicCreateRequestModel()
                //    {
                //        ApplicationId = application.Id,
                //        ActualEfford = null,
                //    };
                //    var characteristic = _appCharacteristicService.Create(appCharacteristic);
                //}
                //if (model.IsService)
                //{
                //    _applicationRelationRepository.Create(new ApplicationRelation
                //    {
                //        ServiceId = application.Id,
                //        ClientId = 0
                //    });
                //    _applicationRelationRepository.SaveChanges();
                //}
                return application;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ApplicationServiceModel UpdateApp(ApplicationUpdateRequestModel model)
        {
            try
            {
                var app = _repo.GetActive().Where(p => p.Id == model.Id).FirstOrDefault();
                var system = _systemsRepository.GetActive().Where(s => s.Id == model.SystemsId).FirstOrDefault();
                if (app == null) return null;
                else
                {
                    //  Modify if application is service
                    //var currentAppRelation = _applicationRelationRepository.Get().Where(p => p.ServiceId == model.Id).FirstOrDefault();
                    //if (model.IsService)
                    //{                       
                    //    if( currentAppRelation == null)
                    //    {
                    //        _applicationRelationRepository.Create(new ApplicationRelation
                    //        {
                    //            ServiceId = model.Id,
                    //            ClientId = 0
                    //        });
                    //        _applicationRelationRepository.SaveChanges();
                    //    }
                    //}
                    //else
                    //{
                    //    _applicationRelationRepository.Remove(currentAppRelation);
                    //    _applicationRelationRepository.SaveChanges();
                    //}

                    //  Add service to this application
                    //serviceRelation.ClientId = model.Id;
                    //_applicationRelationRepository.Update(serviceRelation);
                    //_applicationRelationRepository.SaveChanges();

                    //  Update application detail
                    app.Id = model.Id;
                    app.Name = model.Name;
                    app.Description = model.Description;
                    app.Note = model.Note;
                    app.Category = model.Category;
                    app.Stage = model.Stage;
                    app.Origin = model.Origin;
                    app.Type = model.Type;
                    app.Technologies = model.Technologies;
                    app.Priority = model.Priority;
                    app.Status = model.Status;
                    app.IsDone = true;
                    //app.IsService = model.IsService;
                    app.SourceCodeUrl = model.SourceCodeUrl;
                    app.UpdateTime = model.UpdateTime;
                    app.StartDate = model.StartDate;
                    app.EndDate = model.EndDate;
                    if (model.SystemsId > 0 && system != null)
                        app.SystemsId = model.SystemsId;
                    //app.Link = model.Link;

                    _repo.Update(app);
                    _repo.SaveChanges();



                }
                return Mapper.Map<Application, ApplicationServiceModel>(app);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ApplicationServiceModel ChangeStatus(int applicationId, bool active)
        {
            try
            {
                var app = _repo.GetActive().Where(p => p.Id == applicationId).FirstOrDefault();
                if (app == null)
                {
                    return null;
                }
                else
                {
                    app.Active = active;
                    _repo.Update(app);
                    _repo.SaveChanges();
                }
                return Mapper.Map<Application, ApplicationServiceModel>(app);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public bool? RegisterService(int applicationServiceId, int applicationClientId)
        //{
        //    try
        //    {
        //        var appService = _repo.GetActive().Where(p => p.Id == applicationServiceId).FirstOrDefault();
        //        //if (appService.IsService == null || !((bool)appService.IsService))
        //        //{
        //        //    return false;
        //        //}
        //        if (appService == null)
        //        {
        //            return null;
        //        }
        //        var appClient = _repo.GetActive().Where(p => p.Id == applicationClientId).FirstOrDefault();
        //        if (appClient == null)
        //        {
        //            return null;
        //        }


        //        _applicationRelationRepository.Create(new ApplicationRelation
        //        {
        //            ServiceId = applicationServiceId,
        //            ClientId = applicationClientId
        //        });
        //        _applicationRelationRepository.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public bool? DeactiveService(int applicationServiceId, int applicationClientId)
        //{
        //    try
        //    {
        //        var appService = _repo.GetActive().Where(p => p.Id == applicationServiceId).FirstOrDefault();
        //        var appClient = _repo.GetActive().Where(p => p.Id == applicationClientId).FirstOrDefault();
        //        var serviceRelation = _applicationRelationRepository.Get().Where(p => p.ClientId == applicationClientId && p.ServiceId == applicationServiceId).FirstOrDefault();
        //        //if (appService.IsService == null || !((bool)appService.IsService))
        //        //{
        //        //    return false;
        //        //}
        //        if (appService == null || appClient == null || serviceRelation == null)
        //        {
        //            return null;
        //        }


        //        _applicationRelationRepository.Remove(serviceRelation);
        //        _applicationRelationRepository.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
