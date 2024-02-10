// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/server/Core/src/Hub%60T.cs

using EasyR.Internal;

namespace EasyR;

/// <summary>
/// A base class for a strongly typed EasyR hub.
/// </summary>
/// <typeparam name="T">The type of client.</typeparam>
public abstract class Hub<T> : Hub where T : class
{
    private IHubCallerClients<T>? _clients;

    /// <summary>
    /// Gets or sets a <typeparamref name="T"/> that can be used to invoke methods on the clients connected to this hub.
    /// </summary>
    public new IHubCallerClients<T> Clients
    {
        get
        {
            _clients ??= new TypedHubClients<T>(base.Clients);
            return _clients;
        }
        set => _clients = value;
    }
}