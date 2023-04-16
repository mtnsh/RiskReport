using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RiskReport.Application.Repositories;
using RiskReport.Application.Services;


namespace RiskReport.Application;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IPackageRepository, PackageRepository>();
        services.AddScoped<IPackageService, PackageService>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
        services.AddHttpClient<IPackageInfoService, PackageInfoService>();
        services.AddScoped<IPackageInfoService, PackageInfoService>();
        services.AddScoped<IRiskReportService, RiskReportService>();
        services.AddScoped<IRemediationService, RemediationService>();

        return services;
    }
}