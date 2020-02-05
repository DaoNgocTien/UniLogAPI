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
	public partial interface IErrorCodeRepository : IBaseRepository<ErrorCode, int>
	{
		ErrorCode FindActiveById(int key);
		Task<ErrorCode> FindActiveByIdAsync(int key);
		//IQueryable<ErrorCode> GetActive();
		//IQueryable<ErrorCode> GetActive(Expression<Func<ErrorCode, bool>> expr);
	}
	
	public partial class ErrorCodeRepository : BaseRepository<ErrorCode, int>, IErrorCodeRepository
	{
		public ErrorCodeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override ErrorCode FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ErrorCode> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public ErrorCode FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<ErrorCode> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}

		public override IQueryable<ErrorCode> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<ErrorCode> GetActive(Expression<Func<ErrorCode, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
