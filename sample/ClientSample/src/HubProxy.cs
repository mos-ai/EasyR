using Microsoft.Extensions.DependencyInjection;

using System;

namespace ClientSample;

public class HubProxy
{
    public Hubs.ChatProxy Chat { get; init; }

    public HubProxy(IServiceProvider services)
    {
        Chat = ActivatorUtilities.CreateInstance<Hubs.ChatProxy>(services);
    }
}
