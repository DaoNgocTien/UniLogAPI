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
	public partial class ApplicationCharacteristic : BaseEntity
	{
	}
	
}


namespace DataService.Models.Extensions
{
	public static partial class ApplicationCharacteristicExtension
	{
		public static ApplicationCharacteristic Id(this IQueryable<ApplicationCharacteristic> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static ApplicationCharacteristic Id(this IEnumerable<ApplicationCharacteristic> query, int key)
		{
			return query.FirstOrDefault(
				e => e.Id == key);
		}
		
		public static bool Existed(this IQueryable<ApplicationCharacteristic> query, int key)
		{
			return query.Any(
				e => e.Id == key);
		}
		
		public static IQueryable<ApplicationCharacteristic> Active(this IQueryable<ApplicationCharacteristic> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IQueryable<ApplicationCharacteristic> NotActive(this IQueryable<ApplicationCharacteristic> query)
		{
			return query.Where(e => e.Active == false);
		}
		
		public static IEnumerable<ApplicationCharacteristic> Active(this IEnumerable<ApplicationCharacteristic> query)
		{
			return query.Where(e => e.Active == true);
		}
		
		public static IEnumerable<ApplicationCharacteristic> NotActive(this IEnumerable<ApplicationCharacteristic> query)
		{
			return query.Where(e => e.Active == false);
		}
		
	}
}
