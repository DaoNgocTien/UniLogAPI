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
	public partial interface IAccountRepository : IBaseRepository<Account, int>
	{
		Account FindActiveById(int key);
		Task<Account> FindActiveByIdAsync(int key);
		//IQueryable<Account> GetActive();
		//IQueryable<Account> GetActive(Expression<Func<Account, bool>> expr);
	}
	
	public partial class AccountRepository : BaseRepository<Account, int>, IAccountRepository
	{
		public AccountRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override Account FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Account> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public Account FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<Account> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public override IQueryable<Account> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<Account> GetActive(Expression<Func<Account, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
