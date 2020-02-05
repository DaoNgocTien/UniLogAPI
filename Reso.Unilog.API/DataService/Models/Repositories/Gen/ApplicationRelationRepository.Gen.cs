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
	public partial interface IApplicationRelationRepository : IBaseRepository<ApplicationRelation, int>
	{
	}
	
	public partial class ApplicationRelationRepository : BaseRepository<ApplicationRelation, int>, IApplicationRelationRepository
	{
		public ApplicationRelationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD area
		public override ApplicationRelation FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ApplicationRelation> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		#endregion
	}
}
