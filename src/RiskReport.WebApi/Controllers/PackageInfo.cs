using Microsoft.AspNetCore.Mvc;
using RiskReport.Application.Services;
using RiskReport.Contracts.Requests;

namespace RiskReport.WebApi.Controllers;
/// <summary>
/// This controller is not a requirement, it is only for debug purposes or as a developer service for my convenience.
/// </summary>
[ApiController]
public class PackageInfo : ControllerBase
{
    private readonly IPackageInfoService _packageInfoService;

    public PackageInfo(IPackageInfoService packageInfoService)
    {
        _packageInfoService = packageInfoService;
    }

    [HttpGet(Endpoints.PackageInfo.Get)]
    public async Task<IActionResult> GetPackageInfo(string packageManager, string packageName, string packageVersion)
    {
        var packageInfo = await _packageInfoService.GetPackageInfoAsync(packageManager, packageName, packageVersion);
        return Ok(packageInfo);
    }

    [HttpPost(Endpoints.PackageInfo.GetVulnerabilities)]
    public async Task<IActionResult> GetPackageVulnerabilities([FromBody] PackageVulnerabilityRequest request)
    {
        var vulnerabilities = await _packageInfoService.GetPackageVulnerabilitiesAsync(request);
        return Ok(vulnerabilities);
    }
}