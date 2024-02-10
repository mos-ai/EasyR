using EasyR.Client;

namespace ClientSample.Hubs.Internal;

internal interface IHubListener
{
    void RegisterEndPoints(HubConnection connection);
}
