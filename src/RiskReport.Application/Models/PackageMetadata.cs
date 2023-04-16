using System.Text.Json.Serialization;

namespace RiskReport.Application.Models;

public class PackageMetadata
{
    [JsonPropertyName("packageId")]
    public string PackageId { get; set; }

    [JsonPropertyName("type")]
    public string PackageManager { get; set; }

    [JsonPropertyName("name")]
    public string PackageName { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("releaseDate")]
    public DateTime ReleaseDate { get; set; }
}