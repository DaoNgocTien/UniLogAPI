using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Models.Repositories;
using DataService.ServiceModels;
using DataService.Models;
using DataService.Global;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataService.Models.Domains
{
	public abstract partial class BaseDomain
	{
		public BaseDomain(IUnitOfWork uow)
		{
			this.uow = uow;
			this.context = uow.Context;
		}
		
		protected IUnitOfWork uow;
		
		protected DbContext context;
		
		public IUnitOfWork UoW { get { return uow; } }
		
		public DbContext Context { get { return context; } }
		
	}
}
