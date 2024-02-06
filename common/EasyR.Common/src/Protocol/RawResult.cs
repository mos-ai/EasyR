// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/e6c79485899829b1849b9f7b441d7e58f679603c/src/SignalR/common/SignalR.Common/src/Protocol/RawResult.cs#L20

using System.Buffers;
using System.Linq;

namespace EasyR.Protocol;

/// <summary>
/// Type returned to <see cref="IHubProtocol"/> implementations to let them know the object being deserialized should be
/// stored as raw serialized bytes in the format of the protocol being used.
/// </summary>
/// <example>
/// In Json that would mean storing the byte representation of ascii {"prop":10} as an example.
/// </example>
public sealed class RawResult
{
    /// <summary>
    /// Stores the raw serialized bytes of a <see cref="CompletionMessage.Result"/> for forwarding to another server.
    /// Will copy the passed in bytes to internal storage.
    /// </summary>
    /// <param name="rawBytes">The raw bytes from the client.</param>
    public RawResult(ReadOnlySequence<byte> rawBytes)
    {
        // Review: If we want to use an ArrayPool we would need some sort of release mechanism
        RawSerializedData = new ReadOnlySequence<byte>(rawBytes.ToArray());
    }

    /// <summary>
    /// The raw serialized bytes from the client.
    /// </summary>
    public ReadOnlySequence<byte> RawSerializedData { get; private set; }
}