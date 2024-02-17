#if !NETCOREAPP1_0_OR_GREATER
using Backports.System.IO.Pipes;
#else
using System.IO.Pipes;
#endif

using Bedrock.Framework;

using ClientSample;
using ClientSample.Hubs.Internal;

using EasyR.Client;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

var builder = new HostBuilder();

builder.ConfigureServices(services =>
{
    services.AddLogging(config =>
    {
        config.AddConsole();
        config.SetMinimumLevel(LogLevel.Trace);
    });
    services.AddSingleton(serviceProvider => CreateSocketConnection(serviceProvider));

    // Register Hubs
    services.AddSingleton<ClientSample.Hubs.Chat>();
});

builder.UseConsoleLifetime();
var host = builder.Build();

var connection = host.Services.GetRequiredService<HubConnection>();

// Register Endpoints
connection.MapEndpoint<ClientSample.Hubs.Chat>(host.Services);

var hostTask = host.StartAsync();
await ConnectAsync(connection);

var server = ActivatorUtilities.CreateInstance<HubProxy>(host.Services);

var shutdown = false;
Console.CancelKeyPress += (_,_) => shutdown = true;

Console.WriteLine("Enter a message to send, press Ctrl+C to shutdown.");
while (!shutdown)
{
    var message = Console.ReadLine();
    if (message == null)
        break;
    await server.Chat.Whisper("ClientSender", "ServerRecipient", message);
}

await hostTask;
await host.WaitForShutdownAsync();

static HubConnection CreateNamedPipeConnection(IServiceProvider serviceProvider)
{
    var endPoint = new NamedPipeEndPoint("default", ".", impersonationLevel: System.Security.Principal.TokenImpersonationLevel.None);
    var builder = new HubConnectionBuilder();

    builder.WithNamedPipe(endPoint);
    builder.AddNewtonsoftJsonProtocol();

    builder.Services.AddLogging();
    return builder.Build();
}

static HubConnection CreateSocketConnection(IServiceProvider serviceProvider)
{
    var endPoint = new IPEndPoint(IPAddress.Loopback, 9000);
    var builder = new HubConnectionBuilder();

    builder.WithSocket(endPoint);
    builder.AddNewtonsoftJsonProtocol();

    builder.Services.AddLogging();
    return builder.Build();
}


static async Task<bool> ConnectAsync(HubConnection connection, CancellationToken token = default)
{
    var tries = 0;
    while (tries++ < 5)
    {
        try
        {
            await connection.StartAsync(token);
            return true;
        }
        catch when (token.IsCancellationRequested)
        {
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            Console.WriteLine("Failed to connect, trying again in 5000(ms)");

            await Task.Delay(5000, token);
        }
    }

    return false;
}