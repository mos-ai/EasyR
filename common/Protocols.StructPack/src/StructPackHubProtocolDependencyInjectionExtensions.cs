using EasyR.Protocol;
using EasyR.Protocols.StructPack.Protocol;

using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class StructPackHubProtocolDependencyInjectionExtensions
{
    /// <summary>
    /// Enables the StructPack protocol for EasyR.
    /// </summary>
    /// <param name="builder">The <see cref="IEasyRBuilder"/> representing the EasyR server to add StuctPack protocol support to.</param>
    /// <returns>The value of <paramref name="builder"/></returns>
    public static TBuilder AddStructPackProtocol<TBuilder>(this TBuilder builder) where TBuilder : IEasyRBuilder
        => AddStructPackProtocol(builder, _ => { });

    /// <summary>
    /// Enables the StuctPack protocol for EasyR and allows options for the StructPack protocol to be configured.
    /// </summary>
    /// <remarks>
    /// Any options configured here will be applied, even if the StuctPack protocol has already been registered with the server.
    /// </remarks>
    /// <param name="builder">The <see cref="IEasyRBuilder"/> representing the EasyR server to add StuctPack protocol support to.</param>
    /// <param name="configure">A delegate that can be used to configure the <see cref="StructPackHubProtocolOptions"/></param>
    /// <returns>The value of <paramref name="builder"/></returns>
    public static TBuilder AddStructPackProtocol<TBuilder>(this TBuilder builder, Action<StructPackHubProtocolOptions> configure) where TBuilder : IEasyRBuilder
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IHubProtocol, StructPackHubProtocol>());
        builder.Services.Configure(configure);
        return builder;
    }
}
