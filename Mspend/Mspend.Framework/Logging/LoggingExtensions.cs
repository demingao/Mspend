/* =======================================================================
* create by kikao
* 2016/4/16 16:57:18
* @version 1.0
* =======================================================================*/

using System;

namespace  Mspend.Framework.Logging
{
    public static class LoggingExtensions
    {
        public static void Debug(this ILogger logger, string message)
        {
            FilteredLog(logger, LogLevel.Debug, message);
        }
        public static void Information(this ILogger logger, string message)
        {
            FilteredLog(logger, LogLevel.Information, message);
        }
        public static void Warning(this ILogger logger, string message)
        {
            FilteredLog(logger, LogLevel.Warning, message);
        }
        public static void Error(this ILogger logger, string message)
        {
            FilteredLog(logger, LogLevel.Error, message);
        }
        public static void Fatal(this ILogger logger, string message)
        {
            FilteredLog(logger, LogLevel.Fatal, message);
        }

        public static void Fatal(this ILogger logger, Exception exception)
        {
            FilteredLog(logger, LogLevel.Fatal, "",exception);
        }

        public static void Debug(this ILogger logger, Exception exception, string message)
        {
            FilteredLog(logger, LogLevel.Debug, message, exception);
        }
        public static void Information(this ILogger logger, Exception exception, string message)
        {
            FilteredLog(logger, LogLevel.Information, message, exception);
        }
        public static void Warning(this ILogger logger, Exception exception, string message)
        {
            FilteredLog(logger, LogLevel.Warning, message, exception);
        }
        public static void Error(this ILogger logger, Exception exception, string message)
        {
            FilteredLog(logger, LogLevel.Error, message, exception);
        }
        public static void Fatal(this ILogger logger, Exception exception, string message)
        {
            FilteredLog(logger, LogLevel.Fatal, message, exception);
        }

        public static void Debug(this ILogger logger, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Debug, format, args);
        }
        public static void Information(this ILogger logger, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Information, format, args);
        }
        public static void Warning(this ILogger logger, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Warning, format, args);
        }
        public static void Error(this ILogger logger, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Error, format, args);
        }
        public static void Fatal(this ILogger logger, string format, params object[] args)
        {
            FilteredLog(logger, LogLevel.Fatal, format, args);
        }
        private static void FilteredLog(ILogger logger, LogLevel level, string message)
        {
            if (logger.IsEnabled(level))
            {
                logger.Log(level, message);
            }
        }
        private static void FilteredLog(ILogger logger, LogLevel level, string message, Exception exception)
        {
            if (logger.IsEnabled(level))
            {
                logger.Log(level, message, exception);
            }
        }
        private static void FilteredLog(ILogger logger, LogLevel level, string format, object[] objects)
        {
            if (logger.IsEnabled(level))
            {
                logger.Log(level, format, objects);
            }
        }
    }
}
