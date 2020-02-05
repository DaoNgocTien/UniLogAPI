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
	public partial class Account : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class AccountExtension
	{
		public static Account Id(this IQueryable<Account> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static Account Id(this IEnumerable<Account> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<Account> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<Account> Active(this IQueryable<Account> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<Account> NotActive(this IQueryable<Account> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<Account> Active(this IEnumerable<Account> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<Account> NotActive(this IEnumerable<Account> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
