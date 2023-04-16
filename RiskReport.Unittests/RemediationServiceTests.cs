using FakeItEasy;
using FluentAssertions;
using RiskReport.Application.Models;
using RiskReport.Application.Services;

namespace RiskReport.Unittests
{
    public class RemediationServiceTests
    {
        [Fact]
        public async Task GetRemediationAsync_PackageDoesNotExist_NoRemediationExists()
        {
            // Arrange
            var packageInfoService = A.Fake<IPackageInfoService>();
            var packageService = A.Fake<IPackageService>();

            A.CallTo(() => packageService.GetPackageAsync(A<string>._, A<string>._)).Returns(Task.FromResult<Package>(null));

            var remediationService = new RemediationService(packageInfoService, packageService);

            // Act
            var result = await remediationService.GetRemediationAsync("PackageManager", "PackageName", "1.0.0");

            // Assert
            result.RemediationStatus.Should().Be("NoRemediationExists");
            result.FixVersion.Should().BeEmpty();
        }
    }
}