using RiskReport.Application.Models;
using RiskReport.Contracts.Requests;
using Semver;

namespace RiskReport.Application.Services;

public class RemediationService : IRemediationService
{
    private readonly IPackageInfoService _packageInfoService;
    private readonly IPackageService _packageService;

    public RemediationService(IPackageInfoService packageInfoService, IPackageService packageService)
    {
        _packageInfoService = packageInfoService;
        _packageService = packageService;
    }

    public async Task<Remediation> GetRemediationAsync(string packageManager, string packageName, string packageVersion)
    {
        var remediation = new Remediation() { FixVersion = String.Empty, RemediationStatus = "NoRemediationExists" };

        var package = await _packageService.GetPackageAsync(packageManager, packageName);

        if (package == null)
        {
            return remediation;
        }

        var currentVersion = SemVersion.Parse(packageVersion, SemVersionStyles.Any);
        var higherVersions = package.PackageVersions
            .Select(version =>
            {
                SemVersion.TryParse(version,SemVersionStyles.Any, out var semVersion);
                return semVersion;
            })
            .Where(v => v > currentVersion)
            .ToList();

        foreach (var version in higherVersions)
        {
            var vulnerability = await _packageInfoService.GetPackageVulnerabilitiesAsync(new PackageVulnerabilityRequest
            {
                PackageManager = packageManager,
                PackageName = packageName,
                Version = version.ToString()
            });

            if (vulnerability is null)
            {
                remediation.RemediationStatus = "Remediated";
                remediation.FixVersion = version.ToString();
                break;
            }
        }

        return remediation;
    }
}