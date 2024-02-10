// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;

using EasyR;

using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for setting up EasyR services in an <see cref="IServiceCollection" />.
/// </summary>
public static partial class EasyRDependencyInjectionExtensions
{
    /// <summary>
    /// Adds hub specific options to an <see cref="IEasyRServerBuilder"/>.
    /// </summary>
    /// <typeparam name="THub">The hub type to configure.</typeparam>
    /// <param name="signalrBuilder">The <see cref="IEasyRServerBuilder"/>.</param>
    /// <param name="configure">A callback to configure the hub options.</param>
    /// <returns>The same instance of the <see cref="IEasyRServerBuilder"/> for chaining.</returns>
    public static IEasyRServerBuilder AddHubOptions<THub>(this IEasyRServerBuilder easyrBuilder, Action<HubOptions<THub>> configure) where THub : Hub
    {
        ArgumentNullException.ThrowIfNull(easyrBuilder);

        easyrBuilder.Services.AddSingleton<IConfigureOptions<HubOptions<THub>>, HubOptionsSetup<THub>>();
        easyrBuilder.Services.Configure(configure);
        return easyrBuilder;
    }

    /// <summary>
    /// Adds EasyR services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>An <see cref="IEasyRServerBuilder"/> that can be used to further configure the EasyR services.</returns>
    [RequiresUnreferencedCode("EasyR does not currently support trimming or native AOT.", Url = "https://aka.ms/aspnet/trimming")]
    public static IEasyRServerBuilder AddEasyR(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        //services.AddMetrics();
        //services.AddConnections();
        services.TryAddSingleton<EasyRMarkerService>();
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<HubOptions>, HubOptionsSetup>());
        return services.AddEasyRCore();
    }

    /// <summary>
    /// Adds EasyR services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configure">An <see cref="Action{HubOptions}"/> to configure the provided <see cref="HubOptions"/>.</param>
    /// <returns>An <see cref="IEasyRServerBuilder"/> that can be used to further configure the EasyR services.</returns>
    [RequiresUnreferencedCode("EasyR does not currently support trimming or native AOT.", Url = "https://aka.ms/aspnet/trimming")]
    public static IEasyRServerBuilder AddEasyR(this IServiceCollection services, Action<HubOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(services);

        var easyRBuilder = services.AddEasyR();
        // Setup users settings after we've setup ours
        services.Configure(configure);
        return easyRBuilder;
    }
}