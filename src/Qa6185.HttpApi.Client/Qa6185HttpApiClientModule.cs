﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Abp.SettingManagement;
using Volo.Saas.Host;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Gdpr;

namespace Qa6185;

[DependsOn(
    typeof(Qa6185ApplicationContractsModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule),
    typeof(SaasHostHttpApiClientModule),
    typeof(AbpAuditLoggingHttpApiClientModule),
    typeof(AbpOpenIddictProHttpApiClientModule),
    typeof(AbpAccountAdminHttpApiClientModule),
    typeof(AbpAccountPublicHttpApiClientModule),
    typeof(LanguageManagementHttpApiClientModule),
    typeof(AbpGdprHttpApiClientModule),
    typeof(TextTemplateManagementHttpApiClientModule)
)]
public class Qa6185HttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(Qa6185ApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<Qa6185HttpApiClientModule>();
        });
    }
}
