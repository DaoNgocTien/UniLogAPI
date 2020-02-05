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
	public partial interface ISystemsRepository : IBaseRepository<Systems, int>
	{
		Systems FindActiveById(int key);
		Task<Systems> FindActiveByIdAsync(int key);
		//IQueryable<Systems> GetActive();
		//IQueryable<Systems> GetActive(Expression<Func<Systems, bool>> expr);
	}
	
	public partial class SystemsRepository : BaseRepository<Systems, int>, ISystemsRepository
	{
		public SystemsRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override Systems FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Systems> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public Systems FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<Systems> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}

		public override IQueryable<Systems> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<Systems> GetActive(Expression<Func<Systems, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
