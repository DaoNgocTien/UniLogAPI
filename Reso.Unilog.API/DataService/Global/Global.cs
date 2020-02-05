using AutoMapper.Configuration;
using DataService.Models;
using DataService.RequestModels;
using DataService.RequestModels.CreateRequestModels;
using DataService.ServiceModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Global
{
    public partial class G
    {
        public static void Configure(IServiceCollection services)
        {
            G.MapperConfigs.Add(cfg =>
            {
                cfg.CreateMap<Account, AccountServiceModel>().ReverseMap();
                cfg.CreateMap<Account, CreateRequestModel>().ReverseMap();
                cfg.CreateMap<Account, AccountCreateRequestModel>().ReverseMap();
                cfg.CreateMap<Account, AuthorizeRegisterModel>().ReverseMap();
                cfg.CreateMap<AuthorizeRegisterModel, AspNetUsersCreateRequestModel>().ReverseMap();

                cfg.CreateMap<ActivityLog, ActivityLogServiceModel>().ReverseMap();
                cfg.CreateMap<ActivityLog, ActivityLogCreateRequestModel>().ReverseMap();

                //cfg.CreateMap<Actor, ActorServiceModel>().ReverseMap();

                cfg.CreateMap<Application, ApplicationServiceModel>().ReverseMap();
                cfg.CreateMap<Application, ApplicationCreateRequestModel>().ReverseMap();

                cfg.CreateMap<ApplicationCharacteristic, ApplicationCharacteristicServiceModel>().ReverseMap();
                cfg.CreateMap<ApplicationCharacteristic, ApplicationCharacteristicCreateRequestModel>().ReverseMap();

                cfg.CreateMap<ApplicationRelation, ApplicationRelationServiceModel>().ReverseMap();

                cfg.CreateMap<ApplicationInstance, ApplicationInstanceServiceModel>().ReverseMap();
                cfg.CreateMap<ApplicationInstance, ApplicationInstanceCreateRequestModel>().ReverseMap();

                //cfg.CreateMap<ApplicationScreen, ApplicationScreenServiceModel>().ReverseMap();

                //cfg.CreateMap<AspNetRoleClaims, AspNetRoleClaimsServiceModel>().ReverseMap();

                cfg.CreateMap<AspNetRoles, AspNetRolesServiceModel>().ReverseMap();

                //cfg.CreateMap<AspNetUserClaims, AspNetUserClaimsServiceModel>().ReverseMap();

                //cfg.CreateMap<AspNetUserLogins, AspNetUserLoginsServiceModel>().ReverseMap();

                cfg.CreateMap<AspNetUserRoles, AspNetUserRolesServiceModel>().ReverseMap();

                cfg.CreateMap<AspNetUserTokens, AspNetUserTokensServiceModel>().ReverseMap();

                cfg.CreateMap<AspNetUsers, AspNetUsersServiceModel>().ReverseMap();
                cfg.CreateMap<AspNetUsers, AspNetUsersCreateRequestModel>().ReverseMap();
                cfg.CreateMap<AspNetUsers, CreateRequestModel>().ReverseMap();

                //cfg.CreateMap<Company, CompanyServiceModel>().ReverseMap();

                //cfg.CreateMap<Company, CompanyServiceModel>().ReverseMap();
                //cfg.CreateMap<Company, CompanyCreateRequestModel>().ReverseMap();

                //cfg.CreateMap<DevOps, DevOpsServiceModel>().ReverseMap();

                //cfg.CreateMap<DevOpsLog, DevOpsLogServiceModel>().ReverseMap();
                //cfg.CreateMap<DevOpsLog, DevOpsLogCreateRequestModel>().ReverseMap();

                //cfg.CreateMap<Ecf, EcfServiceModel>().ReverseMap();

                //cfg.CreateMap<EntityRelation, EntityRelationServiceModel>().ReverseMap();

                //cfg.CreateMap<EntityRelation, EntityRelationCreateRequestModel>().ReverseMap();
                //cfg.CreateMap<EntityRelation, EntityRelationUpdateRequestModel>().ReverseMap();

                cfg.CreateMap<ErrorCode, ErrorCodeServiceModel>().ReverseMap();

                cfg.CreateMap<Log, LogServiceModel>().ReverseMap();
                cfg.CreateMap<Log, LogCreateRequestModel>().ReverseMap();

                cfg.CreateMap<ManageProject, ManageProjectServiceModel>().ReverseMap();

                cfg.CreateMap<Repo, RepoServiceModel>().ReverseMap();
                cfg.CreateMap<Repo, RepoCreateRequestModel>().ReverseMap();


                //cfg.CreateMap<RoleActor, RoleActorServiceModel>().ReverseMap();

                cfg.CreateMap<Server, ServerServiceModel>().ReverseMap();
                cfg.CreateMap<Server, ServerCreateRequestModel>().ReverseMap();

                cfg.CreateMap<ServerAccount, ServerAccountServiceModel>().ReverseMap();

                cfg.CreateMap<ServerDetail, ServerDetailServiceModel>().ReverseMap();
                cfg.CreateMap<ServerDetail, ServerDetailCreateRequestModel>().ReverseMap();

                cfg.CreateMap<ServerAccount, ServerAccountCreateRequestModel>().ReverseMap();

                cfg.CreateMap<ServerDetail, ServerDetailServiceModel>().ReverseMap();

                //cfg.CreateMap<SystemInstance, SystemInstanceServiceModel>().ReverseMap();
                //cfg.CreateMap<SystemInstance, SystemInstanceCreateRequestModel>().ReverseMap();

                cfg.CreateMap<Systems, SystemsServiceModel>().ReverseMap();
                cfg.CreateMap<Systems, SystemCreateRequestModel>().ReverseMap();



                //cfg.CreateMap<Tcf, TcfServiceModel>().ReverseMap();

                //cfg.CreateMap<UseCase, UseCaseServiceModel>().ReverseMap();
                //cfg.CreateMap<UseCase, UseCaseCreateRequestModel>().ReverseMap();
                //cfg.CreateMap<UseCase, UseCaseUpdateRequestModel>().ReverseMap();

                //cfg.CreateMap<UseCaseActor, UseCaseActorServiceModel>().ReverseMap();
                //cfg.CreateMap<UseCaseActor, UseCaseActorCreateRequestModel>().ReverseMap();

                //cfg.CreateMap<UseCaseEntity, UseCaseEntityServiceModel>().ReverseMap();
                //cfg.CreateMap<UseCaseEntity, UseCaseEntityCreateRequestModel>().ReverseMap();

                //cfg.CreateMap<UseCaseStep, UseCaseStepServiceModel>().ReverseMap();
                //cfg.CreateMap<UseCaseStep, UseCaseStepCreateRequestModel>().ReverseMap();
                //cfg.CreateMap<UseCaseStep, UseCaseStepUpdateRequestModel>().ReverseMap();

                AutoMapper.Mapper.Initialize(cfg as MapperConfigurationExpression);
            });
            G.ConfigureAutomapper();
            G.ConfigureIoC(services);
        }
    }
}
