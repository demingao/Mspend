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
    }
}
