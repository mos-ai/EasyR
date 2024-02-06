// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/Protocols.NewtonsoftJson/src/NewtonsoftJsonProtocolDependencyInjectionExtensions.cs

using EasyR;
using EasyR.Protocol;
using EasyR.Protocols.NewtonsoftJson.Protocol;

using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="IEasyRBuilder"/>.
/// </summary>
public static class NewtonsoftJsonProtocolDependencyInjectionExtensions
{
    /// <summary>
    /// Enables the JSON protocol for EasyR.
    /// </summary>
    /// <remarks>
    /// This has no effect if the JSON protocol has already been enabled.
    /// </remarks>
    /// <param name="builder">The <see cref="IEasyRBuilder"/> representing the EasyR server to add JSON protocol support to.</param>
    /// <returns>The value of <paramref name="builder"/></returns>
    public static TBuilder AddNewtonsoftJsonProtocol<TBuilder>(this TBuilder builder) where TBuilder : IEasyRBuilder
        => AddNewtonsoftJsonProtocol(builder, _ => { });

    /// <summary>
    /// Enables the JSON protocol for EasyR and allows options for the JSON protocol to be configured.
    /// </summary>
    /// <remarks>
    /// Any options configured here will be applied, even if the JSON protocol has already been registered with the server.
    /// </remarks>
    /// <param name="builder">The <see cref="IEasyRBuilder"/> representing the EasyR server to add JSON protocol support to.</param>
    /// <param name="configure">A delegate that can be used to configure the <see cref="NewtonsoftJsonHubProtocolOptions"/></param>
    /// <returns>The value of <paramref name="builder"/></returns>
    public static TBuilder AddNewtonsoftJsonProtocol<TBuilder>(this TBuilder builder, Action<NewtonsoftJsonHubProtocolOptions> configure) where TBuilder : IEasyRBuilder
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IHubProtocol, NewtonsoftJsonHubProtocol>());
        builder.Services.Configure(configure);
        return builder;
    }
}