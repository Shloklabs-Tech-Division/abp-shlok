using System;
using System.Collections.Generic;
using System.Security.Claims;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.Authorization;
using Volo.Abp.AspNetCore.Mvc.GlobalFeatures;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.Localization.Resource;
using Volo.Abp.AspNetCore.Security.Claims;
using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.GlobalFeatures;
using Volo.Abp.Localization;
using Volo.Abp.MemoryDb;
using Volo.Abp.Modularity;
using Volo.Abp.TestApp;
using Volo.Abp.Threading;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.AspNetCore.Mvc;

[DependsOn(
    typeof(AbpAspNetCoreTestBaseModule),
    typeof(AbpMemoryDbTestModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule)
    )]
public class AbpAspNetCoreMvcTestModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(
                typeof(MvcTestResource),
                typeof(AbpAspNetCoreMvcTestModule).Assembly
            );
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        OneTimeRunner.Run(() =>
        {
            GlobalFeatureManager.Instance.Modules.GetOrAdd(AbpAspNetCoreMvcTestFeatures.ModuleName,
                () => new AbpAspNetCoreMvcTestFeatures(GlobalFeatureManager.Instance))
                .EnableAll();
        });

        context.Services.AddAuthentication(options =>
        {
            options.DefaultChallengeScheme = "Bearer";
            options.DefaultForbidScheme = "Cookie";
        }).AddCookie("Cookie").AddJwtBearer("Bearer", _ => { });

        context.Services.AddAuthorization(options =>
        {
            options.AddPolicy("MyClaimTestPolicy", policy =>
            {
                policy.RequireClaim("MyCustomClaimType", "42");
            });

            options.AddPolicy("TestPermission1_And_TestPermission2", policy =>
            {
                policy.Requirements.Add(new PermissionsRequirement(new []{"TestPermission1", "TestPermission2"}, requiresAll: true));
            });

            options.AddPolicy("TestPermission1_Or_TestPermission2", policy =>
            {
                policy.Requirements.Add(new PermissionsRequirement(new []{"TestPermission1", "TestPermission2"}, requiresAll: false));
            });
        });

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(TestAppModule).Assembly, opts =>
            {
                opts.UrlActionNameNormalizer = urlActionNameNormalizerContext =>
                    string.Equals(urlActionNameNormalizerContext.ActionNameInUrl, "phone", StringComparison.OrdinalIgnoreCase)
                        ? "phones"
                        : urlActionNameNormalizerContext.ActionNameInUrl;
            });
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpAspNetCoreMvcTestModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<MvcTestResource>("en")
                .AddBaseTypes(
                    typeof(AbpUiResource),
                    typeof(AbpValidationResource)
                ).AddVirtualJson("/Volo/Abp/AspNetCore/Mvc/Localization/Resource");

            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("el", "el", "Ελληνικά"));
        });

        Configure<RazorPagesOptions>(options =>
        {
            options.RootDirectory = "/Volo/Abp/AspNetCore/Mvc";
        });

        Configure<RazorViewEngineOptions>(options =>
        {
            options.ViewLocationFormats.Add("/Volo/Abp/AspNetCore/App/Views/{1}/{0}.cshtml");
        });

        Configure<AbpClaimsMapOptions>(options =>
        {
            options.Maps.Add("SerialNumber", () => ClaimTypes.SerialNumber);
            options.Maps.Add("DateOfBirth", () => ClaimTypes.DateOfBirth);
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseAbpRequestLocalization();
        app.UseAbpSecurityHeaders();
        app.UseRouting();
        app.UseMiddleware<FakeAuthenticationMiddleware>();
        app.UseAbpClaimsMap();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseAuditing();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints();
    }
}
