// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/server/Core/src/SignalRDependencyInjectionExtensions.cs

using EasyR.Internal;
using EasyR;
using EasyR.Server.Internal;

using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static partial class EasyRDependencyInjectionExtensions
{
    /// <summary>
    /// Adds the minimum essential EasyR services to the specified <see cref="IServiceCollection" />. Additional services
    /// must be added separately using the <see cref="IEasyRServerBuilder"/> returned from this method.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>An <see cref="IEasyRServerBuilder"/> that can be used to further configure the EasyR services.</returns>
    public static IEasyRServerBuilder AddEasyRCore(this IServiceCollection services)
    {
        services.TryAddSingleton<EasyRCoreMarkerService>();
        services.TryAddSingleton(typeof(HubLifetimeManager<>), typeof(DefaultHubLifetimeManager<>));
        services.TryAddSingleton(typeof(IHubProtocolResolver), typeof(DefaultHubProtocolResolver));
        services.TryAddSingleton(typeof(IHubContext<>), typeof(HubContext<>));
        services.TryAddSingleton(typeof(IHubContext<,>), typeof(HubContext<,>));
        services.TryAddSingleton(typeof(HubConnectionHandler<>), typeof(HubConnectionHandler<>));
        services.TryAddSingleton(typeof(IUserIdProvider), typeof(DefaultUserIdProvider));
        services.TryAddSingleton(typeof(HubDispatcher<>), typeof(DefaultHubDispatcher<>));
        services.TryAddScoped(typeof(IHubActivator<>), typeof(DefaultHubActivator<>));
        //services.AddAuthorization();
        
        var builder = new EasyRServerBuilder(services);
        return builder;
    }
}
