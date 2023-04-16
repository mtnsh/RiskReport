using Microsoft.AspNetCore.Mvc;
using RiskReport.Application.Services;
using RiskReport.WebApi.Mappings;

namespace RiskReport.WebApi.Controllers;

public class RiskReport:ControllerBase
{
    private readonly IRiskReportService _riskReportService;

    public RiskReport(IRiskReportService riskReportService)
    {
        _riskReportService = riskReportService;
    }

    [HttpGet(Endpoints.RiskReport.Get)]
    public async Task<IActionResult> Get([FromRoute] string packageManager, [FromRoute] string packageName, [FromRoute] string packageVersion)
    {
        var riskReport = await _riskReportService.GetRiskReportAsync(packageManager, packageName, packageVersion);
        return Ok(riskReport.MapToResponse());
    }
}