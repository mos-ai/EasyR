// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/Shared/AwaitableThreadPool.cs

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EasyR.Internal;

internal static class AwaitableThreadPool
{
    public static Awaitable Yield()
    {
        return new Awaitable();
    }

    public readonly struct Awaitable : ICriticalNotifyCompletion
    {
        public void GetResult()
        {
        }

        public Awaitable GetAwaiter() => this;

        public bool IsCompleted => false;

        public void OnCompleted(Action continuation)
        {
            Task.Run(continuation);
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            OnCompleted(continuation);
        }
    }
}