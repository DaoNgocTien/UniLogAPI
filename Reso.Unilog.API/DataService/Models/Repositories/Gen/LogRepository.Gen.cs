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
	public partial interface ILogRepository : IBaseRepository<Log, int>
	{
		Log FindActiveById(int key);
		Task<Log> FindActiveByIdAsync(int key);
		//IQueryable<Log> GetActive();
		//IQueryable<Log> GetActive(Expression<Func<Log, bool>> expr);
	}
	
	public partial class LogRepository : BaseRepository<Log, int>, ILogRepository
	{
		public LogRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override Log FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Log> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public Log FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<Log> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}

		public override IQueryable<Log> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<Log> GetActive(Expression<Func<Log, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
