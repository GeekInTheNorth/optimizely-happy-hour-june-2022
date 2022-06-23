namespace CmsSampleSite.HealthChecks;

using Microsoft.Extensions.DependencyInjection;

public static class HealthCheckServiceExtensions
{
    public static IHealthChecksBuilder AddCustomHealthChecks(this IHealthChecksBuilder builder)
    {
        // builder.AddCmsHealthCheck();
        builder.AddCheck<CmsDatabaseHealthCheck>("CMS DB Check");

        return builder;
    }
}