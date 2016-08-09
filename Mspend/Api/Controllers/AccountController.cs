using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Api.Filters;
using Api.Models;
using Autofac;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using Mspend.Framework.Extensions;

namespace Api.Controllers
{
    [AppExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMspendRecordService _mspendRecordService;

        public AccountController()
            : this(IocConfig.Container.Resolve<IUserService>(), IocConfig.Container.Resolve<IMspendRecordService>())
        {

        }
        public AccountController(IUserService userService, IMspendRecordService mspendRecordService)
        {
            _userService = userService;
            _mspendRecordService = mspendRecordService;
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login(AccoutLogin login)
        {
            var user = _userService.Login(login.UserName, login.Password);
            return Ok(user.Map<AccoutModel>());
        }
        [Route("uinfo")]
        [HttpGet]
        public IHttpActionResult Info()
        {
            var user = _userService.FindBy(x => x.LoginName.Equals("gdm")).FirstOrDefault();
            var now = DateTime.Now;
            var start = now.Date.AddDays(-now.Day + 1); ;
            var lastMonthMoney =
                _mspendRecordService.Findby(x => x.RecordTime >= start && x.RecordTime < start.AddMonths(1))
                    .Sum(x => x.Money);
            var totalMoney = _mspendRecordService.Findby(x => true)
                    .Sum(x => x.Money);
            return Ok(new { User = user.Map<AccoutModel>(), LastMonthMoney = lastMonthMoney, TotalMoney = totalMoney });
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
