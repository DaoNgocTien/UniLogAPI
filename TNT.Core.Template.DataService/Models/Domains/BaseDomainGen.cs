﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.Models.Domains
{
    public class BaseDomainGen : FileGen
    {
        private ContextInfo Data { get; set; }
        public BaseDomainGen(ContextInfo dt)
        {
            Data = dt;
            Directive.Add(
                Data.ProjectName + ".Models.Repositories",
                Data.ProjectName + ".ServiceModels",
                Data.ContextNamespace,
                Data.ProjectName + ".Global",
                "Microsoft.EntityFrameworkCore",
                "System.Linq.Expressions");
            ResolveMapping["context"] = dt.ContextName;

            //GENERATE
            GenerateNamespace();
            GenerateBaseDomain();
            GenerateBaseDomainBody();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Data.ProjectName + ".Models.Domains";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate BaseDomain
        private ContainerGen BaseDomain { get; set; }
        private BodyGen BaseDomainBody { get; set; }
        public void GenerateBaseDomain()
        {
            BaseDomain = new ContainerGen();
            BaseDomain.Signature = "public abstract partial class BaseDomain";
            BaseDomainBody = BaseDomain.Body;

            NamespaceBody.Add(BaseDomain);
        }

        public void GenerateBaseDomainBody()
        {

            var c01 = new ContainerGen();
            c01.Signature = "public BaseDomain(DbContext context)";
            c01.Body.Add(new StatementGen(
                "this.context = context;"));

            var s1 = new StatementGen(
                "protected DbContext context;");

            var c1 = new ContainerGen();
            c1.Signature = "public BaseDomain(IUnitOfWork uow)";
            c1.Body.Add(new StatementGen(
                "this.uow = uow;",
                "this.context = uow.Context;"));

            var s2 = new StatementGen(
                "protected IUnitOfWork uow;");

            var s3 = new StatementGen("public IUnitOfWork UoW { get { return uow; } }");
            var s4 = new StatementGen("public DbContext Context { get { return context; } }");

            if (Data.DIContainer == DIContainer.TContainer)
                BaseDomainBody.Add(c01, new StatementGen(""));

            BaseDomainBody.Add(
                c1, new StatementGen(""),
                s2, new StatementGen(""),
                s1, new StatementGen(""),
                s3, new StatementGen(""),
                s4, new StatementGen("")
                );
        }

    }
}
