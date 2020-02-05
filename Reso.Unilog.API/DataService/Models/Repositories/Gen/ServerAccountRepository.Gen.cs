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
	public partial interface IServerAccountRepository : IBaseRepository<ServerAccount, int>
	{
		ServerAccount FindActiveById(int key);
		Task<ServerAccount> FindActiveByIdAsync(int key);
		//IQueryable<ServerAccount> GetActive();
		//IQueryable<ServerAccount> GetActive(Expression<Func<ServerAccount, bool>> expr);
	}
	
	public partial class ServerAccountRepository : BaseRepository<ServerAccount, int>, IServerAccountRepository
	{
		public ServerAccountRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override ServerAccount FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ServerAccount> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public ServerAccount FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<ServerAccount> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}

		public override IQueryable<ServerAccount> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<ServerAccount> GetActive(Expression<Func<ServerAccount, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
