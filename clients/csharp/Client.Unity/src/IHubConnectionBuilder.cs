using Microsoft.Extensions.DependencyInjection;

namespace EasyR.Client;

/// <summary>
/// A builder abstraction for configuring <see cref="HubConnection"/> instances.
/// </summary>
public interface IHubConnectionBuilder : IEasyRBuilder
{
    /// <summary>
    /// Creates a <see cref="HubConnection"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="HubConnection"/> built using the configured options.
    /// </returns>
    HubConnection Build();
}
