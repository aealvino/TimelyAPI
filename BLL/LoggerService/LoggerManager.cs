﻿using Abstraction.Interfaces.Logger;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message) => _logger.Info(message);
        
        public void LogWarn(string message) => _logger.Warn(message);
        
        public void LogDebug(string message) => _logger.Debug(message);
        
        public void LogError(string message) => _logger.Error(message);
        
    }
}
    