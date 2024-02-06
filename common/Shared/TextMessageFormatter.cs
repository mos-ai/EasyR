// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/Shared/TextMessageFormatter.cs

using System.Buffers;

namespace EasyR.Internal;

internal static class TextMessageFormatter
{
    // This record separator is supposed to be used only for JSON payloads where 0x1e character
    // will not occur (is not a valid character) and therefore it is safe to not escape it
    public const byte RecordSeparator = 0x1e;

    public static void WriteRecordSeparator(IBufferWriter<byte> output)
    {
        var buffer = output.GetSpan(1);
        buffer[0] = RecordSeparator;
        output.Advance(1);
    }
}