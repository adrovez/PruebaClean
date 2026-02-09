using aadrovez.Aplicacion.IRepositories;
using aadrovez.Aplicacion.IServices;
using aadrovez.Aplicacion.Services;
using aadrovez.Infraestructura.Data;
using aadrovez.Infraestructura.Repositories;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using System.Reflection;
using System.Web.Http;

namespace aadrovez.Presentacion.API.App_Start
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // 1) MapperConfiguration (singleton)
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }))
            .AsSelf()
            .SingleInstance();

            // 2) IMapper (por request)
            builder.Register(ctx =>
            {
                var cfg = ctx.Resolve<MapperConfiguration>();
                return cfg.CreateMapper(ctx.Resolve);
            })
            .As<IMapper>()
            .InstancePerRequest();
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