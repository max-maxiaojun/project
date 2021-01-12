using Abp.Modules;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using BackLog.Authorization.Roles;
using BackLog.Authorization.Users;
using BackLog.Configuration;
using BackLog.Email;
using BackLog.Localization;
using BackLog.MultiTenancy;
using BackLog.Timing;
using Castle.MicroKernel.Registration;

namespace BackLog
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class BackLogCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            BackLogLocalizationConfigurer.Configure(Configuration.Localization);

            Configuration.ReplaceService(typeof(IEmailSenderConfiguration), () =>
            {
                Configuration.IocManager.IocContainer.Register(
                    Component.For<IEmailSenderConfiguration, ISmtpEmailSenderConfiguration>()
                    .ImplementedBy<BackLogSmtpEmailSenderConfiguration>()
                    .LifestyleTransient()
                );
            });

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = BackLogConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BackLogCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
