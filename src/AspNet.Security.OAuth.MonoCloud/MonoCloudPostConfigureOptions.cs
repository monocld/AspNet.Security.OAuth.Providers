/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using Microsoft.Extensions.Options;

namespace AspNet.Security.OAuth.MonoCloud;

/// <summary>
/// A class used to setup defaults for all <see cref="MonoCloudAuthenticationOptions"/>.
/// </summary>
public class MonoCloudPostConfigureOptions : IPostConfigureOptions<MonoCloudAuthenticationOptions>
{
    /// <inheritdoc/>
    public void PostConfigure(
        string? name,
        [NotNull] MonoCloudAuthenticationOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.DomainName))
        {
            throw new ArgumentException("No MonoCloud domain configured.", nameof(options));
        }

        if (string.IsNullOrWhiteSpace(options.Region))
        {
            throw new ArgumentException("No MonoCloud region configured.", nameof(options));
        }

        options.AuthorizationEndpoint = CreateUrl(options.DomainName, options.Region, MonoCloudAuthenticationDefaults.AuthorizationEndpointPath);
        options.TokenEndpoint = CreateUrl(options.DomainName, options.Region, MonoCloudAuthenticationDefaults.TokenEndpointPath);
        options.UserInformationEndpoint = CreateUrl(options.DomainName, options.Region, MonoCloudAuthenticationDefaults.UserInformationEndpointPath);
    }

    private static string CreateUrl(string domainName, string region, string path)
    {
        // Enforce use of HTTPS
        var builder = new UriBuilder($"{domainName}.{region}.monocloud.com")
        {
            Path = path,
            Port = -1,
            Scheme = Uri.UriSchemeHttps,
        };

        return builder.Uri.ToString();
    }
}
