﻿using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.DependencyInjection;

using System.ComponentModel;
using System.Net;

namespace EasyR.Client;

public class HubConnectionBuilder : IHubConnectionBuilder
{
    private bool _hubConnectionBuilt;

    /// <inheritdoc />
    public IServiceCollection Services { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HubConnectionBuilder"/> class.
    /// </summary>
    public HubConnectionBuilder()
    {
        Services = new ServiceCollection();
        Services.AddSingleton<HubConnection>();
        Services.AddLogging();
    }

    public HubConnection Build()
    {
        // Build can only be used once
        if (_hubConnectionBuilt)
        {
            throw new InvalidOperationException("HubConnectionBuilder allows creation only of a single instance of HubConnection.");
        }

        _hubConnectionBuilt = true;

        // The service provider is disposed by the HubConnection
        var serviceProvider = Services.BuildServiceProvider();

        var connectionFactory = serviceProvider.GetService<IConnectionFactory>() ??
            throw new InvalidOperationException($"Cannot create {nameof(HubConnection)} instance. An {nameof(IConnectionFactory)} was not configured.");

        var endPoint = serviceProvider.GetService<EndPoint>() ??
            throw new InvalidOperationException($"Cannot create {nameof(HubConnection)} instance. An {nameof(EndPoint)} was not configured.");

        return serviceProvider.GetRequiredService<HubConnection>();
    }

    // Prevents from being displayed in intellisense
    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    // Prevents from being displayed in intellisense
    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    // Prevents from being displayed in intellisense
    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string? ToString()
    {
        return base.ToString();
    }

    // Prevents from being displayed in intellisense
    /// <summary>
    /// Gets the <see cref="Type"/> of the current instance.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Type GetType()
    {
        return base.GetType();
    }
}
