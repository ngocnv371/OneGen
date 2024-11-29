using Microsoft.EntityFrameworkCore;
using OneGen.Generation;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace OneGen.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class OneGenDbContext :
	AbpDbContext<OneGenDbContext>,
	ITenantManagementDbContext,
	IIdentityDbContext
{
	public DbSet<Subject> Subjects { get; set; }
	public DbSet<Variant> Variants { get; set; }
	public DbSet<Task> Tasks { get; set; }

	#region Entities from the modules

	/* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

	// Identity
	public DbSet<IdentityUser> Users { get; set; }

	public DbSet<IdentityRole> Roles { get; set; }
	public DbSet<IdentityClaimType> ClaimTypes { get; set; }
	public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
	public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
	public DbSet<IdentityLinkUser> LinkUsers { get; set; }
	public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
	public DbSet<IdentitySession> Sessions { get; set; }

	// Tenant Management
	public DbSet<Tenant> Tenants { get; set; }

	public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

	#endregion Entities from the modules

	public OneGenDbContext(DbContextOptions<OneGenDbContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		/* Include modules to your migration db context */

		builder.ConfigurePermissionManagement();
		builder.ConfigureSettingManagement();
		builder.ConfigureBackgroundJobs();
		builder.ConfigureAuditLogging();
		builder.ConfigureFeatureManagement();
		builder.ConfigureIdentity();
		builder.ConfigureOpenIddict();
		builder.ConfigureTenantManagement();
		builder.ConfigureBlobStoring();

		/* Configure your own tables/entities inside here */

		builder.Entity<Subject>(b =>
		{
			b.ToTable(OneGenConsts.DbTablePrefix + "Subjects", OneGenConsts.GenerationSchema);
			b.ConfigureByConvention();
		});
		builder.Entity<Task>(b =>
		{
			b.ToTable(OneGenConsts.DbTablePrefix + "Tasks", OneGenConsts.GenerationSchema);
			b.ConfigureByConvention();

			b.HasOne<Subject>().WithMany().HasForeignKey(u => u.SubjectId).IsRequired();
		});
		builder.Entity<Variant>(b =>
		{
			b.ToTable(OneGenConsts.DbTablePrefix + "Variants", OneGenConsts.GenerationSchema);
			b.ConfigureByConvention();

			b.HasOne<Task>().WithMany().HasForeignKey(u => u.TaskId).IsRequired();
		});
	}
}