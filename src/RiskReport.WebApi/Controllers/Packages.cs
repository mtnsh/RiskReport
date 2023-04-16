using Microsoft.AspNetCore.Mvc;
using RiskReport.Application.Services;
using RiskReport.Contracts.Requests;
using RiskReport.WebApi.Mappings;

namespace RiskReport.WebApi.Controllers;

[ApiController]
public class Packages : ControllerBase
{
    private readonly IPackageService _packageService;

    public Packages(IPackageService packageService)
    {
        _packageService = packageService;
    }

    [HttpPost(Endpoints.Packages.Create)]
    public async Task<IActionResult> Create([FromBody] PublishPackageRequest request)
    {
        var package = request.MapToPackage();

        await _packageService.CreatePackageAsync(package);

        var response = package.MapToResponse();

        return CreatedAtAction(nameof(Get),
            new { packageManager = response.PackageManager, packageName = response.PackageName }, response);
    }

    [HttpGet(Endpoints.Packages.Get)]
    public async Task<IActionResult> Get([FromRoute] string packageManager, [FromRoute] string packageName)
    {
        var package = await _packageService.GetPackageAsync(packageManager, packageName);
        if (package is null) return NotFound();
        var response = package.MapToResponse();
        return Ok(response);
    }
}