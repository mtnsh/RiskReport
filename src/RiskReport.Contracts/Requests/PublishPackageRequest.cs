namespace RiskReport.Contracts.Requests;

public class PublishPackageRequest
{
    public required string PackageManager { get; init; }
    public required string PackageName { get; init; }
    public required IEnumerable<string> PackageVersions { get; init; } = Enumerable.Empty<string>();
}