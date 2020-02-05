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
	public partial class AspNetUsers : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class AspNetUsersExtension
	{
		public static AspNetUsers Id(this IQueryable<AspNetUsers> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static AspNetUsers Id(this IEnumerable<AspNetUsers> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<AspNetUsers> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
