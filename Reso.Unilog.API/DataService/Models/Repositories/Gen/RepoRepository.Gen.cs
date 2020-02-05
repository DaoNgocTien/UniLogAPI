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
	public partial interface IRepoRepository : IBaseRepository<Repo, int>
	{
		Repo FindActiveById(int key);
		Task<Repo> FindActiveByIdAsync(int key);
		//IQueryable<Repo> GetActive();
		//IQueryable<Repo> GetActive(Expression<Func<Repo, bool>> expr);
	}
	
	public partial class RepoRepository : BaseRepository<Repo, int>, IRepoRepository
	{
		public RepoRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override Repo FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Repo> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public Repo FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<Repo> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}

		public override IQueryable<Repo> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<Repo> GetActive(Expression<Func<Repo, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
