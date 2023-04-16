using RiskReport.Application.Models;
using RiskReport.Contracts.Requests;

namespace RiskReport.Application.Services
{
    public class RiskReportService : IRiskReportService
    {
        private readonly IPackageInfoService _packageInfoService;
        private readonly IRemediationService _remediationService;

        public RiskReportService(IPackageInfoService packageInfoService, IRemediationService remediationService)
        {
            _packageInfoService = packageInfoService;
            _remediationService = remediationService;
        }

        public async Task<PackageRiskReport> GetRiskReportAsync(string packageManager, string packageName, string packageVersion)
        {
            var packageMetadata = await _packageInfoService.GetPackageInfoAsync(packageManager, packageName, packageVersion);

            var vulnerabilities = await _packageInfoService.GetPackageVulnerabilitiesAsync(new PackageVulnerabilityRequest
            {
                PackageManager = packageManager,
                PackageName = packageName,
                Version = packageVersion
            });

            var remediation =
                await _remediationService.GetRemediationAsync(packageManager, packageName, packageVersion);

            return new PackageRiskReport
            {
                PackageId = packageMetadata.PackageId,
                PackageManager = packageMetadata.PackageManager,
                PackageName = packageMetadata.PackageName,
                Version = packageMetadata.Version,
                ReleaseDate = packageMetadata.ReleaseDate,
                Vulnerabilities = vulnerabilities,
                Remediation = remediation
            };
        }
    }
}
