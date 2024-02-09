// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/server/Core/src/Internal/ErrorMessageHelper.cs

namespace EasyR.Internal;

internal static class ErrorMessageHelper
{
    internal static string BuildErrorMessage(string message, Exception exception, bool includeExceptionDetails)
    {
        if (exception is HubException || includeExceptionDetails)
        {
            return $"{message} {exception.GetType().Name}: {exception.Message}";
        }

        return message;
    }
}