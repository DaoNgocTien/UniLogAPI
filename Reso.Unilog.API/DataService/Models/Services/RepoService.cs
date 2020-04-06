﻿using AutoMapper;
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
    public interface IRepoService : IBaseService<RepoRepository, Repo, RepoFilter, int, RepoServiceModel, RepoCreateRequestModel, RepoPartialUpdateRequestModel, RepoUpdateRequestModel>
    {
        RepoServiceModel UpdateRepo(RepoUpdateRequestModel model);
        String Remove(int appID, int serverID);
    }
        public class RepoService : BaseService<RepoRepository, Repo, RepoFilter, int, RepoServiceModel, RepoCreateRequestModel, RepoPartialUpdateRequestModel, RepoUpdateRequestModel>, IRepoService
    {
        public RepoService(RepoRepository repo, RepoServiceModel model) : base(repo, model)
        {

        }



        public override IQueryable<Repo> GetReferenceFields(string ref_fields, IQueryable<Repo> list)
        {
            try
            {
                if(ref_fields != null)
                {
                    if (ref_fields.Contains("application"))
                    {
                        list = list.Include(p => p.Application);
                    }


                    if (ref_fields.Contains("server"))
                    {
                        list = list.Include(p => p.Server);
                    }
                }
            }
            catch (Exception )
            {

                throw;
            }
            return list;
        }



        public override IQueryable<Repo> GetSpecificRequests(RepoFilter filter, IQueryable<Repo> list)
        {
            try
            {
                if(filter != null)
                {
                    if(filter.server_id > 0)
                    {
                        list = list.Where(p => p.ServerId == filter.server_id);
                    }


                    if (filter.application_id > 0)
                    {
                        list = list.Where(p => p.ApplicationId == filter.application_id);
                    }


                    //if (filter.company_id > 0)
                    //{
                    //    list = list.Where(p => p.Server.CompanyId == filter.company_id);
                    //}


                    if (filter.name != null)
                    {
                        list = list.Where(p => p.Name.Equals(filter.name));
                    }
                }
            }
            catch (Exception )
            {

                throw;
            }
            return list;
        }



        public RepoServiceModel UpdateRepo(RepoUpdateRequestModel model)
        {
            try
            {
                var repo = _repo.GetActive().Where(p => p.ServerId == model.ServerId && p.ApplicationId == model.ApplicationId).FirstOrDefault();
                //  create new repo
                if (repo == null) {
                    return this.Create(new RepoCreateRequestModel()
                    {
                        ApplicationId = model.ApplicationId,
                        Name = model.Name,
                        Note= model.Note,
                        RepoUrl = model.RepoUrl,
                        ServerId = model.ServerId
                    });
                }
                //  update current repo
                else
                {
                    repo.Name = model.Name;
                    repo.ApplicationId = model.ApplicationId;
                    repo.ServerId = model.ServerId;
                    repo.RepoUrl = model.RepoUrl;
                    repo.Note = model.Note;
                    repo.Active = true;

                    _repo.Update(repo);
                    _repo.SaveChanges();
                }
                return Mapper.Map<Repo, RepoServiceModel>(repo);
            }
            catch (Exception )
            {

                throw;
            }
        }

        public string Remove (int appID, int serverID)
        {
            try
            {
                var currentRepo = _repo.GetActive().Where(r => r.ApplicationId == appID && r.ServerId == serverID).FirstOrDefault();
                _repo.Remove(currentRepo);
                _repo.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return "Remove Repo successfully";
        }
    }
}
