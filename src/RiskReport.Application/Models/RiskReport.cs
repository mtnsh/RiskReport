namespace RiskReport.Application.Models;

public class PackageRiskReport
{
    public string PackageId { get; init; }
    public string PackageManager { get; init; }
    public string PackageName { get; init; }
    public string Version { get; init; }
    public DateTime ReleaseDate { get; init; }
    public PackageVulnerability Vulnerabilities { get; set; }
    public Remediation Remediation { get; set; }
}