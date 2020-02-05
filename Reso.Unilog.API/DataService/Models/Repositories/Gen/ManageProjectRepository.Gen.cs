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
	public partial interface IManageProjectRepository : IBaseRepository<ManageProject, int>
	{
	}
	
	public partial class ManageProjectRepository : BaseRepository<ManageProject, int>, IManageProjectRepository
	{
		public ManageProjectRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override ManageProject FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ManageProject> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
