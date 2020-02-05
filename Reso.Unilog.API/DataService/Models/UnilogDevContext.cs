using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataService.Models
{
    public partial class UnilogDevContext : DbContext
    {
        public UnilogDevContext()
        {
        }

        public UnilogDevContext(DbContextOptions<UnilogDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<ActivityLog> ActivityLog { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationCharacteristic> ApplicationCharacteristic { get; set; }
        public virtual DbSet<ApplicationInstance> ApplicationInstance { get; set; }
        public virtual DbSet<ApplicationRelation> ApplicationRelation { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ErrorCode> ErrorCode { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<ManageProject> ManageProject { get; set; }
        public virtual DbSet<Repo> Repo { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<ServerAccount> ServerAccount { get; set; }
        public virtual DbSet<ServerDetail> ServerDetail { get; set; }
        public virtual DbSet<Systems> Systems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost; Database=UniLogDev; Trusted_Connection = True;User Id=saisam;Password=Katie123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.AspNetUserId)
                    .HasName("UK_IpAspUser")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UK_Email")
                    .IsUnique();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.AspNetUser)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.AspNetUserId)
                    .HasConstraintName("FK_Account_AspNetUsers");
            });

            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.HasIndex(e => e.AppCode);

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Browser)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.BrowserVersion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Device)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Os)
                    .IsRequired()
                    .HasColumnName("OS")
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.AppCodeNavigation)
                    .WithMany(p => p.ActivityLog)
                    .HasPrincipalKey(p => p.AppCode)
                    .HasForeignKey(d => d.AppCode)
                    .HasConstraintName("FK_ActivityLog_ApplicationInstance");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SourceCodeUrl).IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Technologies).IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.HasOne(d => d.Systems)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.SystemsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Application_Systems");
            });

            modelBuilder.Entity<ApplicationCharacteristic>(entity =>
            {
                entity.HasIndex(e => e.ApplicationId)
                    .HasName("UQ_ApplicationId")
                    .IsUnique();

                entity.HasOne(d => d.Application)
                    .WithOne(p => p.ApplicationCharacteristic)
                    .HasForeignKey<ApplicationCharacteristic>(d => d.ApplicationId)
                    .HasConstraintName("FK_ApplicationCharacteristic_Application");
            });

            modelBuilder.Entity<ApplicationInstance>(entity =>
            {
                entity.HasIndex(e => e.AppCode)
                    .HasName("UQ__Applicat__29493F8624927208")
                    .IsUnique();

                entity.HasIndex(e => e.AppId);

                entity.HasIndex(e => e.UpdateTime)
                    .HasName("IX_ApplicationInstance");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigUrl).IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseUrl).IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.ApplicationInstance)
                    .HasForeignKey(d => d.AppId)
                    .HasConstraintName("FK_ApplicationInstance_Application");
            });

            modelBuilder.Entity<ApplicationRelation>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ApplicationRelationClient)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_ApplicationRelation_Application");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ApplicationRelationService)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_ApplicationRelation_Application1");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<ErrorCode>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.UpdateTime).HasColumnType("date");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasIndex(e => e.AppCode);

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LogDate).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.AppCodeNavigation)
                    .WithMany(p => p.Log)
                    .HasPrincipalKey(p => p.AppCode)
                    .HasForeignKey(d => d.AppCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Log_ApplicationInstance");

                entity.HasOne(d => d.ErrorCode)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.ErrorCodeId)
                    .HasConstraintName("FK_Log_ErrorCode");
            });

            modelBuilder.Entity<ManageProject>(entity =>
            {
                entity.HasIndex(e => e.SystemsId)
                    .HasName("IX_ApplicationAccountMapping_ApplicationId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ManageProject)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManageProject_Account");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ManageProject)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_ManageProject_Application");

                entity.HasOne(d => d.ApplicationInstance)
                    .WithMany(p => p.ManageProject)
                    .HasForeignKey(d => d.ApplicationInstanceId)
                    .HasConstraintName("FK_ManageProject_ApplicationInstance");

                entity.HasOne(d => d.Systems)
                    .WithMany(p => p.ManageProject)
                    .HasForeignKey(d => d.SystemsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManageProject_Systems1");
            });

            modelBuilder.Entity<Repo>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_RepoName")
                    .IsUnique();

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.RepoUrl).IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Repo)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_Application_Repo");

                entity.HasOne(d => d.Server)
                    .WithMany(p => p.Repo)
                    .HasForeignKey(d => d.ServerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Server_Repo");
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_ServerName")
                    .IsUnique();

                entity.HasIndex(e => e.ServerCode)
                    .HasName("UK_ServerCode")
                    .IsUnique();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ExpiredDate).HasColumnType("date");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ServerCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ServerUrl).IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.HasOne(d => d.ServerMasterNavigation)
                    .WithMany(p => p.InverseServerMasterNavigation)
                    .HasForeignKey(d => d.ServerMaster)
                    .HasConstraintName("FK_Server_ServerMaster");
            });

            modelBuilder.Entity<ServerAccount>(entity =>
            {
                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.Owner).IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Server)
                    .WithMany(p => p.ServerAccount)
                    .HasForeignKey(d => d.ServerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Server_ServerAccount");
            });

            modelBuilder.Entity<ServerDetail>(entity =>
            {
                entity.HasIndex(e => e.ServerId)
                    .HasName("IX_ServerDetail")
                    .IsUnique();

                entity.Property(e => e.Disk1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Disk2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Disk3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.VolumeDisk1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VolumeDisk2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VolumeDisk3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Server)
                    .WithOne(p => p.ServerDetail)
                    .HasForeignKey<ServerDetail>(d => d.ServerId)
                    .HasConstraintName("FK_ServerDetail_Server");
            });

            modelBuilder.Entity<Systems>(entity =>
            {
                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("date");
            });
        }
    }
}
