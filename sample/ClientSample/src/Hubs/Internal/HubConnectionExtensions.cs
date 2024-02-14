using EasyR.Client;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace ClientSample.Hubs.Internal;

internal static class HubConnectionExtensions
{
    private static IServiceProvider Services;

    internal static HubConnection MapEndpoint<T>(this HubConnection connection, IServiceProvider serviceProvider) where T : class, IHubListener
    {
        Services ??= serviceProvider; // A bit lazy with this. Do it properly in your code.

        var endpointService = Services.GetRequiredService<T>();
        endpointService.RegisterEndPoints(connection);

        return connection;
    }
}
