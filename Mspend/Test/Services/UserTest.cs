﻿/* =======================================================================
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
    public class UserTest
    {
        [SetUp]
        public void Init()
        {
            IocConfig.Inject();
        }
        [Test]
        public void Add()
        {
            IocConfig.Container.Resolve<IUserService>().Register(new User()
            {
                CreateTime = DateTime.Now,
                LoginName = "test",
                NickName = "test",
                Password = "123456",
                ProfilePicture = ""
            });
        }
    }
}
