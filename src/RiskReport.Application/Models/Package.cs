namespace RiskReport.Application.Models;

public class Package
{
    public required string PackageManager { get; init; }
    public required string PackageName { get; init; }
    public required List<string> PackageVersions { get; init; } = new();
}