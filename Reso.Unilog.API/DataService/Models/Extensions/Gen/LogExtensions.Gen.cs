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
	public partial class Log : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class LogExtension
	{
		public static Log Id(this IQueryable<Log> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Log Id(this IEnumerable<Log> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Log> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<Log> Active(this IQueryable<Log> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Log> NotActive(this IQueryable<Log> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Log> Active(this IEnumerable<Log> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Log> NotActive(this IEnumerable<Log> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
