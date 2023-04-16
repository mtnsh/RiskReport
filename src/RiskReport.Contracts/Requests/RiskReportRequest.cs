namespace RiskReport.Contracts.Requests
{
    public class RiskReportRequest
    {
        public required string PackageManager { get; init; }
        public required string PackageName { get; init; }
        public required string PackageVersion { get; init; }
    }
}
