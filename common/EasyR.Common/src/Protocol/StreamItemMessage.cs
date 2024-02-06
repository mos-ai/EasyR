// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/SignalR.Common/src/Protocol/StreamItemMessage.cs

namespace EasyR.Protocol;

/// <summary>
/// Represents a single item of an active stream.
/// </summary>
public class StreamItemMessage : HubInvocationMessage
{
    /// <summary>
    /// The single item from a stream.
    /// </summary>
    public object? Item { get; set; }

    /// <summary>
    /// Constructs a <see cref="StreamItemMessage"/>.
    /// </summary>
    /// <param name="invocationId">The ID of the stream.</param>
    /// <param name="item">An item from the stream.</param>
    public StreamItemMessage(string invocationId, object? item) : base(invocationId)
    {
        Item = item;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"StreamItem {{ {nameof(InvocationId)}: \"{InvocationId}\", {nameof(Item)}: {Item ?? "<<null>>"} }}";
    }
}