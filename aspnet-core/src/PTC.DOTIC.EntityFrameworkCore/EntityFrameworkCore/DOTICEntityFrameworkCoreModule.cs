using Abp;
using Abp.Dependency;
using Abp.EntityFrameworkCore.Configuration;
using Abp.IdentityServer4;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using PTC.DOTIC.Configuration;
using PTC.DOTIC.EntityHistory;
using PTC.DOTIC.Migrations.Seed;

namespace PTC.DOTIC.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpZeroCoreEntityFrameworkCoreModule),
        typeof(DOTICCoreModule),
        typeof(AbpZeroCoreIdentityServerEntityFrameworkCoreModule)
        )]
    public class DOTICEntityFrameworkCoreModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<DOTICDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        DOTICDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        DOTICDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }

            // Uncomment below line to write change logs for the entities below:
            //Configuration.EntityHistory.Selectors.Add("DOTICEntities", EntityHistoryHelper.TrackedTypes);
            //Configuration.CustomConfigProviders.Add(new EntityHistoryConfigProvider(Configuration));
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DOTICEntityFrameworkCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            var configurationAccessor = IocManager.Resolve<IAppConfigurationAccessor>();

            using (var scope = IocManager.CreateScope())
            {
                if (!SkipDbSeed && scope.Resolve<DatabaseCheckHelper>().Exist(configurationAccessor.Configuration["ConnectionStrings:Default"]))
                {
                    SeedHelper.SeedHostDb(IocManager);
                }
            }
        }
    }
}
