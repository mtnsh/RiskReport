namespace RiskReport.Application.Services;

using Models;
using RiskReport.Contracts.Requests;
using System.Threading.Tasks;

public interface IPackageInfoService
{
    Task<PackageMetadata> GetPackageInfoAsync(string packageManager, string packageName, string packageVersion);
    Task<PackageVulnerability> GetPackageVulnerabilitiesAsync(PackageVulnerabilityRequest request);
}
