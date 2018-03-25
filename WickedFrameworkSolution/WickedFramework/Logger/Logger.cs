using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Core;
using log4net.Appender;
using log4net.Layout;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using WickedFramework.Enums;
using System.Diagnostics;
using System.Reflection;

namespace WickedFramework.Logger
{
    public class Logger : ILogger
    {
        private readonly ILog _logger;

        public bool IsDebugEnabled
        {
            get { return IsEnabled(Level.Debug); }
        }

        public bool IsFatalEnabled
        {
            get { return IsEnabled(Level.Fatal); }
        }

        public bool IsErrorEnabled
        {
            get { return IsEnabled(Level.Error); }
        }

        public bool IsInfoEnabled
        {
            get { return IsEnabled(Level.Info); }
        }

        public bool IsWarnEnabled
        {
            get { return IsEnabled(Level.Warn); }
        }

        public Logger()
        {
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void LogException(Exception exception, ExceptionType exceptionType = ExceptionType.Handled)
        {
            if (exceptionType == ExceptionType.Unhandled)
            {
                Fatal(exception);
            }
            else
            {
                Error(exception);
            }
        }

        public void LogException(string message, Exception exception, ExceptionType exceptionType = ExceptionType.Handled)
        {
            if (exceptionType == ExceptionType.Unhandled)
            {
                Fatal(exception, message);
            }
            else
            {
                Error(exception, message);
            }
        }

        public void Debug(string message)
        {
            WriteMessage(Level.Debug, message);
        }

        public void Debug(Exception exception, string message = "Debug")
        {
            WriteMessage(Level.Debug, message, exception);
        }

        public void Fatal(string message)
        {
            WriteMessage(Level.Fatal, message);
        }

        public void Fatal(Exception exception, string message = "Fatal")
        {
            WriteMessage(Level.Fatal, message, exception);
        }

        public void Error(string message)
        {
            WriteMessage(Level.Error, message);
        }

        public void Error(Exception exception, string message = "Error")
        {
            WriteMessage(Level.Error, message, exception);
        }

        public void Info(string message)
        {
            WriteMessage(Level.Info, message);
        }

        public void Info(Exception exception, string message = "Info")
        {
            WriteMessage(Level.Info, message, exception);
        }

        public void Warn(string message)
        {
            WriteMessage(Level.Warn, message);
        }

        public void Warn(Exception exception, string message = "Warn")
        {
            WriteMessage(Level.Warn, message, exception);
        }

        private void WriteMessage(Level logLevel, string message)
        {
            if (_logger == null) return;
            if (IsEnabled(logLevel))
            {
                if (logLevel == Level.Debug)
                {
                    _logger.Debug(message);
                }
                else if (logLevel == Level.Fatal)
                {
                    _logger.Fatal(message);
                }
                else if (logLevel == Level.Error)
                {
                    _logger.Error(message);
                }
                else if (logLevel == Level.Info)
                {
                    _logger.Info(message);
                }
                else if (logLevel == Level.Warn)
                {
                    _logger.Warn(message);
                }
            }
        }

        private void WriteMessage(Level logLevel, string message, Exception exception)
        {
            if (_logger == null) return;
            if (IsEnabled(logLevel))
            {
                if (logLevel == Level.Debug)
                {
                    _logger.Debug(message, exception);
                }
                else if (logLevel == Level.Fatal)
                {
                    _logger.Fatal(message, exception);
                }
                else if (logLevel == Level.Error)
                {
                    _logger.Error(message, exception);
                }
                else if (logLevel == Level.Info)
                {
                    _logger.Info(message, exception);
                }
                else if (logLevel == Level.Warn)
                {
                    _logger.Warn(message, exception);
                }
            }
        }

        private bool IsEnabled(Level logLevel)
        {
            var enabled = false;
            if (_logger == null) return enabled;

            if (logLevel == Level.Debug)
            {
                enabled = _logger.IsDebugEnabled;
            }
            else if (logLevel == Level.Fatal)
            {
                enabled = _logger.IsDebugEnabled;
            }
            else if (logLevel == Level.Error)
            {
                enabled = _logger.IsDebugEnabled;
            }
            else if (logLevel == Level.Info)
            {
                enabled = _logger.IsDebugEnabled;
            }
            else if (logLevel == Level.Warn)
            {
                enabled = _logger.IsDebugEnabled;
            }
            return enabled;
        }
    }
}