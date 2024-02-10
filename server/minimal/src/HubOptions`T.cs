// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/server/Core/src/HubOptions%60T.cs

namespace EasyR;

/// <summary>
/// Options used to configure the specified hub type instances. These options override globally set options.
/// </summary>
/// <typeparam name="THub">The hub type to configure.</typeparam>
public class HubOptions<THub> : HubOptions where THub : Hub
{
    internal bool UserHasSetValues { get; set; }
}
