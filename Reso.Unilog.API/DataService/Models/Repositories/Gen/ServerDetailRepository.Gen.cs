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
	public partial interface IServerDetailRepository : IBaseRepository<ServerDetail, int>
	{
		ServerDetail FindActiveById(int key);
		Task<ServerDetail> FindActiveByIdAsync(int key);
		//IQueryable<ServerDetail> GetActive();
		//IQueryable<ServerDetail> GetActive(Expression<Func<ServerDetail, bool>> expr);
	}
	
	public partial class ServerDetailRepository : BaseRepository<ServerDetail, int>, IServerDetailRepository
	{
		public ServerDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override ServerDetail FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ServerDetail> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public ServerDetail FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<ServerDetail> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}

		public override IQueryable<ServerDetail> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<ServerDetail> GetActive(Expression<Func<ServerDetail, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
