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
	public partial class Systems : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class SystemsExtension
	{
		public static Systems Id(this IQueryable<Systems> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Systems Id(this IEnumerable<Systems> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Systems> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<Systems> Active(this IQueryable<Systems> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Systems> NotActive(this IQueryable<Systems> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Systems> Active(this IEnumerable<Systems> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Systems> NotActive(this IEnumerable<Systems> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
