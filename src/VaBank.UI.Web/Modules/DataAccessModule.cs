﻿using System.Data.Entity;
using Autofac;
using VaBank.Core.Data;
using VaBank.Core.Repositories;
using VaBank.Data.EntityFramework;
using VaBank.Data.EntityFramework.Repositories;

namespace VaBank.UI.Web.Modules
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Entity framework data access module registration
            builder.RegisterType<VaBankContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterType<QueryProcessor>().As<IQueryProcessor>().InstancePerRequest();
            builder.RegisterGeneric(typeof (Repository<>)).As(typeof (IRepository<>)).InstancePerRequest();
        }
    }
}