using System;
using Doitsu.Service.Core.IdentitiesExtension;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Reso.AuthorizationBase.DbManager.Identity.Context
{
    public class ResoIdentityDbContext : IdentityDbContext<ResoUserInt, IdentityRole<int>, int>
    {
        public ResoIdentityDbContext(DbContextOptions<ResoIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class ResoIdentityDbContextFactory : IDesignTimeDbContextFactory<ResoIdentityDbContext>
    {
        public ResoIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ResoIdentityDbContext>();
            optionsBuilder.UseSqlServer("Server=113.161.84.245,1444;Database=UniLogDev;Trusted_Connection=false;uid=sa;pwd=zaQ@1234;");
            return new ResoIdentityDbContext(optionsBuilder.Options);
        }
    }
}
