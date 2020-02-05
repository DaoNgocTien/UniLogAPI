using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.ServiceModels;
using DataService.Models;
using DataService.Global;

namespace DataService.Models
{
	public partial class ApplicationInstance : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class ApplicationInstanceExtension
	{
		public static ApplicationInstance Id(this IQueryable<ApplicationInstance> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static ApplicationInstance Id(this IEnumerable<ApplicationInstance> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<ApplicationInstance> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<ApplicationInstance> Active(this IQueryable<ApplicationInstance> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<ApplicationInstance> NotActive(this IQueryable<ApplicationInstance> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<ApplicationInstance> Active(this IEnumerable<ApplicationInstance> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<ApplicationInstance> NotActive(this IEnumerable<ApplicationInstance> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
