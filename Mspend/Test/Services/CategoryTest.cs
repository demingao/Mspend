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
    public class CategoryTest
    {
        [SetUp]
        public void Init()
        {
            IocConfig.Inject();
        }
        [Test]
        public void Add()
        {
            var ser = IocConfig.Container.Resolve<ICategoryService>();
            ser.Ctreate(new Category
            {
                Name = "食品",
                Sort = 0,
                CreateTime = DateTime.Now
            });
            ser.Ctreate(new Category
            {
                Name = "日用品",
                Sort = 1,
                CreateTime = DateTime.Now
            });
            ser.Ctreate(new Category
            {
                Name = "交通",
                Sort = 2,
                CreateTime = DateTime.Now
            });
            ser.Ctreate(new Category
            {
                Name = "通讯",
                Sort = 3,
                CreateTime = DateTime.Now
            });
            ser.Ctreate(new Category
            {
                Name = "着装",
                Sort = 4,
                CreateTime = DateTime.Now
            });
            ser.Ctreate(new Category
            {
                Name = "医疗保健",
                Sort = 5,
                CreateTime = DateTime.Now
            });


            ser.Ctreate(new Category
            {
                Name = "文化教育",
                Sort = 6,
                CreateTime = DateTime.Now
            });

            ser.Ctreate(new Category
            {
                Name = "非商品及服务性",
                Sort = 7,
                CreateTime = DateTime.Now
            });
            ser.Ctreate(new Category
            {
                Name = "其他",
                Sort = 8,
                CreateTime = DateTime.Now
            });
        }

        [Test]
        public void Search()
        {
            var ser = IocConfig.Container.Resolve<ICategoryService>();
          
            var cats = ser.FindBy();
        }
    }
}
