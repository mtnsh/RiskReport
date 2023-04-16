using RiskReport.Contracts.Requests;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using RiskReport.Application.Models;

namespace RiskReport.Application.Services;
public class PackageInfoService : IPackageInfoService
{
    private readonly HttpClient _httpClient;

    public PackageInfoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PackageMetadata> GetPackageInfoAsync(string packageManager, string packageName, string packageVersion)
    {
        var url = $"https://api-sca.checkmarx.net/public/packages/{packageManager}/{packageName}/versions/{packageVersion}";
        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<PackageMetadata>(jsonString)!;
    }

    public async Task<PackageVulnerability> GetPackageVulnerabilitiesAsync(PackageVulnerabilityRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(new List<PackageVulnerabilityRequest> { request }), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://api-sca.checkmarx.net/public/vulnerabilities/packages", content);

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<List<ApiResponse>>(jsonResponse);

        return apiResponse.First().Vulnerabilities.FirstOrDefault();

    }

    public class ApiResponse
    {
        [JsonPropertyName("packageName")]
        public string PackageName { get; set; }

        [JsonPropertyName("packageManager")]
        public string PackageManager { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("vulnerabilities")]
        public List<PackageVulnerability> Vulnerabilities { get; set; }
    }

}