﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Abstraction.Interfaces.Logger
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}