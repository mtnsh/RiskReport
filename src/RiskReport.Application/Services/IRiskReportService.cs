using RiskReport.Application.Models;

namespace RiskReport.Application.Services;

public interface IRiskReportService
{
    Task<PackageRiskReport> GetRiskReportAsync(string packageManager, string packageName, string packageVersion);
}