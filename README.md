# EasyR

This project is a copy of [SignalR](https://github.com/dotnet/aspnetcore/tree/main/src/SignalR) adjusted to work with Unity on .netstandard 2.0 and with namedpipes.
Also, the server implementation is reworked to not require AspNetCore.

Points of note:
- Intended transport protocols are Newtonsoft.Json and using StructPack
- You need to reference and add the dependency to the transport and protocol you intend to use.
- This implementation is not compatible with SignalR, even if I kept the namespaces, etc. the connection implementation, in particular around SSL is different. Don't ask for it as a feature.