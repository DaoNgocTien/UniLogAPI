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
	public partial interface IApplicationRepository : IBaseRepository<Application, int>
	{
		Application FindActiveById(int key);
		Task<Application> FindActiveByIdAsync(int key);
		//IQueryable<Application> GetActive();
		//IQueryable<Application> GetActive(Expression<Func<Application, bool>> expr);
	}
	
	public partial class ApplicationRepository : BaseRepository<Application, int>, IApplicationRepository
	{
		public ApplicationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override Application FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Application> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public Application FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<Application> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}

		public override IQueryable<Application> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<Application> GetActive(Expression<Func<Application, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
