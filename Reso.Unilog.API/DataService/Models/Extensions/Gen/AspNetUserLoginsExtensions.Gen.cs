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
	public partial class AspNetUserLogins : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class AspNetUserLoginsExtension
	{
		public static AspNetUserLogins Id(this IQueryable<AspNetUserLogins> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static AspNetUserLogins Id(this IEnumerable<AspNetUserLogins> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<AspNetUserLogins> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
