namespace RiskReport.Contracts.Responses;

public class PublishPackageResponse
{
    public required string PackageManager { get; init; }
    public required string PackageName { get; init; }
    public required IEnumerable<string> PackageVersions { get; init; } = Enumerable.Empty<string>();
}