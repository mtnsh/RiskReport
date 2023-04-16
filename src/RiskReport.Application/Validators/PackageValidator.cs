using System.Collections.Immutable;
using System.Text.RegularExpressions;
using FluentValidation;
using RiskReport.Application.Models;

namespace RiskReport.Application.Validators;

public class PackageValidator : AbstractValidator<Package>
{
    private static readonly ImmutableArray<string> ValidPackageTypes = ImmutableArray.Create(
        "Python", "Npm", "Nuget", "Maven", "Ios", "Php", "Ios", "Go", "Cpp", "Ruby"
    );

    private static readonly string SemVerPattern = @"^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$";
    private static readonly Regex SemVerRegex = new(SemVerPattern);


    public PackageValidator()
    {
        RuleFor(p => p.PackageManager)
            .NotEmpty()
            .Must(type => ValidPackageTypes.Contains(type))
            .WithMessage($"Invalid package type. Valid types are: {string.Join(", ", ValidPackageTypes)}");

        RuleFor(p => p.PackageName)
            .NotEmpty()
            .WithMessage("Package name cannot be empty");

        RuleForEach(p => p.PackageVersions)
            .NotEmpty()
            .Must(version => SemVerRegex.IsMatch(version))
            .WithMessage("Invalid package version. Version must be in SemVer format.");
    }
}