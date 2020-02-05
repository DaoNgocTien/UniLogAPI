using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataService.Models;
using DataService.Models.Repositories;
using DataService.ServiceModels;
using Microsoft.Extensions.DependencyInjection;

namespace DataService.Global
{
	public static partial class G
	{
		public static IMapper Mapper { get; private set; }
		private static List<Action<IMapperConfigurationExpression>> MapperConfigs
			= new List<Action<IMapperConfigurationExpression>>();
		//{
			//cfg =>
			//{
			//	cfg.CreateMap<Account, AccountServiceModel>().ReverseMap();
			//	cfg.CreateMap<ActivityLog, ActivityLogServiceModel>().ReverseMap();
			//	cfg.CreateMap<Application, ApplicationServiceModel>().ReverseMap();
			//	cfg.CreateMap<ApplicationCharacteristic, ApplicationCharacteristicServiceModel>().ReverseMap();
			//	cfg.CreateMap<ApplicationInstance, ApplicationInstanceServiceModel>().ReverseMap();
			//	cfg.CreateMap<ApplicationRelation, ApplicationRelationServiceModel>().ReverseMap();
			//	cfg.CreateMap<AspNetRoles, AspNetRolesServiceModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserLogins, AspNetUserLoginsServiceModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserRoles, AspNetUserRolesServiceModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUserTokens, AspNetUserTokensServiceModel>().ReverseMap();
			//	cfg.CreateMap<AspNetUsers, AspNetUsersServiceModel>().ReverseMap();
			//	cfg.CreateMap<ErrorCode, ErrorCodeServiceModel>().ReverseMap();
			//	cfg.CreateMap<Log, LogServiceModel>().ReverseMap();
			//	cfg.CreateMap<ManageProject, ManageProjectServiceModel>().ReverseMap();
			//	cfg.CreateMap<Repo, RepoServiceModel>().ReverseMap();
			//	cfg.CreateMap<Server, ServerServiceModel>().ReverseMap();
			//	cfg.CreateMap<ServerAccount, ServerAccountServiceModel>().ReverseMap();
			//	cfg.CreateMap<ServerDetail, ServerDetailServiceModel>().ReverseMap();
			//	cfg.CreateMap<Systems, SystemsServiceModel>().ReverseMap();
			//	AutoMapper.Mapper.Initialize(cfg as MapperConfigurationExpression);
		//	}
		//};
		private static void ConfigureAutomapper()
		{
			//AutoMapper
			var mapConfig = new MapperConfiguration(cfg =>
			{
				foreach (var c in MapperConfigs)
				{
					c.Invoke(cfg);
				}
			});
			G.Mapper = mapConfig.CreateMapper();
			
		}
		
		private static void ConfigureIoC(IServiceCollection services)
		{
			//IoC
			services.AddScoped<UnitOfWork>()
				.AddScoped<IUnitOfWork, UnitOfWork>()
				.AddScoped<UnilogDevContext, UnitOfWork>()
				.AddScoped<DbContext, UnitOfWork>()
				.AddScoped<IAccountRepository, AccountRepository>()
				.AddScoped<IActivityLogRepository, ActivityLogRepository>()
				.AddScoped<IApplicationRepository, ApplicationRepository>()
				.AddScoped<IApplicationCharacteristicRepository, ApplicationCharacteristicRepository>()
				.AddScoped<IApplicationInstanceRepository, ApplicationInstanceRepository>()
				.AddScoped<IApplicationRelationRepository, ApplicationRelationRepository>()
				.AddScoped<IAspNetRolesRepository, AspNetRolesRepository>()
				.AddScoped<IAspNetUserLoginsRepository, AspNetUserLoginsRepository>()
				.AddScoped<IAspNetUserRolesRepository, AspNetUserRolesRepository>()
				.AddScoped<IAspNetUserTokensRepository, AspNetUserTokensRepository>()
				.AddScoped<IAspNetUsersRepository, AspNetUsersRepository>()
				.AddScoped<IErrorCodeRepository, ErrorCodeRepository>()
				.AddScoped<ILogRepository, LogRepository>()
				.AddScoped<IManageProjectRepository, ManageProjectRepository>()
				.AddScoped<IRepoRepository, RepoRepository>()
				.AddScoped<IServerRepository, ServerRepository>()
				.AddScoped<IServerAccountRepository, ServerAccountRepository>()
				.AddScoped<IServerDetailRepository, ServerDetailRepository>()
				.AddScoped<ISystemsRepository, SystemsRepository>();
		}
		
	}
}
