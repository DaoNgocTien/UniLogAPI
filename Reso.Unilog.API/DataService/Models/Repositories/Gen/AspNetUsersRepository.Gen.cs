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
	public partial interface IAspNetUsersRepository : IBaseRepository<AspNetUsers, int>
	{
	}
	
	public partial class AspNetUsersRepository : BaseRepository<AspNetUsers, int>, IAspNetUsersRepository
	{
		public AspNetUsersRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override AspNetUsers FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUsers> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
