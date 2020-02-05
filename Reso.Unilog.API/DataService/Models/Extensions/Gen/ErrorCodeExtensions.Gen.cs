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
	public partial class ErrorCode : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class ErrorCodeExtension
	{
		public static ErrorCode Id(this IQueryable<ErrorCode> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static ErrorCode Id(this IEnumerable<ErrorCode> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<ErrorCode> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<ErrorCode> Active(this IQueryable<ErrorCode> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<ErrorCode> NotActive(this IQueryable<ErrorCode> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<ErrorCode> Active(this IEnumerable<ErrorCode> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<ErrorCode> NotActive(this IEnumerable<ErrorCode> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
