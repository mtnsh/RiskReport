using RiskReport.Application.Models;

namespace RiskReport.Application.Services;

public interface IPackageService
{
    Task<bool> CreatePackageAsync(Package package);
    Task<Package?> GetPackageAsync(string packageManager, string packageName);
}