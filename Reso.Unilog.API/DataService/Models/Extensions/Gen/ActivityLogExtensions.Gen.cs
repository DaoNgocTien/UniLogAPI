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
	public partial class ActivityLog : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class ActivityLogExtension
	{
		public static ActivityLog Id(this IQueryable<ActivityLog> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static ActivityLog Id(this IEnumerable<ActivityLog> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<ActivityLog> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
