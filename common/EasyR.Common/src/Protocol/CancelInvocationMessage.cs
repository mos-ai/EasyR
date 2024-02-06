// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/SignalR.Common/src/Protocol/CancelInvocationMessage.cs

namespace EasyR.Protocol;

/// <summary>
/// The <see cref="CancelInvocationMessage"/> represents a cancellation of a streaming method.
/// </summary>
public class CancelInvocationMessage : HubInvocationMessage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CancelInvocationMessage"/> class.
    /// </summary>
    /// <param name="invocationId">The ID of the hub method invocation being canceled.</param>
    public CancelInvocationMessage(string invocationId) : base(invocationId)
    {
    }
}