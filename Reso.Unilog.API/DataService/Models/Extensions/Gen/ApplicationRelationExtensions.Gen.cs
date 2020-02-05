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
	public partial class ApplicationRelation : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class ApplicationRelationExtension
	{
		public static ApplicationRelation Id(this IQueryable<ApplicationRelation> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static ApplicationRelation Id(this IEnumerable<ApplicationRelation> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<ApplicationRelation> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
	}
}
