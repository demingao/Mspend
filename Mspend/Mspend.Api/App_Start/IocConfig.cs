/* =======================================================================
* create by kikao
* 2016/5/25 23:04:46
* @version 1.0
* =======================================================================*/

using Autofac;
using Mspend.Data;
using Mspend.Domain.Interfaces.Services;
using Mspend.Domain.Services;
using Mspend.Framework.Domain;
using Mspend.Framework.Logging;
using Mspend.Framework.UnitOfWork;

namespace Mspend.Api
{
    public static class IocConfig
    {
        public static IContainer Container { get; private set; }

        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new Log4netLogger("mspend.logger","configs/log4net.config")).As<ILogger>().SingleInstance();
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<MspendRecordService>().As<IMspendRecordService>().InstancePerLifetimeScope();
            Container = builder.Build();
        }
    }
}
