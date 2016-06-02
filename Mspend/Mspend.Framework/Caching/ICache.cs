/* =======================================================================
* create by kikao
* 2016/4/16 9:19:55
* @version 1.0
* =======================================================================*/

using System;

namespace Mspend.Framework.Caching
{
    public interface ICache<TKey,TResult>
    {
        TResult Get(TKey key,Func<TKey,TResult> func,TimeSpan? expiredTime=null );
        TResult Remove(TKey key);
    }
}
