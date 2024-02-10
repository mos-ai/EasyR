// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/server/Core/src/IHubClients.cs

using EasyR.Internal;

namespace EasyR;

/// <summary>
/// An abstraction that provides access to client connections.
/// </summary>
public interface IHubClients : IHubClients<IClientProxy>
{
    /// <summary>
    /// Gets a proxy that can be used to invoke methods on a single client connected to the hub and receive results.
    /// </summary>
    /// <param name="connectionId">The connection ID.</param>
    /// <returns>A client caller.</returns>
    new ISingleClientProxy Client(string connectionId) => new NonInvokingSingleClientProxy(((IHubClients<IClientProxy>)this).Client(connectionId), "IHubClients.Client(string connectionId)");
}