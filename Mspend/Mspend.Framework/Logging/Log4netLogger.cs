/* =======================================================================
* create by kikao
* 2016/4/16 16:57:18
* @version 1.0
* =======================================================================*/

using System;
using System.IO;
using log4net;
using log4net.Config;

namespace  Mspend.Framework.Logging
{
    public class Log4netLogger : ILogger
    {
        private readonly ILog _log;

        public Log4netLogger(string name,string configFilename)
        {
            _log = LogManager.GetLogger(name);
            if (!string.IsNullOrWhiteSpace(configFilename))
                XmlConfigurator.ConfigureAndWatch(GetConfigFile(configFilename));
        }
        /// <summary>
        /// 级别是否启用
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return _log.IsDebugEnabled;
                case LogLevel.Information:
                    return _log.IsInfoEnabled;
                case LogLevel.Warning:
                    return _log.IsWarnEnabled;
                case LogLevel.Error:
                    return _log.IsErrorEnabled;
                case LogLevel.Fatal:
                    return _log.IsFatalEnabled;
            }
            return false;
        }

        /// <summary>
        /// 记录日志重载
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Log(LogLevel level, string message, Exception exception)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    _log.Debug(message, exception);
                    break;
                case LogLevel.Information:
                    _log.Info(message, exception);
                    break;
                case LogLevel.Warning:
                    _log.Warn(message, exception);
                    break;
                case LogLevel.Error:
                    _log.Error(message, exception);
                    break;
                case LogLevel.Fatal:
                    _log.Fatal(message, exception);
                    break;
            }
        }
        /// <summary>
        /// 记录日志重载
        /// </summary>
        /// <param name="level"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void Log(LogLevel level, string format, object[] args)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    _log.DebugFormat(format, args);
                    break;
                case LogLevel.Information:
                    _log.InfoFormat(format, args);
                    break;
                case LogLevel.Warning:
                    _log.WarnFormat(format, args);
                    break;
                case LogLevel.Error:
                    _log.ErrorFormat(format, args);
                    break;
                case LogLevel.Fatal:
                    _log.FatalFormat(format, args);
                    break;
            }
        }
        /// <summary>
        /// 记录日志重载
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public void Log(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    _log.Debug(message);
                    break;
                case LogLevel.Information:
                    _log.Info(message);
                    break;
                case LogLevel.Warning:
                    _log.Warn(message);
                    break;
                case LogLevel.Error:
                    _log.Error(message);
                    break;
                case LogLevel.Fatal:
                    _log.Fatal(message);
                    break;
            }
        }
        protected FileInfo GetConfigFile(string fileName)
        {
            return !Path.IsPathRooted(fileName) ? new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)) : new FileInfo(fileName);
        }
    }
}
