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
	public partial interface IApplicationCharacteristicRepository : IBaseRepository<ApplicationCharacteristic, int>
	{
		ApplicationCharacteristic FindActiveById(int key);
		Task<ApplicationCharacteristic> FindActiveByIdAsync(int key);
		//IQueryable<ApplicationCharacteristic> GetActive();
		//IQueryable<ApplicationCharacteristic> GetActive(Expression<Func<ApplicationCharacteristic, bool>> expr);
	}
	
	public partial class ApplicationCharacteristicRepository : BaseRepository<ApplicationCharacteristic, int>, IApplicationCharacteristicRepository
	{
		public ApplicationCharacteristicRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override ApplicationCharacteristic FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ApplicationCharacteristic> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public ApplicationCharacteristic FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active == true);
			return entity;
		}
		
		public async Task<ApplicationCharacteristic> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active == true);
			return entity;
		}

		public override IQueryable<ApplicationCharacteristic> GetActive()
		{
			return dbSet.Where(e => e.Active == true);
		}

		public override IQueryable<ApplicationCharacteristic> GetActive(Expression<Func<ApplicationCharacteristic, bool>> expr)
		{
			return dbSet.Where(e => e.Active == true).Where(expr);
		}
		
		#endregion
	}
}
