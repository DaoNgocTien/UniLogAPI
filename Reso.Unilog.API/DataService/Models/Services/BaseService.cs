using AutoMapper;
using Core.DataService.Models.Filters;
using DataService.Models.Gen;
using DataService.Models.Repositories;
using DataService.ServiceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using TNT.Core.Helpers.Data;

namespace DataService.Models.Services
{
    public partial interface IBaseService
    {

    }

    public partial interface IBaseService<BaseRepo, E, F, T, M, PostRM, PutRM, PatchRM> : IBaseService
        where BaseRepo : IBaseRepository<E, T>
        where E : class
        where F : BaseFilter
        where M : BaseServiceModel<E>
        where PostRM : class
        where PutRM : class
        where PatchRM : class
    {
        IEnumerable<object> Get(F filter);
        //JsonSerializerSettings ToJson(string fields)
        M Create(PostRM requestModel);
        M Update(PutRM requestModel);
        M PartialUpdate(PatchRM requestModel);
        object GetById(F filter);
        IQueryable<E> GetByIds(List<int> ids, IQueryable<E> list);
        IQueryable<E> GetSinceId(int sinceId, IQueryable<E> list);
        IQueryable<E> GetByMinCreateTime(IQueryable<E> list, DateTime create_at_min);
        IQueryable<E> GetByMaxCreateTime(IQueryable<E> list, DateTime create_at_max);
        IQueryable<E> GetReferenceFields(string ref_fields, IQueryable<E> list);
        IQueryable<E> GetSpecificRequests(F filter, IQueryable<E> list);


        
    }

