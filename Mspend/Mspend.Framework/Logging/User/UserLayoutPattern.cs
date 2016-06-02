/* =======================================================================
* create by kikao
* 2016/4/16 16:57:18
* @version 1.0
* =======================================================================*/

using log4net.Layout;
using log4net.Util;

namespace Mspend.Framework.Logging.User
{
    public class UserLayoutPattern : PatternLayout
    {
        public UserLayoutPattern()
        {
            AddConverter(new ConverterInfo
                {
                    Name = "UserLog",
                    Type = typeof(UserConverter)
                }
            );
        }
    }
}
