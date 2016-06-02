/* =======================================================================
* create by kikao
* 2016/4/16 16:57:18
* @version 1.0
* =======================================================================*/

using System;
using System.IO;
using log4net;
using log4net.Config;

namespace Mspend.Framework.Logging.User
{
    /// <summary>
    /// 操作日志记录
    /// </summary>
    public class UserLogger : IUserLogger
    {
        protected internal ILog Logger { get; set; }
        public UserLogger(string name, string configFilename)
        {
            Logger = LogManager.GetLogger(name);
            if (!string.IsNullOrWhiteSpace(configFilename))
                XmlConfigurator.ConfigureAndWatch(GetConfigFile(configFilename));
        }
        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="UserLog"></param>
        public void Log(UserLog UserLog)
        {
            Logger.Info(UserLog);
        }
        protected FileInfo GetConfigFile(string fileName)
        {
            return !Path.IsPathRooted(fileName) ? new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)) : new FileInfo(fileName);
        }
    }
}
