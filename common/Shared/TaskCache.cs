// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/Shared/TaskCache.cs

namespace EasyR.Internal;

internal static class TaskCache
{
    public static readonly Task<bool> True = Task.FromResult(true);
    public static readonly Task<bool> False = Task.FromResult(false);
}