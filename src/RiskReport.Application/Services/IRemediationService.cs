using RiskReport.Application.Models;

namespace RiskReport.Application.Services;

public interface IRemediationService
{
    Task<Remediation> GetRemediationAsync(string packageManager, string packageName, string packageVersion);
}