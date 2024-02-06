using Microsoft.Extensions.DependencyInjection;

namespace EasyR.Server.Internal;

internal sealed class EasyRServerBuilder : IEasyRServerBuilder
{
    public EasyRServerBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }
}
