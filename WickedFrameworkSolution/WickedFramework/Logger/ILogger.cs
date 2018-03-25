using log4net.Core;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedFramework.Enums;

namespace WickedFramework.Logger
{
    public interface ILogger
    {
        void LogException(Exception exception, ExceptionType exceptionType = ExceptionType.Handled);
        void LogException(string message, Exception exception, ExceptionType exceptionType = ExceptionType.Handled);
        void Debug(string message);
        void Debug(Exception exception, string message = "Debug");
        void Fatal(string message);
        void Fatal(Exception exception, string message = "Fatal");
        void Error(string message);
        void Error(Exception exception, string message = "Error");
        void Info(string message);
        void Info(Exception exception, string message = "Info");
        void Warn(string message);
        void Warn(Exception exception, string message = "Warn");
    }
}
