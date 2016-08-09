using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    [RoutePrefix("api/mr")]
    public class MspendRecordController : ApiController
    {
        private readonly IMspendRecordService _mspendRecordService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public MspendRecordController()
            : this(IocConfig.Container.Resolve<IMspendRecordService>(),
            IocConfig.Container.Resolve<ICategoryService>(),
            IocConfig.Container.Resolve<IUserService>())
        {

        }
        public MspendRecordController(IMspendRecordService mspendRecordService,
            ICategoryService categoryService,
            IUserService userService)
        {
            _mspendRecordService = mspendRecordService;
            _categoryService = categoryService;
            _userService = userService;
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create(MspendRecordModel record)
        {
            try
            {
                var cat = _categoryService.Findby(x => x.Id == record.CatId).FirstOrDefault();
                var user = _userService.FindBy(x => x.LoginName == "gdm").FirstOrDefault();
                var m = record.Map<MspendRecord>();
                m.Category = cat;
                m.Owner = user;
                m.CreateTime = DateTime.Now;
                var res = _mspendRecordService.Create(m);
                return Ok(res.Map<MspendRecordModel>());
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }
        [Route("recent")]
        [HttpGet]
        public IHttpActionResult Recent()
        {
            var now = DateTime.Now;
            var w = (int)now.DayOfWeek;
            var start = now.Date.AddDays(w == 0 ? w - 6 : -(w - 1));
            var end = now.Date.AddDays((w == 0 ? 0 : 7 - w) + 1);
            var today = _mspendRecordService.Findby(x => x.RecordTime >= now.Date && x.RecordTime < now.Date.AddDays(1)).OrderByDescending(x => x.CreateTime);
            var laskWeek = _mspendRecordService.Findby(x => x.RecordTime >= start && x.RecordTime < end).OrderByDescending(x => x.CreateTime);
            var res = new List<RecentModel>();
            if (today.Any())
                res.Add(new RecentModel()
                {
                    CategoryName = "今天",
                    MspendRecords = today.Maps<MspendRecord, MspendRecordModel>().Select(x =>
                    {
                        x.RecordTime = "";
                        return x;
                    }),
                    TotalMoney = today.Sum(x => x.Money)
                });
            if (laskWeek.Any())
                res.Add(new RecentModel()
                    {
                        CategoryName = "本周",
                        MspendRecords = laskWeek.Maps<MspendRecord, MspendRecordModel>().Select(x =>
                        {
                            x.RecordTime = Convert.ToDateTime(x.RecordTime).ToShortDateString();
                            return x;
                        }),
                        TotalMoney = laskWeek.Sum(x => x.Money)
                    });
            return Ok(res);
        }

        [Route("search")]
        [HttpPost]
        public IHttpActionResult Search(RecordSearchModel model)
        {
            Expression<Func<MspendRecord, bool>> exp = null;
            if (model != null)
            {
                var now = DateTime.Now;
                if (model.DateType > 0)
                    exp = model.DateType <= 3 ? Weeks(model.DateType, now) : Months(model.DateType, now);
                if (model.CategoryTypes != null && model.CategoryTypes.Any())
                {
                    if (exp == null)
                        exp = m => model.CategoryTypes.Contains(m.Category.Id);
                    else exp = exp.And(m => model.CategoryTypes.Contains(m.Category.Id));
                }
            }
            var records = _mspendRecordService.Findby(exp ?? (m => true)).OrderByDescending(x => x.RecordTime);
            var res = records.GroupBy(x => x.RecordTime.Date).Select(d => new
            {
                RecordDate = d.Key.ToShortDateString(),
                TotalMoney = d.Sum(m => m.Money),
                Records = d.Select(m => m).Maps<MspendRecord, MspendRecordModel>()
            });
            return Ok(res);
        }

        public Expression<Func<MspendRecord, bool>> Weeks(int c, DateTime now)
        {
            var w = (int)now.DayOfWeek;
            var days = 7 * c;
            var start = now.Date.AddDays(w == 0 ? w - 6 : -(w - 1));
            var end = now.Date.AddDays((w == 0 ? 0 : days - w) + 1);
            return x => x.RecordTime >= start && x.RecordTime < end;
        }
        public Expression<Func<MspendRecord, bool>> Months(int m, DateTime now)
        {
            var start = now.Date.AddDays(-now.Day + 1);
            var end = start.AddMonths(m + 1);
            return x => x.RecordTime >= start && x.RecordTime < end;
        }
    }
}
