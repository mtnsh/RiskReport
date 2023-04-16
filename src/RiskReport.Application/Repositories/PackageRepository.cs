using RiskReport.Application.Models;
using System.Collections.Concurrent;

namespace RiskReport.Application.Repositories;

public class PackageRepository : IPackageRepository
{
    private readonly ConcurrentDictionary<string, Package> _packages;

    public PackageRepository()
    {
        _packages = new ConcurrentDictionary<string, Package>();
    }

    public async Task<bool> CreatePackageAsync(Package package)
    {
        return await Task.Run(() =>
        {
            if (package is null) return false;

            string key = $"{package.PackageManager}-{package.PackageName}";
            return _packages.TryAdd(key, package);
        });
    }

    public async Task<Package?> GetPackageAsync(string packageManager, string packageName)
    {
        return await Task.Run(() =>
        {
            string key = $"{packageManager}-{packageName}";
            return _packages.TryGetValue(key, out var package) ? package : null;
        });
    }
}