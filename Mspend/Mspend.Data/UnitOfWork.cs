/* =======================================================================
* create by kikao
* 2016/5/24 23:11:13
* @version 1.0
* =======================================================================*/
using System;
using System.Collections.Generic;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Mspend.Domain.Entities.Mapper;
using Mspend.Framework.UnitOfWork;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Mspend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory SessionFactory;
        private ITransaction _transaction;
        private ISession _session;

        public ISession Session
        {
            get
            {
                if (!_session.IsOpen) _session = SessionFactory.OpenSession();
                return _session;
            }
        }

        static UnitOfWork()
        {
            //SessionFactory =
            //    Fluently.Configure()
            //        .Database(
            //            MySQLConfiguration.Standard.ConnectionString(x => x.FromConnectionStringWithKey("MspendDB")))
            //        .BuildSessionFactory();
            SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("MspendDB")))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<UserMap>())
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            _session = SessionFactory.OpenSession();
        }

        public void BeginTransation()
        {
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (null != _transaction && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                if (null != _transaction && _transaction.IsActive)
                    _transaction.Rollback();
                throw;
            }
            finally
            {
                _session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (null != _transaction && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                _session.Dispose();
            }
        }
    }
}
