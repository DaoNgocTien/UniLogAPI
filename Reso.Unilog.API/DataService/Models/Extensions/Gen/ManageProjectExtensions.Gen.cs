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
	public partial class ManageProject : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class ManageProjectExtension
	{
		public static ManageProject Id(this IQueryable<ManageProject> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static ManageProject Id(this IEnumerable<ManageProject> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<ManageProject> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
