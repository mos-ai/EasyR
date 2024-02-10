// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/server/Core/src/Internal/TypeBaseEnumerationExtensions.cs

namespace EasyR.Internal;

internal static class TypeBaseEnumerationExtensions
{
    public static IEnumerable<Type> AllBaseTypes(this Type type)
    {
        var current = type;
        while (current != null)
        {
            yield return current;
            current = current.BaseType;
        }
    }
}