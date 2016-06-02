/* =======================================================================
* create by kikao
* 2016/4/16 16:57:18
* @version 1.0
* =======================================================================*/
namespace Mspend.Framework.Logging.User
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class UserLog
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 操作对象
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// 操作ip
        /// </summary>
        public string Ip { get; set; }
    }
}
