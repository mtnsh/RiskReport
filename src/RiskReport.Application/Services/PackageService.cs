using FluentValidation;
using RiskReport.Application.Models;
using RiskReport.Application.Repositories;

namespace RiskReport.Application.Services;

public class PackageService : IPackageService
{
    private readonly IPackageRepository _packageRepository;
    private readonly IValidator<Package> _packageValidator;

    public PackageService(IPackageRepository packageRepository, IValidator<Package> packageValidator)
    {
        _packageRepository = packageRepository;
        _packageValidator = packageValidator;
    }

    public Task<bool> CreatePackageAsync(Package package)
    {
        _packageValidator.ValidateAndThrow(package);
        return _packageRepository.CreatePackageAsync(package);
    }

    public Task<Package?> GetPackageAsync(string packageManager, string packageName)
    {
        return _packageRepository.GetPackageAsync(packageManager, packageName);
    }
}