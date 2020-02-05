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
	public partial class Server : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class ServerExtension
	{
		public static Server Id(this IQueryable<Server> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Server Id(this IEnumerable<Server> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Server> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<Server> Active(this IQueryable<Server> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Server> NotActive(this IQueryable<Server> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Server> Active(this IEnumerable<Server> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Server> NotActive(this IEnumerable<Server> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
