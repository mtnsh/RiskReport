namespace RiskReport.Contracts.Responses;

public class RiskReportResponse
{
    public string PackageId { get; init; }
    public string PackageManager { get; init; }
    public string PackageName { get; init; }
    public string Version { get; init; }
    public DateTime ReleaseDate { get; init; }
    public PackageVulnerabilityResponse Vulnerabilities { get; init; }
    public RemediationResponse Remediation { get; init; }
}