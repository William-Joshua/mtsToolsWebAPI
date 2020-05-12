using Autofac;
using Autofac.Integration.WebApi;
using mtsToolsWebAPI.EFCore.EntityFrameworkCore;
using mtsToolsWebAPI.IRepositories;
using mtsToolsWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace mtsToolsWebAPI
{
    /// <summary>
    /// Auto Fac Config File
    /// </summary>
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerRequest();

            builder.RegisterType<TransactionWork>()
                .As<ITransactionWork>()
                .InstancePerRequest();

            builder.RegisterType<EFCoreContext>()
                .As<DbContext>()
                .InstancePerRequest();

            var service = Assembly.Load("mtsToolsWebAPI.Services");
            var iService = Assembly.Load("mtsToolsWebAPI.IServices");
            //根据名称约定（服务层的接口和实现均以App结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(iService, service).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);
            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();
            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();
            return Container;
        }
    }
}