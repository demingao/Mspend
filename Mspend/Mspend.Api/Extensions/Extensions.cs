using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Mspend.Domain.Entities;

namespace Mspend.Api.Extensions
{
    public static class Extensions
    {
        public static User ConvertToUser(this ClaimsIdentity identity)
        {
            var user = new User();
            var claims = identity.Claims;
            var enumerable = claims as Claim[] ?? claims.ToArray();
            if (claims == null || !enumerable.Any()) return user;
            var cn = enumerable.FirstOrDefault(x => x.Type.Equals("username"));
            var ci = enumerable.FirstOrDefault(x => x.Type.Equals("userid"));
            if (cn != null)
                user.LoginName = cn.Value;
            if (ci != null)
                user.Id = Convert.ToInt32(ci.Value);
            return user;
        }
    }
}