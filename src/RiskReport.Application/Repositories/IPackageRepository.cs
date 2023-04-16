using RiskReport.Application.Models;

namespace RiskReport.Application.Repositories;

public interface IPackageRepository
{
    Task<bool> CreatePackageAsync(Package package);
    Task<Package?> GetPackageAsync(string packageManager, string packageName);

}