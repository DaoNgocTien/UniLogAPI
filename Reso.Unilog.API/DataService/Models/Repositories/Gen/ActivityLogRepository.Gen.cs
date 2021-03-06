using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataService.Models.Repositories
{
	public partial interface IActivityLogRepository : IBaseRepository<ActivityLog, int>
	{
	}
	
	public partial class ActivityLogRepository : BaseRepository<ActivityLog, int>, IActivityLogRepository
	{
		public ActivityLogRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override ActivityLog FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ActivityLog> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
