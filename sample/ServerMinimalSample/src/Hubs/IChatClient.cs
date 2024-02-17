namespace ServerMinimalSample.Hubs;

// Client side callback functions

public interface IChatClient
{
    Task Whisper(string sender, string recipient, string message);
}
