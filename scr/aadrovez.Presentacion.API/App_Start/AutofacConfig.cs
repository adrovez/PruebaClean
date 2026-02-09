using Autofac;
using Autofac.Integration.WebApi;

using aadrovez.Aplicacion.IRepositories;
using aadrovez.Aplicacion.IServices;
//using aadrovez.Aplicacion.Mapping;
using aadrovez.Aplicacion.Services;
using aadrovez.Infraestructura.Data;
using aadrovez.Infraestructura.Repositories;

//using AutoMapper;
using System.Reflection;
using System.Web.Http;

namespace aadrovez.Presentacion.API.App_Start
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
                     

            builder.Register(ctx =>
            {
                var asm = typeof(aadrovez.Aplicacion.Mapping.MappingProfile).Assembly;
                var configmapper = new global::AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<aadrovez.Aplicacion.Mapping.MappingProfile>();
                });

                configmapper.AssertConfigurationIsValid();
                return configmapper;
            }).As<AutoMapper.IConfigurationProvider>()
              .SingleInstance();

            builder.Register(ctx =>
            {
                var configmapper = ctx.Resolve<AutoMapper.IConfigurationProvider>();
                return configmapper.CreateMapper(ctx.Resolve);
            }).As<AutoMapper.IMapper>()
              .InstancePerLifetimeScope();


            // =====================
            // Infrastructure
            // =====================
            builder.RegisterType<AppDbContext>()
                   .AsSelf()
                   .InstancePerRequest();

            builder.RegisterType<TablaCodigoRepository>()
                   .As<ITablaCodigoRepository>()
                   .InstancePerRequest();

            // =====================
            // Application
            // =====================
            builder.RegisterType<TablaCodigoService>()
                   .As<ITablaCodigoService>()
                   .InstancePerRequest();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}