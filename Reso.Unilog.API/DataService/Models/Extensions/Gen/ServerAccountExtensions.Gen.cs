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
	public partial class ServerAccount : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class ServerAccountExtension
	{
		public static ServerAccount Id(this IQueryable<ServerAccount> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static ServerAccount Id(this IEnumerable<ServerAccount> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<ServerAccount> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<ServerAccount> Active(this IQueryable<ServerAccount> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<ServerAccount> NotActive(this IQueryable<ServerAccount> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<ServerAccount> Active(this IEnumerable<ServerAccount> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<ServerAccount> NotActive(this IEnumerable<ServerAccount> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
