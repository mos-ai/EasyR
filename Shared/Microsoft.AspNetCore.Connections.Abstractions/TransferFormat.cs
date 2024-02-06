// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/Servers/Connections.Abstractions/src/TransferFormat.cs

using System;

namespace Microsoft.AspNetCore.Connections;

/// <summary>
/// Represents the possible transfer formats.
/// </summary>
[Flags]
public enum TransferFormat
{
    /// <summary>
    /// A binary transport format.
    /// </summary>
    Binary = 0x01,

    /// <summary>
    /// A text transport format.
    /// </summary>
    Text = 0x02
}