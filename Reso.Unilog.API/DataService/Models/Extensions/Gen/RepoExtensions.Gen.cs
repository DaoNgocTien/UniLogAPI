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
	public partial class Repo : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class RepoExtension
	{
		public static Repo Id(this IQueryable<Repo> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Repo Id(this IEnumerable<Repo> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Repo> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<Repo> Active(this IQueryable<Repo> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Repo> NotActive(this IQueryable<Repo> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Repo> Active(this IEnumerable<Repo> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Repo> NotActive(this IEnumerable<Repo> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
