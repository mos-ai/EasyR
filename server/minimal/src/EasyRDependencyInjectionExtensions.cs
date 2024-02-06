using EasyR.Server.Internal;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class EasyRDependencyInjectionExtensions
{
    /// <summary>
    /// Adds the minimum essential EasyR services to the specified <see cref="IServiceCollection" />. Additional services
    /// must be added separately using the <see cref="IEasyRServerBuilder"/> returned from this method.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>An <see cref="IEasyRServerBuilder"/> that can be used to further configure the EasyR services.</returns>
    public static IEasyRServerBuilder AddEasyRCore(this IServiceCollection services)
    {
        // Add resolver services.

        var builder = new EasyRServerBuilder(services);
        return builder;
    }
}
