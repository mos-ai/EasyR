using ClientSample.Hubs.Internal;

using EasyR.Client;

using Microsoft.Extensions.Logging;

namespace ClientSample.Hubs;

internal class Chat : IHubListener, IDisposable
{
    private bool _disposedValue;

    private readonly ILogger<Chat> logger;

    private List<IDisposable> endpointMappings = new List<IDisposable>();

    public Chat(ILogger<Chat> logger)
    {
        this.logger = logger;
    }

    public void RegisterEndPoints(HubConnection connection)
    {
        endpointMappings.AddRange([
            connection.On<string, string, string>("/chat/whisper", WhisperPlayer)
            ]);
    }

    public void WhisperPlayer(string sender, string recipient, string message)
    {
        logger.LogInformation("Whisper received from '{sender}', to '{recipient}' saying: {message}", sender, recipient, message);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                foreach (var mapping in endpointMappings)
                {
                    mapping.Dispose();
                }

                endpointMappings.Clear();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~Chat()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
