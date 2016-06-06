using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using Microsoft.Ajax.Utilities;
using Mspend.Domain.Interfaces.Services;

namespace Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private IUserService _userService;

        public AccountController()
            : this(IocConfig.Container.Resolve<IUserService>())
        {

        }
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("login")]
        public IHttpActionResult Login(string name, string password)
        {
            var user = _userService.Login(name, password);
            return Ok();
        }
    }
}
