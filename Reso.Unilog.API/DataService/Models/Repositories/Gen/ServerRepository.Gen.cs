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
	public partial interface IServerRepository : IBaseRepository<Server, int>
	{
		Server FindActiveById(int key);
		Task<Server> FindActiveByIdAsync(int key);
		//IQueryable<Server> GetActive();
		//IQueryable<Server> GetActive(Expression<Func<Server, bool>> expr);
	}
	
	public partial class ServerRepository : BaseRepository<Server, int>, IServerRepository
	{
		public ServerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override Server FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Server> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public Server FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<Server> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}

		public override IQueryable<Server> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<Server> GetActive(Expression<Func<Server, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
