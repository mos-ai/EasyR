// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/SignalR.Common/src/Protocol/HubInvocationMessage.cs

namespace EasyR.Protocol;

/// <summary>
/// A base class for hub messages related to a specific invocation.
/// </summary>
public abstract class HubInvocationMessage : HubMessage
{
    /// <summary>
    /// Gets or sets a name/value collection of headers.
    /// </summary>
    public IDictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// Gets the invocation ID.
    /// </summary>
    public string? InvocationId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HubInvocationMessage"/> class.
    /// </summary>
    /// <param name="invocationId">The invocation ID.</param>
    protected HubInvocationMessage(string? invocationId)
    {
        InvocationId = invocationId;
    }
}