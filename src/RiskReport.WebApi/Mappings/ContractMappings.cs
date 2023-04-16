using RiskReport.Application.Models;
using RiskReport.Contracts.Requests;
using RiskReport.Contracts.Responses;

namespace RiskReport.WebApi.Mappings;

public static class ContractMappings
{
    public static Package MapToPackage(this PublishPackageRequest request)
    {
        return new()
        {
            PackageManager = request.PackageManager,
            PackageName = request.PackageName,
            PackageVersions = request.PackageVersions.ToList()
        };
    }

    public static PublishPackageResponse MapToResponse(this Package package)
    {
        return new()
        {
            PackageManager = package.PackageManager,
            PackageName = package.PackageName,
            PackageVersions = package.PackageVersions
        };
    }

    public static RiskReportResponse MapToResponse(this PackageRiskReport report)
    {
        return new()
        {
            PackageManager = report.PackageManager,
            PackageName = report.PackageName,
            PackageId = report.PackageId,
            Version = report.Version,
            ReleaseDate = report.ReleaseDate,
            Vulnerabilities = report.Vulnerabilities?.MapToResponse() ?? null,
            Remediation = report.Remediation?.MapToResponse()
        };
    }

    public static RemediationResponse MapToResponse(this Remediation remediation)
    {
        return new()
        {
            FixVersion = remediation.FixVersion,
            RemediationStatus = remediation.RemediationStatus
        };
    }

    public static PackageVulnerabilityResponse MapToResponse(this PackageVulnerability vulnerability)
    {
        return new()
        {
            Cve = vulnerability.Cve,
            Description = vulnerability.Description,
            Cwe = vulnerability.Cwe,
            Severity = vulnerability.Severity,
            Published = vulnerability.Published
        };
    }
}