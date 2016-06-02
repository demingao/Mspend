/* =======================================================================
* create by kikao
* 2016/4/16 16:57:18
* @version 1.0
* =======================================================================*/


namespace  Mspend.Framework.Logging.User
{
    /// <summary>
    /// 操作日志记录接口
    /// </summary>
   public interface IUserLogger
   {
       void Log(UserLog UserLog);
   }
}
