using AutoMapper;
using DataService.Models.Filters;
using DataService.Models.Repositories;
using DataService.RequestModels;
using DataService.ServiceModels;
using System;
using System.Linq;

namespace DataService.Models.Services
{
    public interface IServerDetailService : IBaseService<IServerDetailRepository, ServerDetail, ServerDetailFilter, int, ServerDetailServiceModel, ServerDetailServiceModel, ServerDetailUpdateRequestModel, ServerDetailServiceModel>
    {

    }
    public class ServerDetailService : BaseService<ServerDetailRepository, ServerDetail, ServerDetailFilter, int, ServerDetailServiceModel, ServerDetailServiceModel, ServerDetailUpdateRequestModel, ServerDetailServiceModel>, IServerDetailService
    {
        //private readonly ICompanyRepository _companyRepository;
        public ServerDetailService(
            //ICompanyRepository companyRepository, 
            ServerDetailRepository repo, ServerDetailServiceModel model) : base(repo, model)
        {
            //_companyRepository = companyRepository;
        }

        public override ServerDetailServiceModel Update(ServerDetailUpdateRequestModel requestModel)
        {
            try
            {
                var serverDetail = _repo.GetActive().Where(p => p.Id == requestModel.Id && p.ServerId == requestModel.ServerId).FirstOrDefault();
                //  if server detail is not existed, create
                if (serverDetail == null){
                    ServerDetailServiceModel serverDetailNew = new ServerDetailServiceModel()
                    {
                        Disk1 = requestModel.Disk1,
                        Disk2 = requestModel.Disk2,
                        Disk3 = requestModel.Disk3,
                        VolumeDisk1 = requestModel.VolumeDisk1,
                        VolumeDisk2 = requestModel.VolumeDisk2,
                        VolumeDisk3 = requestModel.VolumeDisk3,
                        ServerId = requestModel.ServerId,
                        UpdateTime = requestModel.UpdateTime
                    };
                    var result = Mapper.Map<ServerDetailServiceModel, ServerDetail>(serverDetailNew);
                    _repo.Create(result);
                    _repo.SaveChanges();
                    return Mapper.Map<ServerDetail, ServerDetailServiceModel>(result);
                }
                //  if server detail is existed, update
                if (!requestModel.Disk1.Trim().IsNullOrEmpty() && !requestModel.VolumeDisk1.Trim().IsNullOrEmpty())
                {
                    serverDetail.Disk1 = requestModel.Disk1;
                    serverDetail.VolumeDisk1 = requestModel.VolumeDisk1;
                }
                if (!requestModel.Disk2.Trim().IsNullOrEmpty() && !requestModel.VolumeDisk2.Trim().IsNullOrEmpty())
                {
                    serverDetail.Disk2 = requestModel.Disk2;
                    serverDetail.VolumeDisk2 = requestModel.VolumeDisk2;
                }
                if (!requestModel.Disk3.Trim().IsNullOrEmpty() && !requestModel.VolumeDisk3.Trim().IsNullOrEmpty())
                {
                    serverDetail.Disk3 = requestModel.Disk3;
                    serverDetail.VolumeDisk3 = requestModel.VolumeDisk3;
                }
                serverDetail.UpdateTime = requestModel.UpdateTime;
                //if (!requestModel.LogEvent.Trim().IsNullOrEmpty())
                //{
                //    serverDetail.LogEvent = requestModel.LogEvent;
                //}
                //if (!requestModel.Notification.Trim().IsNullOrEmpty())
                //{
                //    serverDetail.Notification = requestModel.Notification;
                //}
                _repo.Update(serverDetail);
                _repo.SaveChanges();
                return Mapper.Map<ServerDetail, ServerDetailServiceModel>(serverDetail);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

