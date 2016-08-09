using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Autofac;
using Mspend.Framework.Logging;

namespace Api.Filters
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = false,Inherited = false)]
    public class AppExceptionFilter:ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public AppExceptionFilter()
        {
            this._logger = IocConfig.Container.Resolve<ILogger>();
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            _logger.Error(actionExecutedContext.Exception,"");
            actionExecutedContext.Response=new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("服务器泡妞去了，请稍后再试…")
            };
            base.OnException(actionExecutedContext);
        }
    }
}