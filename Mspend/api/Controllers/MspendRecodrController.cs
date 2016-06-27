using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Api.Models;
using Autofac;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using Mspend.Framework.Extensions;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/mr")]
    public class MspendRecordController : ApiController
    {
        private readonly IMspendRecordService _mspendRecordService;
        private ICategoryService _categoryService;

        public MspendRecordController()
            : this(IocConfig.Container.Resolve<IMspendRecordService>(),
            IocConfig.Container.Resolve<ICategoryService>())
        {

        }
        public MspendRecordController(IMspendRecordService mspendRecordService,
            ICategoryService categoryService)
        {
            _mspendRecordService = mspendRecordService;
            _categoryService = categoryService;
        }

        [Route("create")]
        [HttpGet]
        public IHttpActionResult Create()
        {
            // var cats = _categoryService.FindBy();
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
            var res = new List<RecentModel>()
            {
                new RecentModel()
                {
                    CategoryName = "今天",
                    MspendRecords = today.ToList().Maps<MspendRecord, MspendRecordModel>()
                },
                new RecentModel()
                {
                    CategoryName = "本周",
                    MspendRecords = laskWeek.ToList().Maps<MspendRecord, MspendRecordModel>()
                }
            };
            return Ok(res);
        }
    }
}
