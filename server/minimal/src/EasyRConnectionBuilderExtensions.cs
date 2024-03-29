﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/server/Core/src/SignalRConnectionBuilderExtensions.cs

using System.Diagnostics.CodeAnalysis;

using EasyR.Internal;

using Microsoft.AspNetCore.Connections;

namespace EasyR;

/// <summary>
/// Extension methods for <see cref="IConnectionBuilder"/>.
/// </summary>
public static class EasyRConnectionBuilderExtensions
{
    private const DynamicallyAccessedMemberTypes HubAccessibility = DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods;

    /// <summary>
    /// Configure the connection to host the specified <see cref="Hub"/> type.
    /// </summary>
    /// <typeparam name="THub">The <see cref="Hub"/> type to host on the connection.</typeparam>
    /// <param name="connectionBuilder">The connection to configure.</param>
    /// <returns>The same instance of the <see cref="IConnectionBuilder"/> for chaining.</returns>
    public static IConnectionBuilder UseHub<[DynamicallyAccessedMembers(HubAccessibility)] THub>(this IConnectionBuilder connectionBuilder) where THub : Hub
    {
        var marker = connectionBuilder.ApplicationServices.GetService(typeof(EasyRCoreMarkerService));
        if (marker == null)
        {
            throw new InvalidOperationException("Unable to find the required services. Please add all the required services by calling " +
                "'IServiceCollection.AddEasyR' inside the call to 'ConfigureServices(...)' in the application startup code.");
        }

        return connectionBuilder.UseConnectionHandler<HubConnectionHandler<THub>>();
    }
}