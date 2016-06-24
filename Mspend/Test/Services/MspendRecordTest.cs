/* =======================================================================
* create by kikao
* 2016/5/25 21:42:53
* @version 1.0
* =======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using NUnit.Framework;

namespace Test.Services
{
    [TestFixture]
    public class MspendRecordTest
    {
        [SetUp]
        public void Init()
        {
            IocConfig.Inject();
        }
        [Test]
        public void Add()
        {
            var ser = IocConfig.Container.Resolve<IMspendRecordService>();
            var cser = IocConfig.Container.Resolve<ICategoryService>();
            var users = IocConfig.Container.Resolve<IUserService>();
            var cat =cser.Get(1);
            var user = users.Login("gdm","123456");
          var msr=   ser.Create(new MspendRecord()
            {
                Category = cat,
                Owner = user,
                Name="吃饭",
                Money = 10,
                RecordTime = DateTime.Now,
                CreateTime = DateTime.Now
            });
            var s = msr;
        }

        [Test]
        public void Search()
        {
            var ser = IocConfig.Container.Resolve<ICategoryService>();
          
            var cats = ser.FindBy();
        } 
        [Test]
        public void Recent()
        {
            var ser = IocConfig.Container.Resolve<IMspendRecordService>();
            var cser = IocConfig.Container.Resolve<ICategoryService>();
            var now = DateTime.Now;
            var w = (int)now.DayOfWeek;
            var start = DateTime.Now.AddDays(w == 0 ? w - 6 : -(w - 1));
            var end = DateTime.Now.AddDays(w == 0 ? 0 : 7 - w);
            var today = ser.Findby(x => x.RecordTime>=now.Date&&x.RecordTime<now.Date.AddDays(1)).OrderByDescending(x => x.CreateTime);
            var laskWeek = ser.Findby(x => x.RecordTime >= start && x.RecordTime <= end).OrderByDescending(x => x.CreateTime);
            if (today.Any())
            {
                var t = today.GroupBy(x => x.Category);
            }
        }
    }
}
