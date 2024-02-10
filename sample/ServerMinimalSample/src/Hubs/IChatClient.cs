namespace ServerMinimalSample.Hubs;

public interface IChatClient
{
    Task Whisper(string sender, string recipient, string message);
}
