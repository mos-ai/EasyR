using Bedrock.Framework;

using EasyR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = new HostBuilder();

builder.ConfigureServices(services =>
{
    services.AddLogging(config =>
    {
        config.AddConsole();
        config.SetMinimumLevel(LogLevel.Trace);
    });

    services.AddEasyR()
            .AddNewtonsoftJsonProtocol();
});
builder.ConfigureServer(server =>
{
    server.UseNamedPipes(namedPipes =>
    {
        namedPipes.Listen(new Bedrock.Framework.NamedPipeEndPoint("default", ".", impersonationLevel: System.Security.Principal.TokenImpersonationLevel.None), builder =>
        {
            builder.UseConnectionLogging();
            
            builder.UseHub<ServerMinimalSample.Hubs.Chat>();
        });
    });
    server.UseSockets(sockets =>
    {
        sockets.ListenAnyIP(9000, builder =>
        {
            builder.UseConnectionLogging();

            builder.UseHub<ServerMinimalSample.Hubs.Chat>();
        });
    });
});


builder.UseConsoleLifetime();
using var host = builder.Build();

await host.RunAsync();