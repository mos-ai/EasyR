// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/server/Core/src/Internal/HubContext.cs

namespace EasyR.Internal;

internal sealed class HubContext<THub> : IHubContext, IHubContext<THub> where THub : Hub
{
    private readonly HubLifetimeManager<THub> _lifetimeManager;
    private readonly IHubClients _clients;

    public HubContext(HubLifetimeManager<THub> lifetimeManager)
    {
        _lifetimeManager = lifetimeManager;
        _clients = new HubClients<THub>(_lifetimeManager);
        Groups = new GroupManager<THub>(lifetimeManager);
    }

    public IHubClients Clients => _clients;

    public IGroupManager Groups { get; }
}