/* =======================================================================
* create by kikao
* 2016/5/25 23:04:46
* @version 1.0
* =======================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Mspend.Data;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using Mspend.Domain.Services;
using Mspend.Framework.Domain;
using Mspend.Framework.UnitOfWork;

namespace Test
{
    public static class IocConfig
    {
        public static IContainer Container { get; private set; }

        public static void Inject()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<MspendRecordService>().As<IMspendRecordService>();
            Container = builder.Build();
        }
    }
}
