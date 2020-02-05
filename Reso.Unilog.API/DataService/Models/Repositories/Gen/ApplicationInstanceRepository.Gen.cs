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
	public partial interface IApplicationInstanceRepository : IBaseRepository<ApplicationInstance, int>
	{
		ApplicationInstance FindActiveById(int key);
		Task<ApplicationInstance> FindActiveByIdAsync(int key);
		//IQueryable<ApplicationInstance> GetActive();
		//IQueryable<ApplicationInstance> GetActive(Expression<Func<ApplicationInstance, bool>> expr);
	}
	
	public partial class ApplicationInstanceRepository : BaseRepository<ApplicationInstance, int>, IApplicationInstanceRepository
	{
		public ApplicationInstanceRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override ApplicationInstance FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ApplicationInstance> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public ApplicationInstance FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<ApplicationInstance> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}

		public override IQueryable<ApplicationInstance> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<ApplicationInstance> GetActive(Expression<Func<ApplicationInstance, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
