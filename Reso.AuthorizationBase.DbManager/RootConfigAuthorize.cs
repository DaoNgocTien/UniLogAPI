
using System;
using AutoMapper;
using Doitsu.Service.Core;
using Doitsu.Service.Core.AuthorizeBuilder;
using Doitsu.Service.Core.IdentitiesExtension;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reso.AuthorizationBase.DbManager.Identity;
using Reso.AuthorizationBase.DbManager.Identity.Context;

namespace Reso.AuthorizationBase.DBManager
{
    /// <summary>
    /// Is the api endpoint config to help build a web app fastly
    /// The core destination is: 
    /// + Config Identity with JWT
    /// + Config Main DB context
    /// + Config Service Dependency
    /// + Config Repo Dependency
    /// + Config Autmapper
    /// How to use:
    /// + Use should add to your config
    /// ++ Doitsu.Identity.DevDB key, value
    /// ++ Doitsu.Ecommerce.DevDB key, value
    /// </summary>
    public static class RootConfigAuthorize
    {

        public static void Entry(IServiceCollection services, IConfiguration configuration)
        {
            //Doitsu.Identity.DBConStr
            #region Main Database Config
            // Config identity db config
            services.AddDbContext<ResoIdentityDbContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("UniLogDB")));

            services.AddIdentity<ResoUserInt, IdentityRole<int>>()
                .AddEntityFrameworkStores<ResoIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped(typeof(DbContext), typeof(ResoIdentityDbContext));
            services.AddScoped(typeof(ResoUserIntManager));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            JWTBuilder.BuildJWTService(services);
            #endregion

            #region DI Config
           
            #endregion

            //#region Mapper Config
            //var autoMapperConfig = new MapperConfiguration(cfg => {
            //    cfg.CreateMissingTypeMaps = true;
            //});
            //IMapper mapper = autoMapperConfig.CreateMapper();
            //services.AddSingleton(mapper); 
            //#endregion
        }


        private static void ConfigAutoMapper(IMapperConfigurationExpression config)
        {
            config.CreateMissingTypeMaps = true;
            config.AllowNullDestinationValues = false;
        }
    }
    

}
