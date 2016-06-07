using System;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using Api.Models;
using Autofac;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;

        public AccountController()
            : this(IocConfig.Container.Resolve<IUserService>())
        {

        }
        public AccountController(IUserService userService)
        {
            _userService = IocConfig.Container.Resolve<IUserService>();
        }
        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login(AccoutLogin login)
        {
            var user = _userService.Login(login.UserName, login.Password);
            Thread.Sleep(1000);
            return Ok(new { StatusCode = 0 });
        }
        [Route("register")]
        [HttpPost]
        public IHttpActionResult Register(AccoutRegister entity)
        {
            var res = _userService.Register(new User()
            {
                LoginName = entity.UserName,
                NickName = entity.NickName,
                Password = entity.Password,
                CreateTime = DateTime.Now
            });
            return Ok(new { StatusCode = 0, MSG = res });
        }
    }
}
