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
	public partial class AspNetRoles : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class AspNetRolesExtension
	{
		public static AspNetRoles Id(this IQueryable<AspNetRoles> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static AspNetRoles Id(this IEnumerable<AspNetRoles> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<AspNetRoles> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
