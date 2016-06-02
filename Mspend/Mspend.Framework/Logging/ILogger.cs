/* =======================================================================
* create by kikao
* 2016/4/16 16:57:18
* @version 1.0
* =======================================================================*/

using System;

namespace  Mspend.Framework.Logging
{
    /// <summary>
    /// 日志级别
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 调试
        /// </summary>
        Debug,
        /// <summary>
        /// 信息
        /// </summary>
        Information,
        /// <summary>
        /// 警告
        /// </summary>
        Warning,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 致命错误
        /// </summary>
        Fatal
    }
    /// <summary>
    /// 日志记录接口
    /// </summary>
    public interface ILogger
    {
        bool IsEnabled(LogLevel level);
        void Log(LogLevel level, string message);
        void Log(LogLevel level, string message, Exception exception);
        void Log(LogLevel level, string format, object[] args);
    }
}