    public abstract partial class BaseService<BaseRepo, E, F, T, M, PostRM, PutRM, PatchRM> : IBaseService<BaseRepo, E, F, T, M, PostRM, PutRM, PatchRM>
       where BaseRepo : BaseRepository<E, T>
       where E : class
        where F : BaseFilter
        where M : BaseServiceModel<E>
        where PostRM : class
        where PutRM : class
        where PatchRM : class
    {
        protected BaseRepo _repo;
        protected M _model;
        public BaseService(BaseRepo repo, M model)
        {
            _repo = repo;
            _model = model;
        }

        protected IEnumerable<M> ServiceModel { get; set; }
        public IConfigurationProvider AutoMapperConfig
        {
            get
            {
                return Service<IConfigurationProvider>();
            }
        }

        public S Service<S>() where S : class
        {
            return DependencyResolverExtensions.GetService<S>(D‌​ependencyResolver.Current);
        }

        public virtual M Create(PostRM requestModel)
        {
            try
            {
                var result = Mapper.Map<PostRM, E>(requestModel);
                _repo.Create(result);
                _repo.SaveChanges();
                return Mapper.Map<E, M>(result);
            }
            catch (Exception)
            {
                throw;
            }

        }
        

        public virtual M Update(PutRM requestModel)
        {
            return _model;
        }

        public virtual M PartialUpdate(PatchRM requestModel)
        {
            return _model;
        }

        public virtual IEnumerable<object> Get(F filter)
        {
            try
            {
                var rs = _repo.GetActive();
                if (filter != null)
                {
                    #region Handle Ids
                    if (!string.IsNullOrEmpty(filter.ids))
                    {
                        var ids = filter.ids.Split(',').Select(int.Parse).ToList();
                        rs = this.GetByIds(ids, rs);
                    }

                    //Handle since Id
                    if (filter.since_id > 0)
                    {
                        rs = this.GetSinceId(filter.since_id, rs);
                    }
                    #endregion

                    #region Handle Time   
                    if (filter.create_at_min != null && filter.create_at_min != default(DateTime))
                    {
                        rs = this.GetByMinCreateTime(rs, filter.create_at_min);
                    }

                    if (filter.create_at_max != null && filter.create_at_max != default(DateTime))
                    {
                        rs = this.GetByMaxCreateTime(rs, filter.create_at_max);
                    }
                    #endregion

                    #region Handle Specific request

                    rs = GetSpecificRequests(filter, rs);
                    #endregion

                    #region Handle ReferencesFields
                    if (filter.ref_fields != null)
                    {
                        rs = this.GetReferenceFields(filter.ref_fields, rs);
                    }
                    #endregion

                    #region Handle Limit
                    //if (filter.limit > 0 && filter.limit <= 250)
                    if (filter.limit > 0)
                        rs = rs.Take(filter.limit);
                    else
                        rs = rs.Take(50);
                    #endregion

                    #region Handle fields after mapping
                    var result = rs.Select(s => Mapper.Map<E, M>(s)).ToList();
                    if (!string.IsNullOrEmpty(filter.fields))
                    {
                        var fields = ("id," + filter.fields).Split(',');
                        return result.SelectOnly(false, SelectOption.ByJsonProperty, fields);
                    }
                    return result;
                    #endregion
                }
                return rs.Select(q => Mapper.Map<E, M>(q)).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public object GetById(F filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter.ids))
                {
                    return null;
                }
                return Get(filter).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        //  public JsonSerializerSettings ToJson(string fields)
        //{
        //    var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();            
        //    var jsonProperty = _model.GetType().GetProperties()
        //         .SelectMany(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute))
        //                           .Cast<JsonPropertyAttribute>())
        //         .Select(jp => jp.PropertyName);
        //    if (!string.IsNullOrEmpty(fields))
        //    {
        //        foreach (var item in jsonProperty)
        //        {
        //            if (!fields.Contains(item))
        //            {
        //                jsonResolver.IgnoreProperty(typeof(AgencyServiceModel), item);
        //            }
        //        }
        //    }
        //    var serializerSettings = new JsonSerializerSettings
        //    {
        //        ContractResolver = jsonResolver
        //    };
        //    return serializerSettings;
        //}

        public IQueryable<E> GetByIds(List<int> ids, IQueryable<E> list)
        {
            if (typeof(IGetting).IsAssignableFrom(typeof(E)))
            {
                Expression<Func<E, bool>> node = (E q) => ids.Contains(((IGetting)q).Id);
                node = (Expression<Func<E, bool>>)RemoveCastsVisitor.Visit(node);

                return Queryable.Where<E>(list, node);
            }
            return list;
        }
        public IQueryable<E> GetSinceId(int sinceId, IQueryable<E> list)
        {
            if (typeof(IGetting).IsAssignableFrom(typeof(E)))
            {
                Expression<Func<E, bool>> node = (E q) => ((IGetting)q).Id >= sinceId;
                node = (Expression<Func<E, bool>>)RemoveCastsVisitor.Visit(node);
                return Queryable.Where<E>(list, node);
            }
            return list;
        }

        public IQueryable<E> GetByMinCreateTime(IQueryable<E> list, DateTime create_at_min)
        {
            if (typeof(IGetting).IsAssignableFrom(typeof(E)))
            {
                Expression<Func<E, bool>> node = (E q) => ((IGetting)q).CreateTime >= create_at_min;
                node = (Expression<Func<E, bool>>)RemoveCastsVisitor.Visit(node);
                return Queryable.Where<E>(list, node);
            }
            return list;
        }

        public IQueryable<E> GetByMaxCreateTime(IQueryable<E> list, DateTime create_at_max)
        {
            if (typeof(IGetting).IsAssignableFrom(typeof(E)))
            {
                Expression<Func<E, bool>> node = (E q) => ((IGetting)q).CreateTime <= create_at_max;
                node = (Expression<Func<E, bool>>)RemoveCastsVisitor.Visit(node);
                return Queryable.Where<E>(list, node);
            }
            return list;
        }




        public virtual IQueryable<E> GetReferenceFields(string ref_fields, IQueryable<E> list)
        {
            return list;
        }


        public virtual IQueryable<E> GetSpecificRequests(F filter, IQueryable<E> list)
        {
            return list;
        }


       
    }
}
