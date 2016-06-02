/* =======================================================================
* create by kikao
* 2016/4/16 16:57:18
* @version 1.0
* =======================================================================*/

using log4net.Core;
using log4net.Util;

namespace Mspend.Framework.Logging.User
{
    /// <summary>
    /// 用户日志格式转换器
    /// </summary>
    public class UserConverter : PatternConverter
    {
        protected override void Convert(System.IO.TextWriter writer, object state)
        {
            if (state == null)
            {
                writer.Write(SystemInfo.NullText);
                return;
            }
            var loggingEvent = state as LoggingEvent;
            var UserInfo = loggingEvent.MessageObject as UserLog;
            if (UserInfo == null)
            {
                writer.Write(SystemInfo.NullText);
            }
            else
            {
                switch (this.Option.ToLower())
                {
                    case "userid":
                        writer.Write(UserInfo.UserId);
                        break;
                    case "username":
                        writer.Write(UserInfo.UserName);
                        break;
                    case "target":
                        writer.Write(UserInfo.Target);
                        break;
                    case "remark":
                        writer.Write(UserInfo.Remark);
                        break;
                    case "detail":
                        writer.Write(UserInfo.Detail);
                        break;
                    case "ip":
                        writer.Write(UserInfo.Ip);
                        break;
                    default:
                        writer.Write(SystemInfo.NullText);
                        break;
                }
            }
        }
    }
}
