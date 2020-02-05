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
	public partial class ServerDetail : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class ServerDetailExtension
	{
		public static ServerDetail Id(this IQueryable<ServerDetail> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static ServerDetail Id(this IEnumerable<ServerDetail> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<ServerDetail> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<ServerDetail> Active(this IQueryable<ServerDetail> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<ServerDetail> NotActive(this IQueryable<ServerDetail> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<ServerDetail> Active(this IEnumerable<ServerDetail> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<ServerDetail> NotActive(this IEnumerable<ServerDetail> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
