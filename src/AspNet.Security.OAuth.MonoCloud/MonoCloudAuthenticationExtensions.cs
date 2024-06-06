/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace AspNet.Security.OAuth.MonoCloud;

/// <summary>
/// Extension methods to add MonoCloud authentication capabilities to an HTTP application pipeline.
/// </summary>
public static class MonoCloudAuthenticationExtensions
{
    /// <summary>
    /// Adds <see cref="MonoCloudAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables MonoCloud authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
    public static AuthenticationBuilder AddMonoCloud([NotNull] this AuthenticationBuilder builder)
    {
        return builder.AddMonoCloud(MonoCloudAuthenticationDefaults.AuthenticationScheme, options => { });
    }

    /// <summary>
    /// Adds <see cref="MonoCloudAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables MonoCloud authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="configuration">The delegate used to configure the MonoCloud options.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
    public static AuthenticationBuilder AddMonoCloud(
        [NotNull] this AuthenticationBuilder builder,
        [NotNull] Action<MonoCloudAuthenticationOptions> configuration)
    {
        return builder.AddMonoCloud(MonoCloudAuthenticationDefaults.AuthenticationScheme, configuration);
    }

    /// <summary>
    /// Adds <see cref="MonoCloudAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables MonoCloud authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="scheme">The authentication scheme associated with this instance.</param>
    /// <param name="configuration">The delegate used to configure the MonoCloud options.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
    public static AuthenticationBuilder AddMonoCloud(
        [NotNull] this AuthenticationBuilder builder,
        [NotNull] string scheme,
        [NotNull] Action<MonoCloudAuthenticationOptions> configuration)
    {
        return builder.AddMonoCloud(scheme, MonoCloudAuthenticationDefaults.DisplayName, configuration);
    }

    /// <summary>
    /// Adds <see cref="MonoCloudAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables MonoCloud authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="scheme">The authentication scheme associated with this instance.</param>
    /// <param name="caption">The optional display name associated with this instance.</param>
    /// <param name="configuration">The delegate used to configure the MonoCloud options.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
    public static AuthenticationBuilder AddMonoCloud(
        [NotNull] this AuthenticationBuilder builder,
        [NotNull] string scheme,
        [CanBeNull] string caption,
        [NotNull] Action<MonoCloudAuthenticationOptions> configuration)
    {
        builder.Services.TryAddSingleton<IPostConfigureOptions<MonoCloudAuthenticationOptions>, MonoCloudPostConfigureOptions>();
        return builder.AddOAuth<MonoCloudAuthenticationOptions, MonoCloudAuthenticationHandler>(scheme, caption, configuration);
    }
}
