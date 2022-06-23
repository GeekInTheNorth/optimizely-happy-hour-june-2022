namespace CmsSampleSite.HealthChecks;

using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public class CmsDatabaseHealthCheck : IHealthCheck
{
    private readonly string _connectionString;

    private const string DatabaseName = "EPiServerDB";

    public CmsDatabaseHealthCheck(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString(DatabaseName);
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(cancellationToken);

            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT TOP 1 * FROM INFORMATION_SCHEMA.TABLES";

            await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);

            return HealthCheckResult.Healthy("Successfully connected to the CMS Database.");
        }
        catch (Exception exception)
        {
            return HealthCheckResult.Unhealthy("Failure encountered with connecting to the CMS Database.",
                exception);
        }
    }
}