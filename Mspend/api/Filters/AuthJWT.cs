using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Api.Filters
{
    public class AuthJwt:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //var jwt=actionContext.Request.Headers.Authorization.
        }
    }
}