namespace RiskReport.WebApi;

public static class Endpoints
{
    private const string ApiBase = "api";

    public static class Packages
    {
        private const string Base = $"{ApiBase}/packages";
        public const string Create = Base;
        public const string Get = Base + "/{packageManager}/{packageName}";
    }

    public static class RiskReport
    {
        private const string Base = $"{ApiBase}/risk-report";
        public const string Get = Base + "/{packageManager}/{packageName}/{packageVersion}";
    }

    public static class PackageInfo
    {
        private const string Base = $"{ApiBase}/package-info";
        public const string GetVulnerabilities = $"{Base}/package-vulnerabilities";
        public const string Get = Base + "/{packageManager}/{packageName}/{packageVersion}";
    }
}