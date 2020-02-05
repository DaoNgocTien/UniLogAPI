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
	public partial class Application : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class ApplicationExtension
	{
		public static Application Id(this IQueryable<Application> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Application Id(this IEnumerable<Application> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Application> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<Application> Active(this IQueryable<Application> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Application> NotActive(this IQueryable<Application> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Application> Active(this IEnumerable<Application> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Application> NotActive(this IEnumerable<Application> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
