using DataService.Global;
using DataService.Models;
using DataService.Models.Repositories;
using DataService.Models.Services;
using DataService.RequestModels;
using DataService.ServiceModels;
using DataService.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

namespace UniLog.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(p => p.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
         
            #region Authorization Token
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IAuthorizeService, AuthorizeService>();
            #endregion

            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
            var conn = Configuration.GetConnectionString("myConnectionString");
            services.AddDbContext<UnilogDevContext>(options => options.UseSqlServer(conn));

            G.Configure(services);
            services.AddScoped<EmailConfiguration>();

            services.AddScoped<SystemService>();
            services.AddScoped<SystemsServiceModel>();
            services.AddScoped<SystemsRepository>();


            services.AddScoped<ApplicationCharacteristicService>();
            services.AddScoped<ApplicationCharacteristicServiceModel>();
            services.AddScoped<ApplicationCharacteristicRepository>();

            services.AddScoped<LogService>();
            services.AddScoped<LogServiceModel>();
            services.AddScoped<LogRepository>();

            services.AddScoped<AccountService>();
            services.AddScoped<AccountServiceModel>();
            services.AddScoped<AccountRepository>();

            services.AddScoped<AspNetUsersService>();
            services.AddScoped<AspNetUsersServiceModel>();
            services.AddScoped<AspNetUsersRepository>();
            services.AddScoped<AspNetUserTokensRepository>();
            services.AddScoped<AspNetUserRolesRepository>();

            services.AddScoped<AuthorizeLoginModel>();
            services.AddScoped<PasswordModel>();

            services.AddScoped<ActivityLogService>();
            services.AddScoped<ActivityLogServiceModel>();
            services.AddScoped<ActivityLogRepository>();

            //services.AddScoped<EcfServiceModel>();
            //services.AddScoped<EcfRepository>();


            //services.AddScoped<TcfServiceModel>();
            //services.AddScoped<TcfRepository>();


            //services.AddScoped<ActorService>();
            //services.AddScoped<ActorServiceModel>();
            //services.AddScoped<ActorRepository>();


            services.AddScoped<ApplicationService>();
            services.AddScoped<ApplicationServiceModel>();
            services.AddScoped<ApplicationRepository>();


            services.AddScoped<ApplicationInstanceService>();
            services.AddScoped<ApplicationInstanceServiceModel>();
            services.AddScoped<ApplicationInstanceRepository>();


            //services.AddScoped<DevOpsService>();
            //services.AddScoped<DevOpsServiceModel>();
            //services.AddScoped<DevOpsRepository>();

            //services.AddScoped<DevOpsLogService>();
            //services.AddScoped<DevOpsLogServiceModel>();
            //services.AddScoped<DevOpsLogRepository>();

            //services.AddScoped<CompanyRepository>();

            //services.AddScoped<ApplicationScreenService>();
            //services.AddScoped<ApplicationScreenServiceModel>();
            //services.AddScoped<ApplicationScreenRepository>();

            services.AddScoped<ServerService>();
            services.AddScoped<ServerServiceModel>();
            services.AddScoped<ServerRepository>();

            services.AddScoped<ServerDetailService>();
            services.AddScoped<ServerDetailServiceModel>();
            services.AddScoped<ServerDetailRepository>();

         //   services.AddScoped<UseCaseService>();
         //   services.AddScoped<UseCaseServiceModel>();
         //   services.AddScoped<UseCaseRepository>();



         ////   services.AddScoped<UseCaseStepService>();
         //   services.AddScoped<UseCaseStepServiceModel>();
         //   services.AddScoped<UseCaseStepRepository>();


         //   services.AddScoped<UseCaseStepServiceModel>();
         //   services.AddScoped<UseCaseStepRepository>();


            //services.AddScoped<UseCaseActorServiceModel>();
            //services.AddScoped<UseCaseActorRepository>();


            //services.AddScoped<UseCaseEntityServiceModel>();
            //services.AddScoped<UseCaseEntityRepository>();


            //services.AddScoped<EntityRelationService>();
            //services.AddScoped<EntityRelationServiceModel>();
            //services.AddScoped<EntityRelationRepository>();


            //services.AddScoped<SystemInstanceService>();
            //services.AddScoped<SystemInstanceServiceModel>();
            //services.AddScoped<SystemInstanceRepository>();


            //services.AddScoped<CompanyService>();
            //services.AddScoped<CompanyServiceModel>();
            //services.AddScoped<CompanyRepository>();


            services.AddScoped<RepoService>();
            services.AddScoped<RepoServiceModel>();
            services.AddScoped<RepoRepository>();



            services.AddScoped<ServerAccountService>();
            services.AddScoped<ServerAccountServiceModel>();
            services.AddScoped<ServerAccountRepository>();



            services.AddScoped<ServerService>();
            services.AddScoped<ServerServiceModel>();
            services.AddScoped<ServerRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "UniLog API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "Wisky Corporation Allright Reserve License",
                    Contact = new Contact
                    {
                        Name = "Tiến Đào",
                        Email = "dnt4863@gmail.com",
                        Url = "https://www.facebook.com/tiendaongoc.tdn"
                    },
                    //License = new License
                    //{
                    //    Name = "Use under LICX",
                    //    Url = "https://example.com/license"
                    //}
                });
                c.AddSecurityDefinition("oauth2", new ApiKeyScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = "header",
                    Name = "Authorization",
                    Type = "apiKey"
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseCors(builder => builder
                                               .AllowAnyOrigin()
                                               .AllowAnyMethod()
                                               .AllowAnyHeader()
                                               .AllowCredentials());
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
