using System;
using System.Linq;
using System.Web.Http;
using Autofac;
using Mspend.Api.Filters;
using Mspend.Api.Models;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using Mspend.Framework.Extensions;

namespace Mspend.Api.Controllers
{
    [Authorize]
    [AppExceptionFilter]
    [RoutePrefix("account")]
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
        [AllowAnonymous]
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
