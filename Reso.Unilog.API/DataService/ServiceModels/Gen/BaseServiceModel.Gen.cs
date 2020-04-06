using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Global;
using System.Reflection;
using DataService.Models.Gen;

namespace DataService.ServiceModels
{
	public partial interface IServiceModel:IGetting
	{
		void CopyFrom(object src);
		void CopyTo(object dest);
		ET To<ET>();
	}
	
	public partial interface IBaseServiceModel<E>: IServiceModel
	{
		void FromEntity(E entity);
		E ToEntity();
	}
	
	public abstract partial class BaseServiceModel<E>: IBaseServiceModel<E>
	{
		public BaseServiceModel()
		{
		}
		
		public BaseServiceModel(E entity)
		{
			FromEntity(entity);
		}
		
		protected E Entity { get; set; }
		public int Id { get ; set ; }

		public virtual void FromEntity(E entity)
		{
			Entity = entity;
			G.Mapper.Map(entity, this);
		}
		
		public virtual void CopyFrom(object src)
		{
			G.Mapper.Map(src, this);
		}
		
		public virtual void CopyTo(object dest)
		{
			G.Mapper.Map(this, dest);
		}
		
		public virtual ET To<ET>()
		{
			return G.Mapper.Map<ET>(this);
		}
		
		public virtual E ToEntity()
		{
			if (Entity!=null)
				return Entity;
			return G.Mapper.Map<E>(this);
		}
		
		public virtual E ToEntity(bool copyToEntity)
		{
			if (Entity!=null)
			{
				if (copyToEntity) CopyTo(Entity);
				return Entity;
			}
			return G.Mapper.Map<E>(this);
		}
		
	}
	
	public abstract partial class BaseUpdateServiceModel<VM, Entity>
	{
		public void PatchTo(Entity dest)
		{
			foreach (var map in vPropMappings)
			{
				var srcProp = map.Value;
				var srcVal = srcProp.GetValue(this);
				if (srcVal != null)
				{
					var destProp = ePropMappings[map.Key];
					destProp.SetValue(dest, (srcVal as IWrapper).GetValue());
				}
			}
		}
		
		protected static IDictionary<string, PropertyInfo> vPropMappings; // ServiceModel
		
		protected static IDictionary<string, PropertyInfo> ePropMappings; // entity
		
		static BaseUpdateServiceModel()
		{
			var entityType = typeof(Entity);
			var Type = typeof(VM);
			vPropMappings = new Dictionary<string, PropertyInfo>();
			ePropMappings = new Dictionary<string, PropertyInfo>();
			var props = entityType.GetProperties();
			foreach (var p in props)
			{
				ePropMappings[p.Name] = p;
			}
			props = Type.GetProperties();
			foreach (var p in props)
			{
				if (ePropMappings.ContainsKey(p.Name))
					vPropMappings[p.Name] = p;
			}
		}
		
	}
	
}
