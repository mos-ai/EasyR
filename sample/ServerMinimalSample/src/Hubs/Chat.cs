using EasyR;

using Microsoft.Extensions.Logging;

namespace ServerMinimalSample.Hubs;

public class Chat : Hub<IChatClient>
{
    private readonly ILogger<Chat> logger;

    public Chat(ILogger<Chat> logger)
    {
        this.logger = logger;
    }

    public Task WhisperPlayer(string sender, string recipient, string message)
    {
        logger.LogInformation("message received: whisper (sender = '{Sender}', Recipient = '{Recipient}', Message = '{Message}'", sender, recipient, message);
        var targetClient = Clients.User(recipient);
        return targetClient.Whisper(sender, recipient, message);
    }
}
